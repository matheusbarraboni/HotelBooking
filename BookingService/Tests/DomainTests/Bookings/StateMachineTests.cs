using Domain.Entities;
using Domain.Enums;
using Action = Domain.Enums.Action;

namespace DomainTests.Bookings
{
    public class StateMachineTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldAlwaysStartWithCreatedStatus()
        {
            var booking = new Booking();
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Created));
        }

        [Test]
        public void ShouldSetStatusToPaidWhenPayingForABookWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangeStatus(Action.Pay);
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Paid));
        }

        [Test]
        public void ShouldSetStatusToRefoundedWhenRefoundForABookWithPaidStatus()
        {
            var booking = new Booking();
            booking.ChangeStatus(Action.Pay);
            booking.ChangeStatus(Action.Refound);
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Refounded));
        }

        [Test]
        public void ShouldSetStatusToFinishedWhenFinishABookWithPaidStatus()
        {
            var booking = new Booking();
            booking.ChangeStatus(Action.Pay);
            booking.ChangeStatus(Action.Finish);
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Finished));
        }

        [Test]
        public void ShouldSetStatusToCanceledWhenCancelABookWithRefoundedStatus()
        {
            var booking = new Booking();
            booking.ChangeStatus(Action.Pay);
            booking.ChangeStatus(Action.Refound);
            booking.ChangeStatus(Action.Cancel);
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Canceled));
        }

        [Test]
        public void ShouldSetStatusToCreatedWhenreopenABookWithCanceledStatus()
        {
            var booking = new Booking();
            booking.ChangeStatus(Action.Cancel);
            booking.ChangeStatus(Action.Reopen);
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Created));
        }

        [Test]
        public void ShouldNotChangeStatusWhenTryToRefoundABookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangeStatus(Action.Refound);
            Assert.That(booking.CurrentStatus, Is.EqualTo(Status.Created));
        }
    }
}