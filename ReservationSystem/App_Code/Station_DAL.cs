using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    /// <summary>
    /// Data Access Layer class for operations related to station
    /// </summary>
  public class Station_DAL
    {
        SqlConnection conRailwayReservation;
        public Station_DAL()
        {
            conRailwayReservation = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);

        }


        /// <summary>
        /// Method to add a new station
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="stationCode"></param>
        /// <returns></returns>
        public int AddStation(string stationName, string stationCode)
        {
            int returnValue = 0;
            try
            {
                //Command to add a new station
                SqlCommand cmdAddStation = new SqlCommand("INSERT INTO tbl_Station VALUES(@stationCode,@StationName)", conRailwayReservation);
                cmdAddStation.Parameters.AddWithValue("@Stationname", stationName);
                cmdAddStation.Parameters.AddWithValue("stationCode", stationCode);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                returnValue = cmdAddStation.ExecuteNonQuery();
                

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
        /// Method to update the details of a station
        /// </summary>
        /// <param name="Stationname"></param>
        /// <param name="Stationcode"></param>
        /// <returns></returns>
        public int UpdateStation(string stationName, string stationCode)
        {
            int returnValue = 0;
            try
            {

                //Command to update the details of a station
                SqlCommand cmdUpdateStation = new SqlCommand(" UPDATE tbl_station SET StationName=@StationName WHERE Stationcode=@StationCode", conRailwayReservation);
                cmdUpdateStation.Parameters.AddWithValue("@StationName", stationName);
                cmdUpdateStation.Parameters.AddWithValue("@StationCode", stationCode);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                returnValue = cmdUpdateStation.ExecuteNonQuery();


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
        /// Method to delete a station
        /// </summary>
        /// <param name="stationCode"></param>
        /// <returns></returns>
        public int DeleteStation(string stationCode)
        {
            int returnValue = 0;
            try
            {
                //Command to delete a station
                SqlCommand cmd = new SqlCommand("DELETE FROM tbl_station WHERE Stationcode=@stationcode", conRailwayReservation);
                cmd.Parameters.AddWithValue("@stationcode", stationCode);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                returnValue = cmd.ExecuteNonQuery();


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
        /// Method to fetch stations
        /// </summary>
        /// <returns></returns>
        public DataTable GetStation()
        {
            DataTable dtStation = new DataTable();
            try
            {
                //Command to fetch the station details
                SqlCommand cmdGetStation = new SqlCommand("SELECT * FROM tbl_station", conRailwayReservation);
                conRailwayReservation.Open();
                dtStation.Load(cmdGetStation.ExecuteReader());
         
            }
            catch (SqlException)
            {

                dtStation = null;
            }

            finally
            {
                conRailwayReservation.Close();
            }

            return dtStation;
        }
    }

}
