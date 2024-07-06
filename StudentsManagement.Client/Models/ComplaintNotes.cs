namespace StudentsManagement.Client.Models
{
    public class ComplaintNote
    {
        public int Id { get; set; }
        public int ComplaintId { get; set; }
        public Complaint Complaint { get; set; }
        public string Notes { get; set; }
        public string Attachment { get; set; }
        public string ActionedById { get; set; }
        public ApplicationUser ActionedBy { get; set; }
        public DateTime ActionedOn { get; set; }
        public int ActionStatusId { get; set; }
        public SystemCodeDetail ActionStatus { get; set; }
    }
}
