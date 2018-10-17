namespace Web.Site.Template.Application.Assembler
{
    using System.Collections.Generic;
    using AutoMapper;
    using Dto;
    using Domain.Entity;
    public class TemplateCreateAssembler
    {
        private readonly IMapper _mapper;

        public TemplateCreateAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Template ToEntity(TemplateCreateDto modelCreateDto)
        {
            return _mapper.Map<Template>(modelCreateDto);
        }

        public TemplateOutputDto FromEntity(Template model)
        {
            return _mapper.Map<TemplateOutputDto>(model);
        }

        public List<TemplateOutputDto> FromEntityList(List<Template> modelList)
        {
            return _mapper.Map<List<TemplateOutputDto>>(modelList);
        }
    }
}
