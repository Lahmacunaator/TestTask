using LakeAreaService;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MapDataController : Controller
    {
        /// <summary>
        /// Builds the map object, finds the area of lakes(water squares that have an adjacent water square)
        /// </summary>
        /// <returns>total area of lakes</returns>
        /// <response code="200">Returns the lake surface area</response>
        /// <response code="400">If the item is null</response> 
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<int> LakeArea()
        {
            var mapBuilder = new MapBuilder();
            var mapAnalyzer = new MapAnalyzer();

            var map = mapBuilder.BuildMap();
            var areas = mapAnalyzer.GetLakeAndWaterAreas(map);

            return areas[0];
        }

        /// <summary>
        /// Builds the map object, finds the area of lakes(water squares that have an adjacent water square)
        /// </summary>
        /// <returns>total area of waters</returns>
        /// <response code="200">Returns the water surface area</response>
        /// <response code="400">If the item is null</response>  
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<int> WaterArea()
        {
            var mapBuilder = new MapBuilder();
            var mapAnalyzer = new MapAnalyzer();

            var map = mapBuilder.BuildMap();
            var areas = mapAnalyzer.GetLakeAndWaterAreas(map);

            return areas[1];
        }

        /// <summary>
        /// Builds the map object.
        /// </summary>
        /// <returns>Map object JSON</returns>
        /// <response code="200">Returns the Map object JSON</response>
        /// <response code="400">If the item is null</response>  
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Map()
        {
            var mapBuilder = new MapBuilder();
            var map = mapBuilder.BuildMap();

            return Json(map);
        }
    }
}