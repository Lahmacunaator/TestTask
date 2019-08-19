namespace LakeAreaService.Landscapes
{
    public class Landscape : ILandscape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Type { get; set; }
        public int SquareMorph { get; set; }
    }

    public interface ILandscape
    {
        int X { get; set; }
        int Y { get; set; }
        string Type { get; set; }
        int SquareMorph { get; set; }
    }
}
