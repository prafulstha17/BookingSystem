namespace Domain.Common
{
    public record BaseResponse<T>
    {
        public string? Code { get; set; } = "200";
        public string? Message { get; set; } = "Operation Successful";
        public string? Status { get; set; } = "Success";
        public T? Data { get; set; }
    }
}
