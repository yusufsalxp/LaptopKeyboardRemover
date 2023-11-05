using AutoMapper;
using Services.Contracts;
using Utils;

namespace Services
{

    public class MapperService : IMapperService
    {
        private readonly IMapper _mapper;
        private readonly IJsonService _jsonService;

        public MapperService(IJsonService jsonService)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
            _jsonService = jsonService;
        }

        public T Map<T>(object obj)
        {
            return _mapper.Map<T>(obj);
        }

        public T? MapAnything<T>(object obj)
        {
            var str = _jsonService.Serialize(obj);
            return _jsonService.Deserialize<T>(str);
        }
    }
}