using AutoMapper;

namespace EscolaDeV.Profiles
{
    public static class MapperConfig
    {
        public static MapperConfiguration GetMapperConfig()
        {
            return new MapperConfiguration(x =>
            {
                x.AddProfile(new UserProfile());
            });
        }
    }
}
