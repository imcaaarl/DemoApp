using Microsoft.OpenApi.Any;

namespace UserSvc.vmModel
{
    public class vmResponse<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }

        public T Data { get; set; }

        public vmResponse(string s,string m,T d) {
            Status = s;
            Message = m;
            Data = d;
        }
    }
}
