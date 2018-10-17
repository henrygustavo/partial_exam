namespace Web.Site.Template.Application.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Web.Site.Common.Application.Notification;
    using Web.Site.Common.Infrastructure.Persistence;
    using Assembler;
    using Dto;
    using Domain.Repository;
    using Domain.Entity;
    public class TemplateApplicationService : ITemplateApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITemplateRepository _TemplateRepository;
        private readonly TemplateCreateAssembler _TemplateCreateAssembler;

        public TemplateApplicationService(IUnitOfWork unitOfWork,
            ITemplateRepository TemplateRepository,
            TemplateCreateAssembler TemplateCreateAssembler)
        {
            _unitOfWork = unitOfWork;
            _TemplateRepository = TemplateRepository;
            _TemplateCreateAssembler = TemplateCreateAssembler;
        }

        public TemplateOutputDto Get(int id)
        {
            var entity = _TemplateRepository.Get(id);

            return _TemplateCreateAssembler.FromEntity(entity);
        }

        public List<TemplateOutputDto> GetAll()
        {
            var entities = _TemplateCreateAssembler.FromEntityList(_TemplateRepository.GetAll().ToList());

            return entities;
        }

        public void Create(TemplateCreateDto model)
        {
            Notification notification = ValidateModel(model);

            if (notification.HasErrors())
            {
                throw new ArgumentException(notification.ErrorMessage());
            }

            bool status = _unitOfWork.BeginTransaction();

            try
            {
                Template Template = _TemplateCreateAssembler.ToEntity(model);
                _TemplateRepository.Create(Template);
                _unitOfWork.Commit(status);
            }
            catch
            {
                _unitOfWork.Rollback(status);

                notification.AddError("there was error creating Template");
                throw new ArgumentException(notification.ErrorMessage());

            }
        }

        private Notification ValidateModel(TemplateCreateDto model)
        {
            Notification notification = new Notification();

            if (model == null || string.IsNullOrEmpty(model.Name))

            {
                notification.AddError("Invalid JSON data in request body");
                return notification;
            }

            return notification;

        }
    }
}
