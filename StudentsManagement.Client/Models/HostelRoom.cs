namespace StudentsManagement.Client.Models
{
    public class HostelRoom
    {
        public int Id { get; set; }

        public string RoomNo { get; set; }

        public int HostelId { get; set; }
        public Hostel Hostel { get; set; }

        public int RoomTypeId { get; set; }
        public SystemCodeDetail RoomType { get; set; }

        public int NoOfBeds { get; set; }

        public decimal CostPerBed { get; set; }

        public string Description { get; set; }
    }
}
