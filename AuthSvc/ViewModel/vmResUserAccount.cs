namespace AuthSvc.ViewModel
{
    public class vmResUserAccount
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
        public int UserRoleCode { get; set; }
        public string UserType { get; set; }
        public int UserTypeCode { get; set; }

        public vmResUserAccount(int id,string fn,string email,string ur,int urc,string ut,int utc)
        {
            Id= id;
            FullName = fn;
            Email = email;
            UserRole = ur;
            UserRoleCode = urc;
            UserType = ut;
            UserTypeCode = utc;
        }
    }
}
