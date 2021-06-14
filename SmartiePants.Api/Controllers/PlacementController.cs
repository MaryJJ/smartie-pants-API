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
    [Route("api/placements")]
    [ApiController]
    public class PlacementController : ControllerBase
    {
        private readonly IPlacementService _placementService;

        public PlacementController(IPlacementService placementService)
        {
            _placementService = placementService ?? throw new ArgumentNullException(nameof(placementService));
        }

        /// <summary>
        /// Create Placements
        /// </summary>
        /// <param name="resourceParameters"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost()]
        [ProducesResponseType(201, Type = typeof(List<PlacementDto>))]
        [ProducesResponseType(400, Type = typeof(ProblemDetails))]
        [ProducesResponseType(401, Type = typeof(List<PlacementDto>))]
        [ProducesResponseType(422, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> CreatePlacements(PlacementsResourceParameters resourceParameters)
        {
            try
            {
                List<PlacementDto> placements = await _placementService.CreatePlacementsAsync(resourceParameters);
                return Created(string.Empty, placements);
            }
            catch (Exception e)
            {
                return Problem(e.Message, null, StatusCodes.Status422UnprocessableEntity);
            }
        }

        /// <summary>
        /// Update Placements
        /// </summary>
        /// <param name="resourceParameters"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut()]
        [ProducesResponseType(200, Type = typeof(List<PlacementDto>))]
        [ProducesResponseType(400, Type = typeof(ProblemDetails))]
        [ProducesResponseType(401, Type = typeof(List<PlacementDto>))]
        [ProducesResponseType(422, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> UpdatePlacements(PlacementsResourceParameters resourceParameters)
        {
            try
            {
                List<PlacementDto> placements = await _placementService.UpdatePlacementsAsync(resourceParameters);
                return Ok(placements);
            }
            catch (Exception e)
            {
                return Problem(e.Message, null, StatusCodes.Status422UnprocessableEntity);
            }
        }
    }
}