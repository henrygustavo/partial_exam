﻿namespace Web.Site.Product.Application.Assembler
{
    using AutoMapper;
    using Web.Site.Common.Domain.ValueObject;
    using Dto;
    using Domain.Entity;
    public class ProductCreateProfile : Profile
    {
        public ProductCreateProfile()
        {
            CreateMap<ProductCreateDto, Product>()
                .ForMember(
                    dest => dest.Balance,
                    opts => opts.MapFrom(
                        src => new Money(src.Balance, src.Currency)
                    )
                )
                 .ForMember(
                    dest => dest.Category,
                      opts => opts.MapFrom(src => new Category { Id = src.CategoryId })
                    );

            CreateMap<ProductOutputDto, Product>()
                .ForMember(
                    dest => dest.Balance,
                    opts => opts.MapFrom(
                        src => new Money(src.Balance, src.Currency)
                    )
                )
                .ReverseMap();

            CreateMap<Product, ProductOutputDto>()
            .ForMember(
                dest => dest.Balance,
                opts => opts.MapFrom(
                    src => src.Balance.Amount
                )
            )
            .ForMember(
                dest => dest.Currency,
                opts => opts.MapFrom(
                    src => src.Balance.Currency.ToString()
                )
            );
        }
    }
}
