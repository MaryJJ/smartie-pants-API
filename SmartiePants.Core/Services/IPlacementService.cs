using SmartiePants.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartiePants.Core.Services
{
    public interface IPlacementService
    {
        Task<List<PlacementDto>> CreatePlacementsAsync(PlacementsResourceParameters data);

        Task<List<PlacementDto>> UpdatePlacementsAsync(PlacementsResourceParameters data);
    }
}