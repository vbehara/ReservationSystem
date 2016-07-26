using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
 
    /// <summary>
    /// Data Access Layer class for operations related to train
    /// </summary>
    public class Train_DAL
    {
        SqlConnection conRailwayReservation;
        public Train_DAL()
        {

            conRailwayReservation = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
            
        }
     

        /// <summary>
        /// Method to add a new train
        /// </summary>
        /// <param name="trainName"></param>
        /// <param name="trainType"></param>
        /// <param name="sunday"></param>
        /// <param name="monday"></param>
        /// <param name="tuesday"></param>
        /// <param name="wednesday"></param>
        /// <param name="thursday"></param>
        /// <param name="friday"></param>
        /// <param name="saturday"></param>
        /// <returns></returns>
        public int AddTrain(string trainName, string trainType, bool sunday, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday)
        {
            int returnValue = 0;
            try
            {
                //Command to add a new train
                SqlCommand cmdAddTrain = new SqlCommand("INSERT INTO tbl_train VALUES(@trainname,@traintype,@sunday,@monday,@tuesday,@wednesday,@thursday,@friday,@saturday");
                cmdAddTrain.Parameters.AddWithValue("@trainname", trainName);
                cmdAddTrain.Parameters.AddWithValue("@traintype", trainType);
                cmdAddTrain.Parameters.AddWithValue("@sunday", sunday);
                cmdAddTrain.Parameters.AddWithValue("@monday", monday);
                cmdAddTrain.Parameters.AddWithValue("@tuesday", tuesday);
                cmdAddTrain.Parameters.AddWithValue("@wednesday", wednesday);
                cmdAddTrain.Parameters.AddWithValue("@thursday", thursday);
                cmdAddTrain.Parameters.AddWithValue("@friday", friday);
                cmdAddTrain.Parameters.AddWithValue("@saturday", saturday);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                returnValue = cmdAddTrain.ExecuteNonQuery();


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
        ///  Method to update a train
        /// </summary>
        /// <param name="trainName"></param>
        /// <param name="trainType"></param>
        /// <param name="sunday"></param>
        /// <param name="monday"></param>
        /// <param name="tuesday"></param>
        /// <param name="wednesday"></param>
        /// <param name="thursday"></param>
        /// <param name="friday"></param>
        /// <param name="saturday"></param>
        /// <returns></returns>
        public int UpdateTrain(string trainName, string trainType, bool sunday, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday)
        {
            int returnValue = 0;
            try
            {
                //Command to update the train details
                SqlCommand cmd = new SqlCommand("UPDATE tbl_Train SET TrainName =@TrainName,TrainType =@TrainType, Sunday =@Sunday,Monday = @Monday,Tuesday=@Tuesday,Wednesday=@Wednesday,Thursday =@Thursday,Friday =@Friday, Saturday=@Saturday WHERE TrainId=@TrainId", conRailwayReservation);
                cmd.Parameters.AddWithValue("@TrainName", trainName);
                cmd.Parameters.AddWithValue("@TrainType", trainType);
                cmd.Parameters.AddWithValue("@Sunday", sunday);
                cmd.Parameters.AddWithValue("@monday", monday);
                cmd.Parameters.AddWithValue("@tuesday", tuesday);
                cmd.Parameters.AddWithValue("@wednesday", wednesday);
                cmd.Parameters.AddWithValue("@thursday", thursday);
                cmd.Parameters.AddWithValue("@friday", friday);
                cmd.Parameters.AddWithValue("@saturday", saturday);
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
        /// Method to delete a train
        /// </summary>
        /// <param name="trainId"></param>
        /// <returns></returns>
        public int DeleteTrain(int trainId)
        {
            int returnValue = 0;
            try
            {
                //Command to delete a train
                SqlCommand cmdDeleteTrain = new SqlCommand("DELETE FROM tbl_train WHERE TrainId=@TrainId", conRailwayReservation);
                cmdDeleteTrain.Parameters.AddWithValue("@TrainId", trainId);
                conRailwayReservation.Open();
                returnValue = cmdDeleteTrain.ExecuteNonQuery();
          

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
        /// Method to fetch trains
        /// </summary>
        /// <returns></returns>
        public DataTable GetTrains()
        {
            DataTable dtTrains = new DataTable();
            try
            {
                //Command to fetch trains
                SqlCommand cmdGetTrains = new SqlCommand("SELECT * FROM tbl_Train", conRailwayReservation);

                //Open the connection and close the command
                conRailwayReservation.Open();
                dtTrains.Load(cmdGetTrains.ExecuteReader());
                
            }
            catch (SqlException)
            {

                dtTrains = null;
            }

            finally
            {
                conRailwayReservation.Close();
            }

            return dtTrains;
        }


        /// <summary>
        /// Method to fetch the schedule of a given train
        /// </summary>
        /// <param name="trainId"></param>
        /// <returns></returns>
        public DataRow  GetTrainSchedule(int trainId)
        {
            DataRow  datarow=null;
            try
            {
                //Command to execute the function to fetch train schedule for a given train
                SqlCommand cmdGetTrainSchedule = new SqlCommand("SELECT * FROM ufn_FetchSchedulebasedonTrainId(@TrainId)", conRailwayReservation);
                cmdGetTrainSchedule.Parameters.AddWithValue("@TrainId", trainId);                
                SqlDataAdapter daTrainSchedule=new SqlDataAdapter(cmdGetTrainSchedule);
                DataTable dtTrainSchedule=new DataTable();
                daTrainSchedule.Fill(dtTrainSchedule);
                if (dtTrainSchedule.Rows.Count==1)
                {
                    datarow = dtTrainSchedule.Rows[0];
                    
                }
                

            }
            catch (SqlException)
            {

                datarow = null;
            }

            return datarow;
        }

        //public DataTable GetTrain(string source,string destination)
        //{
        //    DataTable dt = null;
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("SELECT * FROM ufn_FetchSchedulebasedonSourceDestination(@Source,@Destination)", conRailwayReservation);
        //        cmd.Parameters.AddWithValue("@Source", source);
        //        cmd.Parameters.AddWithValue("@Destination", destination);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //         dt = new DataTable();
        //        da.Fill(dt);
        //        if (dt.Rows.Count>0)
        //        {
        //            return dt;

        //        }


        //    }
        //    catch (SqlException)
        //    {

        //        dt = null;
        //    }

        //    return dt;
        //}


        /// <summary>
        /// Method to fetch class details for a given train, class, date of journey, from station and to station
        /// </summary>
        /// <param name="trainId"></param>
        /// <param name="classId"></param>
        /// <param name="dateOfJourney"></param>
        /// <param name="fromStation"></param>
        /// <param name="toStation"></param>
        /// <returns></returns>
        public DataRow GetClassDetails(int trainId,int classId,DateTime dateOfJourney,string fromStation, string toStation)
        {
            DataRow datarow = null;
            try
            {
                //Command to execute the function to fetch the class details
                SqlCommand cmdGetClassDetails = new SqlCommand("SELECT * from ufn_FetchClassDetails(@TrainId,@ClassId,@DateofJourney,@FromStation,@ToStation)", conRailwayReservation);
                cmdGetClassDetails.Parameters.AddWithValue("@TrainId", trainId);
                cmdGetClassDetails.Parameters.AddWithValue("@ClassId", classId);
                cmdGetClassDetails.Parameters.AddWithValue("@DateofJourney", dateOfJourney);
                cmdGetClassDetails.Parameters.AddWithValue("@FromStation", fromStation);
                cmdGetClassDetails.Parameters.AddWithValue("@ToStation", toStation);
                SqlDataAdapter daClassDetails = new SqlDataAdapter(cmdGetClassDetails);
                DataTable dtClassDetails = new DataTable();
                daClassDetails.Fill(dtClassDetails);
                if (dtClassDetails.Rows.Count == 1)
                {
                    datarow = dtClassDetails.Rows[0];

                }


            }
            catch (SqlException)
            {

                datarow = null;
            }

            return datarow;
        }


        /// <summary>
        /// Method to fetch the train id from a given train name
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        public int FetchTrainId(string trainName)
        {

            int trainId=-1;
            try
            {
                //Command to fetch the train id from the train name
                SqlCommand cmdFetchTrainId = new SqlCommand("SELECT TrainId FROM tbl_Train WHERE TrainName=@TrainName", conRailwayReservation);
                cmdFetchTrainId.Parameters.AddWithValue("@TrainName", trainName);
                conRailwayReservation.Open();
                trainId = Convert.ToInt32(cmdFetchTrainId.ExecuteScalar());
                
            }

            catch (SqlException)
            {
                //In case of any exception, set the value of train id to -1
                trainId = -1;
            }

            finally
            {
                conRailwayReservation.Close();
            }

            return trainId;

        }


        /// <summary>
        /// Method to fetch the available classes for a train
        /// </summary>
        /// <param name="trainId"></param>
        /// <returns></returns>
        public DataTable GetClassBasedOnTrain(int trainId)
        {
            DataTable dtClass = new DataTable();
            try
            {
                //Command to execute the function for fetching the available classes for a given train  
                SqlCommand cmdGetClass = new SqlCommand("SELECT * FROM ufn_FetchAvailableClassesforaTrain(@TrainId)", conRailwayReservation);
                cmdGetClass.Parameters.Add("@TrainId",trainId);
                SqlDataAdapter daTemp = new SqlDataAdapter(cmdGetClass);
                daTemp.Fill(dtClass);
            }
            catch
            {
                dtClass = null;
            }
            return dtClass;
        }

    }


}
