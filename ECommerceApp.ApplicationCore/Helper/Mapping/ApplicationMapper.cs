using AutoMapper;
using ECommerceApp.ApplicationCore.Entities;
using ECommerceApp.ApplicationCore.Model.Request;
using ECommerceApp.ApplicationCore.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.ApplicationCore.Helper.Mapping
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper() { 
        
        CreateMap<Product,ProductRequestModel>().ReverseMap();
           CreateMap<Product,ProductResponseModel>().ReverseMap();
        
        }
    }
}
