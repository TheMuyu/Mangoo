using AutoMapper;
using Mangoo.Services.CouponApi.Data;
using Mangoo.Services.CouponApi.Models;
using Mangoo.Services.CouponApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Mangoo.Services.CouponApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ILogger<CouponController> _logger;
        private ResponseDto _response;
        private readonly IMapper _mapper;
        public CouponController(AppDbContext db, ILogger<CouponController> logger, IMapper mapper)
        {
            _db = db;
            _logger = logger;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(x => x.Id == id);
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon obj = _db.Coupons.First(x => x.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(x => x.Id == id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
