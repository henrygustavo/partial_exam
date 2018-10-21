namespace Web.Site.User.Application.Assembler
{
    using AutoMapper;
    using Web.Site.User.Application.Dto;
    using Web.Site.User.Domain.Entity;

    public class UserCreateProfile : Profile
    {
        public UserCreateProfile()
        {
            CreateMap<UserCreateDto, User>()
               .ForMember(
                   dest => dest.UserName,
                   opts => opts.MapFrom(src => src.UserName)
               )
               .ForMember(
                   dest => dest.Password,
                   opts => opts.MapFrom(src => src.Password)
               );

            CreateMap<User, UserOutputDto>()
              .ForMember(
                  dest => dest.UserName,
                  opts => opts.MapFrom(src => src.UserName)
              )
              .ForMember(
                  dest => dest.Role,
                  opts => opts.MapFrom(src => src.Role != null ? src.Role.Name : string.Empty)
              );
        }
    }
}
