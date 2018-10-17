namespace Web.Site.Template.Application.Service
{
    using System.Collections.Generic;
    using Dto;

    public interface ITemplateApplicationService
    {
        TemplateOutputDto Get(int id);
        List<TemplateOutputDto> GetAll();
        void Create(TemplateCreateDto modelCreateDto);

    }
}
