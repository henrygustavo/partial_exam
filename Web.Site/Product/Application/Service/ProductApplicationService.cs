namespace Web.Site.Product.Application.Service
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
    using Web.Site.Api.Common.Domain.Specification;
    using Web.Site.Product.Infrastructure.Specification;

    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly ProductCreateAssembler _productCreateAssembler;

        public ProductApplicationService(IUnitOfWork unitOfWork,
            IProductRepository productRepository,
            ProductCreateAssembler productCreateAssembler)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _productCreateAssembler = productCreateAssembler;
        }

        public ProductOutputDto Get(int id)
        {
            AbstractProduct entity = _productRepository.Get(id);

            if (entity == null)
                entity = new NullProduct();

            var resultEntity = _productCreateAssembler.FromEntity(entity);

            return resultEntity;
        }

        public List<ProductOutputDto> GetAll()
        {
            var list = _productRepository.GetAll().ToList();
            var entities = _productCreateAssembler.FromEntityList(list);

            return entities;
        }

        public long Create(ProductCreateDto model)
        {
            Notification notification =  ValidateModel(model);

            if (notification.HasErrors())
            {
                throw new ArgumentException(notification.ErrorMessage());
            }

            bool status = _unitOfWork.BeginTransaction();

            try
            { 
                Product product = _productCreateAssembler.ToEntity(model);
                _productRepository.Create(product);
                _unitOfWork.Commit(status);
                return product.Id;
            }
            catch(Exception ex)
            {
                _unitOfWork.Rollback(status);

                notification.AddError("there was error creating product");
                throw new ArgumentException(notification.ErrorMessage());

            }
        }

        private Notification ValidateModel(ProductCreateDto model)
        {
            Notification notification = new Notification();

            if (model == null)

            {
                notification.AddError("Invalid JSON data in request body");
                return notification;
            }

            if (string.IsNullOrEmpty(model.Name))

            {
                notification.AddError("please fill out product name");
                return notification;
            }

            if (model.CategoryId == 0)

            {
                notification.AddError("Invalid category");
                return notification;
            }

            return notification;

        }

        public List<ProductOutputDto> GetExpensives()
        {
            Specification<Product> specification = Specification<Product>.All;

              specification = specification.And(new ProductWithExpensivePriceSpecification());

            var entities = _productCreateAssembler.FromEntityList(_productRepository.GetFilteredList(specification).ToList());

            return entities;
        }
    }
}
