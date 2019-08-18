using System.Text;
using LakeAreaService;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MapDataController : Controller
    {
        /// <summary>
        /// Builds the map object from input file, finds the area of lakes(water squares that have an adjacent water square) and returns the area of lakes.
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
        /// Builds the map object from input file, finds the area of waters and returns the area of waters.
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
            var mapBuilder = new MapBuilder();
            var map = mapBuilder.BuildMap();

            return Json(map);
        }

        /// <summary>
        /// Takes the map data as input and returns the Map object JSON.
        /// </summary>
        /// <param name="mapData"></param>
        /// <response code="200">Returns the Map object JSON</response>
        /// <response code="400">If the item is null</response>  
        [HttpPost("{mapData}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult LoadMapData(string mapData)
        {
            var mapBuilder = new MapBuilder();
            var bytes = Encoding.ASCII.GetBytes(mapData);
            var map = mapBuilder.BuildMap(bytes);

            return Json(map);
        }

        /// <summary>
        /// Takes the map data as input and returns the Lake(water squares that have an adjacent water square) area.
        /// </summary>
        /// <param name="mapData"></param>
        /// <response code="200">Returns the lake surface area</response>
        /// <response code="400">If the item is null</response>  
        [HttpPost("{mapData}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<int> LoadLakeData(string mapData)
        {
            var mapBuilder = new MapBuilder();
            var mapAnalyzer = new MapAnalyzer();

            var bytes = Encoding.ASCII.GetBytes(mapData);
            var map = mapBuilder.BuildMap(bytes);

            var areas = mapAnalyzer.GetLakeAndWaterAreas(map);

            return areas[0];
        }

        /// <summary>
        /// Takes the map data as input and returns the Lake(water squares that have an adjacent water square) area.
        /// </summary>
        /// <param name="mapData"></param>
        /// <response code="200">Returns the water surface area</response>
        /// <response code="400">If the item is null</response>  
        [HttpPost("{mapData}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<int> LoadWaterData(string mapData)
        {
            var mapBuilder = new MapBuilder();
            var mapAnalyzer = new MapAnalyzer();

            var bytes = Encoding.ASCII.GetBytes(mapData);
            var map = mapBuilder.BuildMap(bytes);

            var areas = mapAnalyzer.GetLakeAndWaterAreas(map);

            return areas[1];
        }
    }
}