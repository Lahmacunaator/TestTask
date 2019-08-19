using System.Collections.Generic;

namespace LakeAreaService.Landscapes
{
    public class Row : IRow
    {
        public List<ILandscape> Landscapes { get; set; }

    }

    public interface IRow
    {
        List<ILandscape> Landscapes { get; set; }
    }
}
