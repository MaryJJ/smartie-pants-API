using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartiePants.Core.Resources
{
    public class PlacementsResourceParameters
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public string StoreName { get; set; }

        [Required]
        public string AdUnitId { get; set; }

        public bool? Dryrun { get; set; }

        [Required]
        public List<PlacementForCreationDto> Placements { get; set; }
    }
}