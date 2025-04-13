using Application.Guest.DTO;
using Application.Guest.Requests;
using Application.Guest.Responses;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GuestManager : IGuestManager
    {
        private IGuestRepository guestRepository;

        public GuestManager(IGuestRepository guestRepository)
        {
            this.guestRepository = guestRepository;
        }

        public async Task<GuestResponse> CreateGuest(CreateGuestRequest request)
        {
            try
            {
                var guest = GuestDTO.MapToEntity(request.Data);

                request.Data.Id = await guestRepository.Create(guest);

                return new GuestResponse
                {
                    Data = request.Data,
                    Success = true,
                };
            }
            catch (Exception)
            {
                return new GuestResponse
                {
                    Success = false,
                    Message = "There was a error while saving at DB.",
                    ErrorCode = ErrorCodes.COULD_NOT_STORE_DATA,
                };
            }
        }
    }
}
