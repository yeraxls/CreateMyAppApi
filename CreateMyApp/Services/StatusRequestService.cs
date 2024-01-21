using CreateMyApp.Models;
using DB;
using Microsoft.AspNetCore.Mvc;

namespace CreateMyApp.Services
{
    public class StatusRequestService : IStatusRequestService
    {
        private readonly MyAppContext _context;
        public StatusRequestService(MyAppContext context)
        {
            _context = context;
        }

        public async Task<List<StatusRequestDTO>> GetStatusRequests()
        {
            return new List<StatusRequestDTO>();
        }

        public async Task NewStatusRequest(NewStatusRequest newStatus)
        {

        }

        public Task UpdateStatusRequest(UpdateStatusRequestDTO statusRequest)
        {
            throw new NotImplementedException();
        }
    }
}
