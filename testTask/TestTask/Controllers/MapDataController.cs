using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MapDataController : Controller
    {
        //public MapContext _context;

        //public MapDataController(MapContext context)
        //{
        //    var map = MapBuilder.BuildMap();
        //    _context = context;
        //    if (_context.Maps.Any()) return;
        //    _context.Maps.Add(new Map
        //    {
        //        ColumnCount = map.ColumnCount,
        //        RowCount = map.RowCount,
        //        Rows = map.Rows
        //    });
        //    _context.SaveChanges();
        //}
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Map>>> GetMap(MapContext context)
        //{
        //    return await _context.Maps.ToListAsync();
        //}

        [HttpGet]
        public ActionResult<int> LakeArea()
        {
            var map = MapBuilder.BuildMap();
            var areas = MapAnalyzer.FindAdjacentRows(map);

            return areas[0];
        }
        [HttpGet]
        public ActionResult<int> WaterArea()
        {
            var map = MapBuilder.BuildMap();
            var areas = MapAnalyzer.FindAdjacentRows(map);

            return areas[1];
        }
        //[HttpGet]
        //public ActionResult<string> Test()
        //{
            
        //    var map = MapBuilder.BuildMap();
        //    var areas = MapAnalyzer.FindAdjacentRows(map);
        //    var test = "";
        //    foreach (var row in map.Rows)
        //    {
        //        foreach (var landscape in row.Landscapes)
        //        {
        //            test += landscape.ToString();
        //        }
        //    }

        //    return test;
        //}

        //    var map = MapBuilder.BuildMap();
        //    var lakeSurfaceArea = MapAnalyzer.FindAdjacentRows(map);
        //return lakeSurfaceArea;
        /*$"Lake Surface Area is {lakeSurfaceArea} meters squared"*/
    }
}