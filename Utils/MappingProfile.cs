
using AutoMapper;
using Models;

namespace Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dictionary<string, object>, Driver>()
                .ConvertUsing((src, dest) =>
                {
                    foreach (var entry in src)
                    {
                        var propertyInfo = dest.GetType().GetProperty(entry.Key);
                        if (propertyInfo != null)
                        {
                            propertyInfo.SetValue(dest, Convert.ChangeType(entry.Value, propertyInfo.PropertyType));
                        }
                    }
                    return dest;
                });
        }
    }
}