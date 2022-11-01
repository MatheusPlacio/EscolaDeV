using AutoMapper;
using EscolaDeV.DTO.UserDTO;
using EscolaDeV.Models;

namespace EscolaDeV.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserRequest>();
            CreateMap<User, UserResponse>();
        }
    }
}
