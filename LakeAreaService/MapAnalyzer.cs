using System;
using System.Collections.Generic;
using System.Linq;
using LakeAreaService.Landscapes;

namespace LakeAreaService
{
    public class MapAnalyzer
    {
        /// <summary>
        /// Get Lake and Water areas from map data, returns array[lake area, water area]
        /// </summary>
        /// <param name="map"></param>
        public int[] GetLakeAndWaterAreas(IMap map)
        {
            var waters = new List<ILandscape>();
            foreach (var rowWithWater in map.Rows.FindAll(r => r.Landscapes.Exists(l => l.Type.Equals("Water"))))
            {
                rowWithWater.Landscapes.FindAll(l => l.Type.Equals("Water")).ForEach(w => waters.Add(w));
            }
            if (waters[0] == null || waters.Count <= 1) return new[] { 0, 0 };

            var tempWaters = waters;
            tempWaters.Reverse();
            var lakeSquares = new List<ILandscape>();
            foreach (var water in waters)
            {
                foreach (var tempWater in tempWaters)
                {
                    if (IsLake(tempWater, water)) continue;
                    lakeSquares.Add(tempWater);
                    lakeSquares.Add(water);
                }
            }

            var duplicates = lakeSquares
                .GroupBy(i => i)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);
            foreach (var d in duplicates)
            {
                lakeSquares.RemoveAll(l => l == d);
                lakeSquares.Add(d);
            }

            return new[] { lakeSquares.Count, waters.Count };
        }

        private static bool IsLake(ILandscape tempWater, ILandscape water)
        {
            if (MathF.Abs(tempWater.SquareMorph - water.SquareMorph) != 1) return true;
            if ((!(MathF.Abs(tempWater.X - water.X) <= 1) || tempWater.Y != water.Y) &&
                (!(MathF.Abs(tempWater.Y - water.Y) <= 1) || tempWater.X != water.X)) return true;
            return false;
        }
    }
}