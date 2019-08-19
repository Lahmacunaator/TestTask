using System.Collections.Generic;

namespace LakeAreaService.Landscapes
{
    public class Map : IMap
    {
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
        public List<IRow> Rows { get; set; }
    }

    public interface IMap
    {
        int RowCount { get; set; }
        int ColumnCount { get; set; }
        List<IRow> Rows { get; set; }
    }


}
