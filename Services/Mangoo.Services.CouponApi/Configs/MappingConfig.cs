using AutoMapper;
using Mangoo.Services.CouponApi.Models;
using Mangoo.Services.CouponApi.Models.Dtos;

namespace Mangoo.Services.CouponApi.Configs
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappingConfig;
        }
    }
}