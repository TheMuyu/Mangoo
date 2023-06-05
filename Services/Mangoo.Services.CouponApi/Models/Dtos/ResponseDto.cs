namespace Mangoo.Services.CouponApi.Models.Dtos
{
    public class ResponseDto
    {
#nullable enable
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}