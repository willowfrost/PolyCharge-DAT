using System.ComponentModel.DataAnnotations;

namespace PolyCharge_DAT.Models
{
    public class Issue
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Issue_CreatedBy { get; set; }
        [Required]
        public string? Issue_Description { get; set; }
        [Required]
        public DateTime? Issue_CreatedOn { get; set; } = DateTime.Now;
        public String? Issue_ClosedBy { get; set; }
        public string? Issue_Resolution { get; set; }
        public DateTime? Issue_ClosedOn { get; set; }
        public IssueStatus Issue_Status { get; set; } = IssueStatus.Open;

    }
    public enum IssueStatus
    {
        Open,
        Closed
    }
}
