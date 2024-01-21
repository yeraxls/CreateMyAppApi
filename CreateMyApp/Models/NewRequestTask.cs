namespace CreateMyApp.Models
{
    public class NewRequestTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int IdUser { get; set; }
        public DateTime StartDate { get; set; }
        public StatusRequest Status { get; set; }
    }
}
