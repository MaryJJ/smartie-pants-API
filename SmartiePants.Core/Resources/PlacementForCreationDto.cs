using System;
using System.Collections.Generic;
using System.Text;

namespace SmartiePants.Core.Resources
{
    public class PlacementForCreationDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<TargetDto> Targets { get; set; }
    }
}