using Application.Guest.Responses;
using Application.Guest.Requests;

namespace Domain.Ports
{
    public interface IGuestManager
    {
        Task<GuestResponse> CreateGuest(CreateGuestRequest request);
    }
}
