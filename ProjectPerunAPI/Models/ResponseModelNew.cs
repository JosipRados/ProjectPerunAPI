using System.Data;

namespace ProjectPerunAPI.Models
{
    public class ResponseModelNew
    {
        
        public bool Success { get; set; }
        public string? Error { get; set; }
        public DataTable? Data { get; set; }

        public ResponseModelNew() { Data = new DataTable(); }

        public ResponseModelNew(bool success, string? error, DataTable? data)
        {
            Success = success;
            Error = error;
            Data = data;
        }
    }
}

