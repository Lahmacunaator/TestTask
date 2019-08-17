using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LakeAreaService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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
        [HttpGet]
        public ActionResult<int> LakeArea()
        {
            var mapBuilder = new MapBuilder();
            var mapAnalyzer = new MapAnalyzer();

            var map = mapBuilder.BuildMap();
            var areas = mapAnalyzer.FindAdjacentRows(map);

            return areas[0];
        }

        /// <summary>
        /// Builds the map object, finds the area of lakes(water squares that have an adjacent water square)
        /// </summary>
        /// <returns>total area of waters</returns>
        [HttpGet]
        public ActionResult<int> WaterArea()
        {
            var mapBuilder = new MapBuilder();
            var mapAnalyzer = new MapAnalyzer();

            var map = mapBuilder.BuildMap();
            var areas = mapAnalyzer.FindAdjacentRows(map);

            return areas[1];
        }

        /// <summary>
        /// Builds the map object.
        /// </summary>
        /// <returns>Map object JSON</returns>
        [HttpGet]
        public ActionResult Map()
        {
            var mapBuilder = new MapBuilder();
            var map = mapBuilder.BuildMap();

            return Json(map);
        }
    }
}