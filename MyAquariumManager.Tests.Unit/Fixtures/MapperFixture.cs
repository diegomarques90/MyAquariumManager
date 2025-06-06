using AutoMapper;
using MyAquariumManager.Application.Mappers;

namespace MyAquariumManager.Tests.Unit.Fixtures
{
    public class MapperFixture : IDisposable
    {
        public IMapper Mapper { get; private set; }

        public MapperFixture()
        {
            var mapperConfig = new MapperConfiguration(cfg => 
            {
                cfg.AddProfile(new AnimalProfile());
            });

            Mapper = mapperConfig.CreateMapper();
        }

        public void Dispose()
        {
        }
    }
}
