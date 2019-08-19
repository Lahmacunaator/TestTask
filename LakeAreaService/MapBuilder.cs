using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LakeAreaService.Landscapes;

namespace LakeAreaService
{
    public class MapBuilder
    {
        /// <summary>
        /// Builds map data
        /// </summary>
        public IMap BuildMap(byte[] bytes = null)
        {
            var map = new Map
            {
                Rows = new List<IRow>(),
                ColumnCount = 0,
                RowCount = 0
            };

            var landscapeListAll = GetLandscapeListFromFile(out var rowCount, out var columnCount, bytes);

            for (var i = 0; i < rowCount; i++)
            {
                var row = new Row
                {
                    Landscapes = new List<ILandscape>()
                };
                for (var j = 0; j < columnCount; j++)
                {
                    row.Landscapes.Add(landscapeListAll[(i * columnCount) + j]);
                }
                map.Rows.Add(row);
            }
            map.ColumnCount = columnCount;
            map.RowCount = rowCount;
            return map;
        }
        /// <summary>
        /// Retrieves a list of landscapes with attributes from input file
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>
        public List<ILandscape> GetLandscapeListFromFile(out int rowCount, out int columnCount, byte[] bytes)
        {
            rowCount = 1;
            columnCount = 0;
            var landscapeListAll = new List<ILandscape>();
            if (bytes != null)
            {
                foreach (var landscape in bytes)
                {
                    var input = Convert.ToInt32(landscape);
                        //Reads whitespace as newline
                        if (input == 32) input = 10;
                    BuildLandscapes(ref rowCount, ref columnCount, input, landscapeListAll);
                }
            }
            else
            {
                FileStream stream;
                try
                {
                    stream = new FileStream(".//Resources/Input.asc", FileMode.Open, FileAccess.Read);
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("Cannot open Input.asc for reading");
                    Console.WriteLine(ex);
                    Console.ReadLine();
                    return null;
                }

                var streamReader = new StreamReader(stream, new ASCIIEncoding());

                while ((!streamReader.EndOfStream))
                {
                    var input = streamReader.Read();
                    BuildLandscapes(ref rowCount, ref columnCount, input, landscapeListAll);
                }

                stream.Close();
            }
            return landscapeListAll;
        }

        private static void BuildLandscapes(ref int rowCount, ref int columnCount, int input, ICollection<ILandscape> landscapeListAll)
        {
            var type = "Land";
            switch (input)
            {
                case 13:
                    return;
                case 10:
                    columnCount = 0;
                    rowCount++;
                    break;
                case 35:
                    var land = new Landscape
                    {
                        Type = type,
                        X = columnCount,
                        Y = rowCount - 1,
                        SquareMorph = rowCount + columnCount
                    };
                    landscapeListAll.Add(land);
                    columnCount++;
                    break;
                case 79:
                    type = "Water";
                    var water = new Landscape
                    {
                        Type = type,
                        X = columnCount,
                        Y = rowCount - 1,
                        SquareMorph = rowCount + columnCount
                    };
                    landscapeListAll.Add(water);
                    columnCount++;
                    break;
            }
        }
    }
}