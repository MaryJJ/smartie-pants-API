using System;
using System.Collections.Generic;
using System.Text;

namespace SmartiePants.Core.Resources
{
    public class PlacementDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ArchivedAt { get; set; }
        public List<TargetDto> Targets { get; set; }
        public string StoreName { get; set; }
        public string AdUnitId { get; set; }
        public int GameId { get; set; }
    }
}