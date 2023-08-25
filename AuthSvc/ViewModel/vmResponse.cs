using Microsoft.OpenApi.Any;

namespace AuthSvc.ViewModel
{
    public class vmResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }

        public vmResData Data { get; set; }
    }
}
