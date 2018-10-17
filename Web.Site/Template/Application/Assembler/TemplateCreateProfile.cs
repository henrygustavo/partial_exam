namespace Web.Site.Template.Application.Assembler
{
    using AutoMapper;
    using Dto;
    using Domain.Entity;

    public class TemplateCreateProfile : Profile
    {
        public TemplateCreateProfile()
        {
            CreateMap<TemplateCreateDto, Template>()
                .ForMember(
                    dest => dest.Name,
                    opts => opts.MapFrom(
                        src => src.Name
                    )
                )
               .ReverseMap();

            CreateMap<TemplateOutputDto, Template>()
                .ForMember(
                    dest => dest.Name,
                    opts => opts.MapFrom(
                        src => src.Name
                    )
                )
                .ReverseMap();
        }
    }
}
