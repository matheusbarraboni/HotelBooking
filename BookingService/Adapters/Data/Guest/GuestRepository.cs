using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Guest
{
    public class GuestRepository : IGuestRepository
    {
        private HotelDbContext dbContext;

        public GuestRepository(HotelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Create(Domain.Entities.Guest guest)
        {
            dbContext.Guests.Add(guest);
            await dbContext.SaveChangesAsync();
            return guest.Id;
        }

        public Task<Domain.Entities.Guest> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
