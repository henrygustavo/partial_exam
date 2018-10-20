namespace Web.Site.User.Application.Assembler
{
    using AutoMapper;
    using Web.Site.User.Application.Dto;
    using Web.Site.User.Domain.Entity;

    public class UserCreateProfile : Profile
    {
        public UserCreateProfile()
        {
            CreateMap<UserCreateDTO, User>()
               .ForMember(
                   dest => dest.UserName,
                   opts => opts.MapFrom(src => src.UserName)
               )
               .ForMember(
                   dest => dest.Password,
                   opts => opts.MapFrom(src => src.Password)
               );
        }
    }
}
