using AutoMapper;

namespace Core.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<EntityToModelMappingProfile>();
                x.AddProfile<ModelToEntityMappingProfile>();
            });
        }
    }
}
