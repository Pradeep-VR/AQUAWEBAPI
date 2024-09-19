namespace AQUAWEBAPI.Models
{
    public class ApiResponse
    {
        public string Result { get; set; }
        public dynamic data { get; set; }
    }

    public class ResponseApi
    {
        public int ResponseCode { get; set; }
        public string Result { get; set; }
        public dynamic data { get; set; }
    }
}