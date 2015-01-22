using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stilago.Models;

namespace Stilago
{
    public static class AutomapperMappings
    {
        /// <summary>
        /// Creates the object map for automapper
        /// </summary>
        public static void Init()
        {
            //Define here all of your automapper mappings

            //Computer
            AutoMapper.Mapper.CreateMap<ViewModels.Computer.ListViewModel, Computer>().ReverseMap();
            AutoMapper.Mapper.CreateMap<ViewModels.Computer.CreateEditViewModel, Computer>().ReverseMap();

            //brand
            AutoMapper.Mapper.CreateMap<ViewModels.Brand.ListViewModel, Brand>().ReverseMap();
        }
    }
}
