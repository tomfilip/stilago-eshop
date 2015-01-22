using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.ViewModels.Computer
{
    public class CreateEditViewModel: EntityDto<Guid>
    {
        [MaxLength(15)]
        [Required]
        public string Model { get; set; }

        /// <summary>
        /// Disk capacity in MB
        /// </summary>
        [Required]
        public long DiskCapacity { get; set; }

        [Required]
        [Range(0, long.MaxValue)]
        public long Price { get; set; }
        public string Description { get; set; }

        [Required]
        public string BrandName { get; set; }
    }
}
