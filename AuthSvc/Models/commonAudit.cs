using System.ComponentModel.DataAnnotations;

namespace AuthSvc.Models
{
    public abstract class commonAudit
    {
        public DateTime DateCreated { get; set; }
        public int CreatedBy_Id { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public int ModifiedBy_Id { get; set; }
    }

}