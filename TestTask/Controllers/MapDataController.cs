using System.Text;
using LakeAreaService;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MapDataController : Controller
    {
        private readonly MapManager _mapManager = new MapManager();

        /// <summary>
        /// Builds the map object from input file, finds the area of lakes(water squares that have an adjacent water square) and returns the area of lakes.
        /// </summary>
        /// <returns>total area of lakes</returns>
        /// <response code="200">Returns the lake surface area</response>
        /// <response code="400">If the item is null</response> 
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<int> LakeArea()
        {
            var map = _mapManager.Builder.BuildMap();
            var areas = _mapManager.Analyzer.GetLakeAndWaterAreas(map);

            return areas[0];
        }

        /// <summary>
        /// Builds the map object from input file, finds the area of waters and returns the area of waters.
        /// </summary>
        /// <returns>total area of waters</returns>
        /// <response code="200">Returns the water surface area</response>
        /// <response code="400">If the item is null</response>  
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<int> WaterArea()
        {
            var map = _mapManager.Builder.BuildMap();
            var areas = _mapManager.Analyzer.GetLakeAndWaterAreas(map);

            return areas[1];
        }

        /// <summary>
        /// Builds the map object from input file and returns it.
        /// </summary>
        /// <returns>Map object JSON</returns>
        /// <response code="200">Returns the Map object JSON</response>
        /// <response code="400">If the item is null</response>  
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Map()
        {
            var map = _mapManager.Builder.BuildMap();

            return Json(map);
        }

        /// <summary>
        /// Takes the map data as input and returns the total Lake(water squares that have an adjacent water square) surface area.
        /// </summary>
        /// <param name="mapData">"#" as land square meter, "O" as water square meter, combining to make a square map</param>
        /// <remarks>
        /// Sample requests:
        /// 
        /// *   ########## ##O##O#O#O ##OOOOOOOO ####O##### ##OOO##### #OO####O## #OOOO###O# ####OO#### #####O#### ##########
        /// *   ###O##O##O ##O##O#O#O ##OOO##OOO O###OO#### ##OOO##### #OO####O## #O##OO##O# ####OO#### #O###O##O# ####O#####
        /// *   #O#O#O#O#O O#O#O#O#O# #O#O#O#O#O O#O#O#O#O# #O#O#O#O#O O#O#O#O#O# #O#O#O#O#O O#O#O#O#O# #O#O#O#O#O O#O#O#O#O#
        /// 
        /// </remarks>
        /// <response code="200">Returns the lake surface area</response>
        /// <response code="400">If the item is null</response>  
        [HttpPost("{mapData}")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<int> LoadLakeArea(string mapData)
        {
            var bytes = Encoding.ASCII.GetBytes(mapData);

            var map = _mapManager.Builder.BuildMap(bytes);
            var areas = _mapManager.Analyzer.GetLakeAndWaterAreas(map);

            return areas[0];
        }

        /// <summary>
        /// Takes the map data as input and returns the total water surface area.
        /// </summary>
        /// <param name="mapData">"#" as land square meter, "O" as water square meter, combining to make a square map</param>
        /// <remarks>
        /// Sample requests:
        /// 
        /// *   ########## ##O##O#O#O ##OOOOOOOO ####O##### ##OOO##### #OO####O## #OOOO###O# ####OO#### #####O#### ##########
        /// *   ###O##O##O ##O##O#O#O ##OOO##OOO O###OO#### ##OOO##### #OO####O## #O##OO##O# ####OO#### #O###O##O# ####O#####
        /// *   #O#O#O#O#O O#O#O#O#O# #O#O#O#O#O O#O#O#O#O# #O#O#O#O#O O#O#O#O#O# #O#O#O#O#O O#O#O#O#O# #O#O#O#O#O O#O#O#O#O#
        /// 
        /// </remarks>
        /// <response code="200">Returns the water surface area</response>
        /// <response code="400">If the item is null</response>  
        [HttpPost("{mapData}")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<int> LoadWaterArea(string mapData)
        {
            var bytes = Encoding.ASCII.GetBytes(mapData);

            var map = _mapManager.Builder.BuildMap(bytes);
            var areas = _mapManager.Analyzer.GetLakeAndWaterAreas(map);

            return areas[1];
        }

        /// <summary>
        /// Takes the map data as input and returns the Map object JSON.
        /// </summary>
        /// <param name="mapData">Post method input</param>
        /// <remarks>
        /// Sample requests:
        /// 
        /// *   ########## ##O##O#O#O ##OOOOOOOO ####O##### ##OOO##### #OO####O## #OOOO###O# ####OO#### #####O#### ##########
        /// *   ###O##O##O ##O##O#O#O ##OOO##OOO O###OO#### ##OOO##### #OO####O## #O##OO##O# ####OO#### #O###O##O# ####O#####
        /// *   #O#O#O#O#O O#O#O#O#O# #O#O#O#O#O O#O#O#O#O# #O#O#O#O#O O#O#O#O#O# #O#O#O#O#O O#O#O#O#O# #O#O#O#O#O O#O#O#O#O#
        /// 
        /// </remarks>
        /// <response code="200">Returns the Map object JSON</response>
        /// <response code="400">If the item is null</response>
        [HttpPost("{mapData}")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult LoadMap(string mapData)
        {
            var bytes = Encoding.ASCII.GetBytes(mapData);
            var map = _mapManager.Builder.BuildMap(bytes);

            return Json(map);
        }
    }
}