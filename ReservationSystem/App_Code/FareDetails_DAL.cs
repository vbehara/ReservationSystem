using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Data Access Layer class for operations related to fare of trains
    /// </summary>
  public  class TrainFareDetails_DAL
    {
        SqlConnection conRailwayReservation;
        public TrainFareDetails_DAL()
        {
            conRailwayReservation = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
            
        }

        /// <summary>
        /// Metho to add fare per person per kilometer
        /// </summary>
        /// <param name="trainId"></param>
        /// <param name="classId"></param>
        /// <param name="totalSeats"></param>
        /// <param name="farePerKilometer"></param>
        /// <returns></returns>
        public int AddTrainFare(int trainId,int classId,int totalSeats,decimal farePerKilometer )
        {
            int returnValue = 0;
            try
            {
                //Command to insert train fare 
                SqlCommand cmdInsertFare = new SqlCommand("INSERT INTO tbl_ClasswiseSeats VALUES (@TrainId,@ClassId,@NumberofSeats,@FarePerPerson)", conRailwayReservation);
                cmdInsertFare.Parameters.AddWithValue("@TrainId", trainId);
                cmdInsertFare.Parameters.AddWithValue("@ClassId", classId);
                cmdInsertFare.Parameters.AddWithValue("@NumberofSeats", totalSeats);
                cmdInsertFare.Parameters.AddWithValue("@FarePerPerson", farePerKilometer);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                returnValue = cmdInsertFare.ExecuteNonQuery();
             
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
        /// Method to update the table tbl_ClasswiseSeats
        /// </summary>
        /// <param name="trainId"></param>
        /// <param name="classId"></param>
        /// <param name="totalSeats"></param>
        /// <param name="FareperPerson"></param>
        /// <returns></returns>
        public int UpdateTrainFare(int trainId,int classId,int totalSeats,decimal farePerPerson)
        {
            int returnValue = 0;
            try
            {
                //Command to update the table tbl_ClasswiseSeats
                SqlCommand cmd = new SqlCommand(" UPDATE tbl_ClasswiseSeats SET NumberofSeats=@NumberofSeats,FarePerPerson=@FarePerPerson WHERE TrainId=@TrainId and ClassId=@ClassId", conRailwayReservation);
                cmd.Parameters.AddWithValue("@NumberofSeats", totalSeats);
                cmd.Parameters.AddWithValue("@FarePerPerson",farePerPerson);
                cmd.Parameters.AddWithValue("@TrainId", trainId);
                cmd.Parameters.AddWithValue("@ClassId", classId);
                

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
        /// Method to delete the table tbl_ClasswiseSeats
        /// </summary>
        /// <param name="trainId"></param>
        /// <param name="classId"></param>
        /// <returns></returns>
        public int DeleteTrainFare(int trainId,int classId)
        {
            int returnValue = 0;
            try
            {
                //Command to delete the table tbl_ClasswiseSeats
                SqlCommand cmd = new SqlCommand("DELETE FROM tbl_ClasswiseSeats WHERE TrainId=@TrainId AND ClassId=@ClassId", conRailwayReservation);
                cmd.Parameters.AddWithValue("@TrainId", trainId);
                cmd.Parameters.AddWithValue("@ClassId", classId);

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
        /// Method to fetch the class details
        /// </summary>
        /// <returns></returns>
        public DataTable GetClassDetails(int trainID)
        {
            DataTable dtClassDetails=new DataTable();
            try
            {
                //Method to fetch the class details
                SqlCommand cmdGetClassDetails = new SqlCommand("SELECT cservice.ClassName,cseats.NumberOfSeats,cseats.FarePerPerson FROM tbl_ClasswiseSeats cseats, tbl_ClassOfService cservice where cseats.ClassId=cservice.ClassId and TrainId="+trainID, conRailwayReservation);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                dtClassDetails.Load(cmdGetClassDetails.ExecuteReader());

            }
            catch (SqlException)
            {

                dtClassDetails = null;
            }

            finally
            {
                conRailwayReservation.Close();
            }

            return dtClassDetails;
        }

    }
}
