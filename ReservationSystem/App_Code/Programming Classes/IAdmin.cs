
namespace RailwayReservation
{
    /// <summary>
    /// Interface IAdministrator
    /// </summary>
    interface IAdmin
    {
        /// <summary>
        /// Abstract method to add a booking clerk
        /// </summary>
        void AddBookingClerk();

        /// <summary>
        /// Abstract method to add a train details
        /// </summary>
        void AddTrainDetails();
    }
}
