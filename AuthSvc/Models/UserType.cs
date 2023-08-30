using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthSvc.Models
{
    public class UserType
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Type { get; set; }
        public int UserTypeCode { get; set; }
    }
}
