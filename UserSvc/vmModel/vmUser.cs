using AuthSvc.Models;
using UserSvc.Models;

namespace UserSvc.vmModel
{
    public class vmUser
    {
        public List<User> users { get; set; }
        public jwt authResponse { get; set; }
    }
}
