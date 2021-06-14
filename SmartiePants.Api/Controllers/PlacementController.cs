using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartiePants.Core.Resources;
using SmartiePants.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartiePants.Api.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class PlacementController : ControllerBase
    {
        private readonly IPlacementService _placementService;

        public PlacementController(IPlacementService placementService)
        {
            _placementService = placementService ?? throw new ArgumentNullException(nameof(placementService));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="storeName"></param>
        /// <param name="adUnitId"></param>
        /// <param name="dryrun"></param>
        /// <param name="placements"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("{projectId}/{storeName}/adunits/{adUnitId}/placements")]
        [ProducesResponseType(201, Type = typeof(List<PlacementDto>))]
        [ProducesResponseType(400, Type = typeof(ProblemDetails))]
        [ProducesResponseType(401, Type = typeof(List<PlacementDto>))]
        [ProducesResponseType(404, Type = typeof(ProblemDetails))]
        [ProducesResponseType(409, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> CreatePlacements(Guid projectId, string storeName, string adUnitId,
                                                          [FromQuery] bool? dryrun,
                                                          [FromBody] List<PlacementForCreationDto> placements)
        {
            try
            {
                PlacementsResourceParameters resourceParameters = new PlacementsResourceParameters
                {
                    ProjectId = projectId,
                    StoreName = storeName,
                    AdUnitId = adUnitId,
                    Dryrun = dryrun,
                    Placements = placements
                };
                List<PlacementDto> result = await _placementService.CreatePlacementsAsync(resourceParameters);
                return Created(string.Empty, result);
            }
            catch (Exception e)
            {
                return Problem(e.Message, null, StatusCodes.Status409Conflict);
            }
        }

        [Authorize]
        [HttpPut("{projectId}/{storeName}/adunits/{adUnitId}/placements")]
        [ProducesResponseType(200, Type = typeof(List<PlacementDto>))]
        [ProducesResponseType(400, Type = typeof(ProblemDetails))]
        [ProducesResponseType(401, Type = typeof(List<PlacementDto>))]
        [ProducesResponseType(404, Type = typeof(ProblemDetails))]
        [ProducesResponseType(409, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> UpdatePlacements(Guid projectId, string storeName, string adUnitId,
                                                          [FromQuery] bool? dryrun,
                                                          [FromBody] List<PlacementForCreationDto> placements)
        {
            try
            {
                PlacementsResourceParameters resourceParameters = new PlacementsResourceParameters
                {
                    ProjectId = projectId,
                    StoreName = storeName,
                    AdUnitId = adUnitId,
                    Dryrun = dryrun,
                    Placements = placements
                };
                List<PlacementDto> result = await _placementService.UpdatePlacementsAsync(resourceParameters);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Problem(e.Message, null, StatusCodes.Status409Conflict);
            }
        }
    }
}