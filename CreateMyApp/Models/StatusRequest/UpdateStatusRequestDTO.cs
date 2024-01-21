namespace CreateMyApp.Models
{
    public class UpdateStatusRequestDTO : StatusRequestDTO
    {
        public DateTime? LeavingDate { get; set; }
    }
}
