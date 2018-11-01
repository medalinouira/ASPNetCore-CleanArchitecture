﻿/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using AutoMapper;

using ASPNetCore.CleanArchitecture.Api.ViewModels.Order;
using ASPNetCore.CleanArchitecture.Api.ViewModels.Product;
using ASPNetCore.CleanArchitecture.Api.ViewModels.Customer;

using ASPNetCore.CleanArchitecture.Models;

namespace ASPNetCore.CleanArchitecture.Api.Mapping
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<OrderViewModel, OrderModel>().ReverseMap();
            CreateMap<ProductViewModel, ProductModel>().ReverseMap();
            CreateMap<CustomerViewModel, CustomerModel>().ReverseMap();
        }
    }
}
