using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestTask.Models;

namespace TestTask
{
    internal class MapBuilder
    {
        public static Map BuildMap()
        {
            var map = new Map
            {
                Rows = new List<Row>(),
                ColumnCount = 0,
                RowCount = 0
            };

            var landscapeListAll = GetMapDataFromFile(out var rowCount, out var columnCount);

            for (var i = 0; i <= rowCount; i++)
            {
                var row = new Row
                {
                    Landscapes = new List<Landscape>()
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

        private static List<Landscape> GetMapDataFromFile(out int rowCount, out int columnCount)
        {
            FileStream stream;
            rowCount = 0;
            columnCount = 0;
            var landscapeListAll = new List<Landscape>();

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
                var type = "Land";
                switch (input)
                {
                    case 13:
                        continue;
                    case 10:
                        columnCount = 0;
                        rowCount++;
                        break;
                    case 35:
                        var land = new Landscape
                        {
                            Type = type,
                            X = columnCount,
                            Y = rowCount
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
                            Y = rowCount,
                            SquareMorph = rowCount + columnCount
                        };
                        landscapeListAll.Add(water);
                        columnCount++;
                        break;
                    default:
                        {
                            Console.WriteLine("Wrong Type of Input!");
                            break;
                        }
                }
            }

            stream.Close();
            return landscapeListAll;
        }
    }
}