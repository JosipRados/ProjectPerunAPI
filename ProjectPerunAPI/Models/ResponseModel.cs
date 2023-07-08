namespace ProjectPerunAPI.Models
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public string? Data { get; set; }

        public ResponseModel() { }

        public ResponseModel(bool success, string? error, string? data)
        {
            Success = success;
            Error = error;
            Data = data;
        }
    }
}
