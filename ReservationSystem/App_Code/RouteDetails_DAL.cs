using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Data Access Layer class for operations related to train route
    /// </summary>
   public class RouteDetails_DAL
    {
        SqlConnection conRailwayReservation;
        public RouteDetails_DAL()
        {
            conRailwayReservation = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
            
        }

        /// <summary>
        /// Method to add a new train route
        /// </summary>
        /// <param name="trainId"></param>
        /// <param name="stationCode"></param>
        /// <param name="arrivalTime"></param>
        /// <param name="departureTime"></param>
        /// <param name="distanceFromDestination"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public int AddRoute(int trainId,string stationCode,string arrivalTime,string departureTime,int distanceFromDestination, int day )
        {
            int returnValue = 0;
            try
            {
                //Command to add a new train route
                SqlCommand cmdAddRoute = new SqlCommand("INSERT INTO tbl_TrainRoute VALUES (@TrainId,@StationCode,@ArrivalTime,@DepartureTime,@DistanceFromDestination,@Day)", conRailwayReservation);
                cmdAddRoute.Parameters.AddWithValue("@TrainId", trainId);
                cmdAddRoute.Parameters.AddWithValue("@StationCode", stationCode);
                cmdAddRoute.Parameters.AddWithValue("@ArrivalTime", arrivalTime);
                cmdAddRoute.Parameters.AddWithValue("@DepartureTime", departureTime);
                cmdAddRoute.Parameters.AddWithValue("@DistanceFromDestination", distanceFromDestination);
                cmdAddRoute.Parameters.AddWithValue("@Day", day);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                returnValue = cmdAddRoute.ExecuteNonQuery();
               

            }
            catch (SqlException)
            {
                //In case of any exception, set value of return value to -1
                returnValue = -1;
            }

            finally
            {
                conRailwayReservation.Close();
            }

            return returnValue;
        }


        /// <summary>
        /// Method to update a train route
        /// </summary>
        /// <param name="trainId"></param>
        /// <param name="stationCode"></param>
        /// <param name="arrivalTime"></param>
        /// <param name="departureTime"></param>
        /// <param name="distanceFromDestination"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public int UpdateRoute(int trainId, string stationCode, string arrivalTime, string departureTime, int distanceFromDestination, int day)
        {
            int returnValue = 0;
            try
            {
                //Command to update the train route
                SqlCommand cmdUpdateRoute = new SqlCommand("UPDATE tbl_TrainRoute SET ArrivalTime=@ArrivalTime,DepartureTime =@DepartureTime,DistanceFromDestination=@DistanceFromDestination,Day=@Day WHERE Trainid=@TrainId AND StationCode=@StationCode", conRailwayReservation);
                cmdUpdateRoute.Parameters.AddWithValue("@ArrivalTime", arrivalTime);
                cmdUpdateRoute.Parameters.AddWithValue("@DepartureTime", departureTime);
                cmdUpdateRoute.Parameters.AddWithValue("@DistanceFromDestination", distanceFromDestination);
                cmdUpdateRoute.Parameters.AddWithValue("@Day", day);
                cmdUpdateRoute.Parameters.AddWithValue("@TrainId", trainId);
                cmdUpdateRoute.Parameters.AddWithValue("@StationCode", stationCode);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                returnValue = cmdUpdateRoute.ExecuteNonQuery();


            }
            catch (SqlException)
            {
                //In case of any exception, set value of return value to -1
                returnValue = -1;
            }

            finally
            {
                conRailwayReservation.Close();
            }

            return returnValue;
        }


        /// <summary>
        /// Method to delete a train route
        /// </summary>
        /// <param name="trainid"></param>
        /// <param name="stationCode"></param>
        /// <returns></returns>
        public int DeleteRoute(int trainId, string stationCode)
        {
            int returnValue = 0;
            try
            {
                //Command to delete a train route
                SqlCommand cmdDeleteRoute = new SqlCommand("DELETE FROM tbl_TrainRoute WHERE TrainId=@TrainId AND StationCode=@StationCode", conRailwayReservation);
                cmdDeleteRoute.Parameters.AddWithValue("@TrainId", trainId);
                cmdDeleteRoute.Parameters.AddWithValue("@StationCode", stationCode);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                returnValue = cmdDeleteRoute.ExecuteNonQuery();


            }
            catch (SqlException)
            {
                //In case of any exception, set value of return value to -1
                returnValue = -1;
            }

            finally
            {
                conRailwayReservation.Close();
            }

            return returnValue;
        }


        

        /// <summary>
        /// Method to fetch the train route based on the Train Id
        /// </summary>
        /// <param name="trainId"></param>
        /// <returns></returns>
        public DataTable FetchTrainRoute(int trainId)
        {
            SqlDataAdapter daTrainRoute = new SqlDataAdapter();
            DataTable dtTrainRoute = new DataTable();
             try
            {
                //Command to fetch the train route based on the Train Id
                SqlCommand cmdFetchTrainRoute = new SqlCommand("SELECT * FROM ufn_FetchTrainRoute(@TrainId)", conRailwayReservation);
                cmdFetchTrainRoute.Parameters.AddWithValue("@TrainId", trainId);
                daTrainRoute.SelectCommand = cmdFetchTrainRoute;
                daTrainRoute.Fill(dtTrainRoute);
            }

            catch (SqlException)
            {

                dtTrainRoute = null;
            }

            finally
            {

            }

            return dtTrainRoute;

        }
    }
}
