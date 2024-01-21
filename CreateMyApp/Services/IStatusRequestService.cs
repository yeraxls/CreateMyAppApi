using CreateMyApp.Models;

namespace CreateMyApp.Services
{
    public interface IStatusRequestService
    {
        Task<List<StatusRequestDTO>> GetStatusRequests();
        Task NewStatusRequest(NewStatusRequest newStatus);
        Task UpdateStatusRequest(UpdateStatusRequestDTO statusRequest);
    }
}