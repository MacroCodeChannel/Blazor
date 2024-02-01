namespace StudentsManagement.Client.Models
{
    public class Grade :UserModifyActivity
    {
        public int Id { get; set; }

        public string GradeCode { get; set; }

        public string GradeName { get; set; }

        public string GradePoint { get; set; }

        public int MarkFrom { get; set; }

        public int MarkTo { get; set; }

        public string Notes { get; set; }
    }
}
