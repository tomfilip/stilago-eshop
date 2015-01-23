using Stilago.Services.Interface;
using Stilago.ViewModels.Computer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stilago.Repository;
using Stilago.Models;
using Stilago.Fundamentals.Interface;

namespace Stilago.Services
{
    public class SearchService: StilagoAppServiceBase, ISearchService
    {
        public SearchService(IComputerRepository computerRepository, IUserInfo userInfo, IBrandRepository brandRepository)
        {
            _ComputerRepository = computerRepository;
            _BrandRepository = brandRepository;
            _UserInfo = userInfo;
        }

        private readonly IComputerRepository _ComputerRepository;
        private readonly IBrandRepository _BrandRepository;
        private readonly IUserInfo _UserInfo;

        /// <summary>
        /// This method is for the search autocomplete. There is a separate method for the actual search.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public SearchOutput Autocomplete(SearchInput input)
        {
            IEnumerable<ListViewModel> computers = new List<ListViewModel>();
            if (input.SearchTerm != null)
            {
                computers = PerformSearch(input);
            }

            return new SearchOutput()
            {
                Computers = computers
            };
        }

        /// <summary>
        /// This search method is more complex and more accurate but also more resource heavy. This is for the actual search after the search button has been pressed.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public SearchOutput Search(SearchInput input)
        {
            //For this solution I would not use SQL. I would use a search index like Lucene or Flex Search or something similar to get a better search engine and deal with scalability issues.
            //Because of the time constraints I just used SQL for now.

            IEnumerable<ListViewModel> computers = new List<ListViewModel>();

            if (string.IsNullOrWhiteSpace(input.SearchTerm))
            {
                computers = PerformSearch(input);
            }
            else
            {
                //Search engine logic
                //first decompose the whole search term into smaller compounds. In this case words
                var terms = input.SearchTerm.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                //Create an array of computer enumerables. In this array the search results for every term will be stored.
                IEnumerable<ListViewModel>[] searchResults = new IEnumerable<ListViewModel>[terms.Length];

                //Run all the searches for terms
                int index = 0;
                foreach (var term in terms)
                {
                    searchResults[index] = PerformSearch(input);
                    index++;
                }
                

                //now join the partial results
                List<ListViewModel> finalSearchResults = new List<ListViewModel>();
                foreach(var result in searchResults)
                {
                    finalSearchResults.AddRange(result.Where(x => !finalSearchResults.Select(y => y.Id).Contains(x.Id)));
                }
                computers = finalSearchResults;
            }
            return new SearchOutput
            {
                Computers = computers
            };
        }

        /// <summary>
        /// Gets all the brands for the brand filter
        /// </summary>
        /// <returns></returns>
        public ViewModels.Brand.GetAllOutput GetAllBrands()
        {
            var currentCountry = _UserInfo.GetCurrentCountry();

            var brands = _BrandRepository.GetAll().Where(x => x.CountryId == currentCountry.Id).OrderBy(x => x.Name).ToList();
            var vm = AutoMapper.Mapper.Map<IEnumerable<ViewModels.Brand.ListViewModel>>(brands);
            return new ViewModels.Brand.GetAllOutput()
            {
                Brands = vm
            };
        }

        private IEnumerable<ListViewModel> PerformSearch(SearchInput input)
        {
            var currentCountry = _UserInfo.GetCurrentCountry();

            IQueryable<Computer> computers;

            //Instead of this a separate api method should be created with proper pagination implementation.
            //Due to time constraints for now I just return all of the items
            if (!string.IsNullOrWhiteSpace(input.SearchTerm))
            {
                if (input.BrandId.HasValue)
                {
                    computers = _ComputerRepository.GetAll()
                    .Where(x =>
                        (
                            x.Model.Contains(input.SearchTerm) ||
                            x.CountryBrandRelationships.FirstOrDefault(y => y.Brand.CountryId == currentCountry.Id).Brand.Name.Contains(input.SearchTerm) ||
                            x.ComputerInfo.FirstOrDefault(y => y.CountryId == currentCountry.Id).Description.Contains(input.SearchTerm)
                        )
                        && x.CountryBrandRelationships.FirstOrDefault(y => y.Brand.CountryId == currentCountry.Id).BrandId == input.BrandId.Value
                        && x.IsDeleted == false);
                }
                else
                {
                    computers = _ComputerRepository.GetAll()
                    .Where(x =>
                        (
                            x.Model.Contains(input.SearchTerm) ||
                            x.CountryBrandRelationships.FirstOrDefault(y => y.Brand.CountryId == currentCountry.Id).Brand.Name.Contains(input.SearchTerm) ||
                            x.ComputerInfo.FirstOrDefault(y => y.CountryId == currentCountry.Id).Description.Contains(input.SearchTerm)
                        )
                        && x.IsDeleted == false);
                }
            }
            else
            {
                if (input.BrandId.HasValue)
                {
                    computers = _ComputerRepository
                    .GetAll()
                    .Where(x => x.CountryBrandRelationships.FirstOrDefault(y => y.Brand.CountryId == currentCountry.Id).BrandId == input.BrandId.Value);
                }
                else
                {
                    computers = _ComputerRepository
                    .GetAll();
                }
            }

            if (input.SortDirection == SortDirection.Ascending)
            {
                if (input.SortBy == SortBy.Brand)
                {
                    computers = computers.OrderBy(x => x.CountryBrandRelationships.FirstOrDefault(y => y.Brand.CountryId == currentCountry.Id).Brand.Name);
                }
                else if (input.SortBy == SortBy.Model)
                {
                    computers = computers.OrderBy(x => x.Model);
                }
                else if (input.SortBy == SortBy.Price)
                {
                    computers = computers.OrderBy(x => x.ComputerInfo.FirstOrDefault(y => y.CountryId == currentCountry.Id).Price);
                }
            }
            else
            {
                if (input.SortBy == SortBy.Brand)
                {
                    computers = computers.OrderByDescending(x => x.CountryBrandRelationships.FirstOrDefault(y => y.Brand.CountryId == currentCountry.Id).Brand.Name);
                }
                else if (input.SortBy == SortBy.Model)
                {
                    computers = computers.OrderByDescending(x => x.Model);
                }
                else if (input.SortBy == SortBy.Price)
                {
                    computers = computers.OrderByDescending(x => x.ComputerInfo.FirstOrDefault(y => y.CountryId == currentCountry.Id).Price);
                }
            }

            Guid currentCountryId = Guid.Empty;

            if (currentCountry == null)
            { throw new MissingDataExeption("Please run the script to fill in the default data. Without the default data the application is not able to get the current country."); }

            else
            {
                currentCountryId = currentCountry.Id;
            }

            //Do the mappings here
            var computersViewModels = computers.Select(x =>
                new ListViewModel()
                {
                    Id = x.Id,
                    Model = x.Model,
                    DiskCapacity = x.DiskCapacity,
                    BrandName = x.CountryBrandRelationships.Where(y => y.Brand.CountryId == currentCountryId).FirstOrDefault().Brand.Name,
                    Description = x.ComputerInfo.Where(y => y.CountryId == currentCountryId).FirstOrDefault().Description,
                    Price = x.ComputerInfo.Where(y => y.CountryId == currentCountryId).FirstOrDefault().Price,
                }
            ).ToList();
            return computersViewModels;
        }

    }
}
