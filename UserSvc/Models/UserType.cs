using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserSvc.Models
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Type { get;set; }
        [Column(TypeName = "varchar(255)")]
        public string Description { get; set; }
        public int UserTypeCode { get; set; }
        public virtual User tblusers { get; set; }


    }
}
