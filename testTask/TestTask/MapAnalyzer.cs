using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.Models;

namespace TestTask
{
    internal class MapAnalyzer
    {
        public static int[] FindAdjacentRows(Map map)
        {
            var waters = new List<Landscape>();
            foreach (var rowWithWater in map.Rows.FindAll(r => r.Landscapes.Exists(l => l.Type.Equals("Water"))))
            {
                rowWithWater.Landscapes.FindAll(l => l.Type.Equals("Water")).ForEach(w => waters.Add(w));
            }
            if (waters[0] == null || waters.Count <= 1) return new[] { 0, 0 };

            var tempWaters = waters;
            tempWaters.Reverse();
            var lakeSquares = new List<Landscape>();
            foreach (var water in waters)
            {
                foreach (var tempWater in tempWaters)
                {
                    if (MathF.Abs(tempWater.SquareMorph - water.SquareMorph) != 1) continue;
                    if ((!(MathF.Abs(tempWater.X - water.X) <= 1) || tempWater.Y != water.Y) && (!(MathF.Abs(tempWater.Y - water.Y) <= 1) || tempWater.X != water.X)) continue;
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

            return new[] {lakeSquares.Count, waters.Count};
        }

        public static void DrawMap(Map map) //For Console App
        {
            foreach (var row in map.Rows)
            {
                for (var i = 0; i < map.ColumnCount; i++)
                {
                    Console.Write(i == map.ColumnCount - 1 ? "********\n" : "********");
                }

                foreach (var landscape in row.Landscapes)
                {
                    Console.Write(landscape.Type == "Land" ? "********" : "* ~  ~ *");
                    if (landscape.X == map.ColumnCount - 1)
                        Console.Write("\n");
                }

                foreach (var landscape in row.Landscapes)
                {
                    Console.Write(landscape.Type == "Land" ? "********" : "*~  ~  *");
                    if (landscape.X == map.ColumnCount - 1)
                        Console.WriteLine("");
                }

                foreach (var landscape in row.Landscapes)
                {
                    Console.Write(landscape.Type == "Land" ? "********" : "*  ~  ~*");
                    if (landscape.X == map.ColumnCount - 1)
                        Console.WriteLine("");
                }

                for (var i = 0; i < map.ColumnCount; i++)
                {
                    Console.Write(i == map.ColumnCount - 1 ? "********\n" : "********");
                }
            }
        }
    }
}