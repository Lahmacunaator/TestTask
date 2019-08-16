using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models
{
    public class Map
    {
        [Key]
        public int Id { get; set; }
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
        public List<Row> Rows { get; set; }
    }
}
