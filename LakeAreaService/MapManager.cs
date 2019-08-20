using Autofac;

namespace LakeAreaService
{
    public class MapManager
    {
        public IMapBuilder Builder;
        public IMapAnalyzer Analyzer;

        public MapManager()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MapBuilder>();
            builder.RegisterType<MapAnalyzer>();

            var container = builder.Build();
            Builder = container.Resolve<MapBuilder>();
            Analyzer = container.Resolve<MapAnalyzer>();
        }
    }
}