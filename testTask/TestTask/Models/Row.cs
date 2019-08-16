using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class Row
    {
        [Key]
        public int Id { get; set; }
        public List<Landscape> Landscapes { get; set; }
    }
}
