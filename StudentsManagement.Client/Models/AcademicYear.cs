namespace StudentsManagement.Client.Models
{
    public class AcademicYear :UserModifyActivity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int StatusId { get; set; }
        public SystemCodeDetail Status { get; set; }

        public string Notes { get; set; }
    }
}
