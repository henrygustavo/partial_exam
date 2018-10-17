namespace Web.Site.Template.Infrastructure.Persistence.NHibernate.Mapping
{
     using FluentNHibernate.Mapping;
    using Domain.Entity;
    public class TemplateMap : ClassMap<Template>
    {
        public TemplateMap()
        {
            Id(x => x.Id).Column("Template_id");
            Map(x => x.Name).Column("name");
        }
    }
}
