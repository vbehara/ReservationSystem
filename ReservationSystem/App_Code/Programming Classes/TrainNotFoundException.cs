using System;

namespace RailwayReservation
{
    class TrainNotFoundException:Exception
    {
         public TrainNotFoundException():base("Train not found exception")
    {
    }
    //Inheriting the constructor of the base class Exception
         public TrainNotFoundException(string message) : base(message)
         {
         }
    }
}
