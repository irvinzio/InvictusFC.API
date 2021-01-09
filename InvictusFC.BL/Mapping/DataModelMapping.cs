using AutoMapper;
using InvictusFC.Data.Entities;
using InvictusFC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvictusFC.Service.Mapping
{
    public class DataModelMappingProfile :  Profile
    {
        public DataModelMappingProfile()
        {
            CreateMap<ClientRequest, User>().ReverseMap();
            CreateMap<ClientResponse, User>().ReverseMap();
        }
    }
}
