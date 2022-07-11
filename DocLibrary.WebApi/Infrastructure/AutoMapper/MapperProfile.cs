using AutoMapper;
using DocLibrary.Entity.Entities;
using DocLibrary.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DocLibrary.Model.Common.Enums;

namespace DocLibrary.WebApi.Infrastructure.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Document, DocumentDto>()
                .ForMember(dest => dest.DocumentExtensionCode, opt => opt.MapFrom(src => (short)src.DocumentExtension))
                .ForMember(dest => dest.DocumentExtensionName, opt => opt.MapFrom(src => src.DocumentExtension.ToString()))
                .ForMember(dest => dest.DocumentTypeCode, opt => opt.MapFrom(src => (short)src.DocumentType))
                .ForMember(dest => dest.DocumentTypeName, opt => opt.MapFrom(src => src.DocumentType.ToString()))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => Convert.ToBase64String(src.Content)));

            CreateMap<DocumentDto, Document>()
                .ForMember(dest => dest.DocumentExtension, opt => opt.MapFrom(src => (DocumentExtension)src.DocumentExtensionCode))
                .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => (DocumentExtension)src.DocumentTypeCode))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => Convert.FromBase64String(src.Content)));

            CreateMap<DocumentShareDto, DocumentShare>()
                .ForMember(dest => dest.ShareType, opt => opt.MapFrom(src => (DocumentShareType)src.ShareTypeCode));
        }
    }
}
