using SmartiePants.Core.Resources;
using SmartiePants.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartiePants.Services
{
    public class PlacementMockService : IPlacementService
    {
        private readonly Random _random = new Random();

        public Task<List<PlacementDto>> CreatePlacementsAsync(PlacementsResourceParameters data)
        {
            return MockPlacements(data);
        }

        public Task<List<PlacementDto>> UpdatePlacementsAsync(PlacementsResourceParameters data)
        {
            return MockPlacements(data);
        }

        private Task<List<PlacementDto>> MockPlacements(PlacementsResourceParameters data)
        {
            List<PlacementDto> placements = new List<PlacementDto>();
            foreach (PlacementForCreationDto item in data.Placements)
            {
                PlacementDto placement = new PlacementDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    ArchivedAt = null,
                    Targets = item.Targets,
                    AdUnitId = data.AdUnitId,
                    StoreName = data.StoreName,
                    GameId = RandomNumber(10000, 99999)
                };
                placements.Add(placement);
            }
            return Task.FromResult(placements);
        }

        private int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}