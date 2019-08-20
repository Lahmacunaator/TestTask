namespace LakeAreaService
{
    public class MapManager
    {
        public IMapBuilder Builder;
        public IMapAnalyzer Analyzer;

        public MapManager(IMapBuilder builder, IMapAnalyzer analyzer)
        {
            Builder = builder;
            Analyzer = analyzer;
        }
    }
}