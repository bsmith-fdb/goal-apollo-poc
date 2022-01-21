﻿using AutoMapper;
using FDB.Apollo.IPT.Service.Models.EF;

namespace FDB.Apollo.IPT.Service.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AuditBase, PublishAudit>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.WIPStatusID, opt => opt.MapFrom(src => src.WipStatusId))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.AudCreateDate))
                .ForMember(dest => dest.CreateUserID, opt => opt.MapFrom(src => src.AudCreateUserId))
                .ForMember(dest => dest.CheckoutDate, opt => opt.MapFrom(src => src.AudCheckoutDate))
                .ForMember(dest => dest.CheckoutUserID, opt => opt.MapFrom(src => src.AudCheckoutUserId))
                .ForMember(dest => dest.LastModifyDate, opt => opt.MapFrom(src => src.AudLastModifyDate))
                .ForMember(dest => dest.LastModifyUserID, opt => opt.MapFrom(src => src.AudLastModifyUserId))
                .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => src.AudPublishDate))
                .ForMember(dest => dest.PublishedUserID, opt => opt.MapFrom(src => src.AudPublishUserId))
                .ForMember(dest => dest.FirstDeliveredDate, opt => opt.MapFrom(src => src.FirstDeliveredDate))
                .ForMember(dest => dest.LastDeliveredDate, opt => opt.MapFrom(src => src.LastDeliveredDate))
                .IncludeAllDerived();

            CreateMap<Color, IptColorW>().ReverseMap();
            CreateMap<Color, IptColorP>().ReverseMap();
            CreateMap<IptColorA, PublishAudit>()
                .IncludeBase<AuditBase, PublishAudit>();

            CreateMap<BasicColor, IptBasicColorW>().ReverseMap();
            CreateMap<BasicColor, IptBasicColorP>().ReverseMap();
            CreateMap<PublishAudit, IptBasicColorA>().ReverseMap();
        }
    }
}
