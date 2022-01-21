using AutoMapper;
using FDB.Apollo.IPT.Service.Models.EF;

namespace FDB.Apollo.IPT.Service.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<bool, char>().ConvertUsing(source => source ? '1' : '0');
            CreateMap<char, bool>().ConvertUsing(source => source == '1' ? true : false);

            CreateMap<IAudit, PublishAudit>()
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
                .IncludeAllDerived()
                .ReverseMap();

            CreateMap<Color, IptColorW>().ReverseMap();
            CreateMap<Color, IptColorP>().ReverseMap();
            CreateMap<Color, IptColorC>().ReverseMap();
            CreateMap<PublishAudit, IptColorA>().ReverseMap();

            CreateMap<BasicColor, IptBasicColorW>().ReverseMap();
            CreateMap<BasicColor, IptBasicColorP>().ReverseMap();
            CreateMap<BasicColor, IptBasicColorC>().ReverseMap();
            CreateMap<PublishAudit, IptBasicColorA>().ReverseMap();
        }
    }
}
