using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    /// <summary>
    /// Data Access Layer class for operations related to different classes of trains 
    /// </summary>
 public class ClassTypes_DAL
    {
         SqlConnection conRailwayReservation;
         public ClassTypes_DAL()
        {
            conRailwayReservation = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
            
        }

        /// <summary>
        /// Method to add a new class
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public int AddClass(string className)
        {
            int returnValue = 0;
            try
            {
                //Command object for inserting data into tbl_ClassofService
                SqlCommand cmdInsertClass = new SqlCommand("INSERT INTO tbl_ClassofService VALUES(@Classname)", conRailwayReservation);
                cmdInsertClass.Parameters.AddWithValue("@Classname", className);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                returnValue = cmdInsertClass.ExecuteNonQuery();
               

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
        /// Method to edit the class name of a class
        /// </summary>
        /// <param name="Classname"></param>
        /// <param name="Classid"></param>
        /// <returns></returns>
        public int UpdateClass(string className,int classId)
        {
            int returnValue = 0;
            try
            {
                //Command object for updating data in tbl_ClassofService
                SqlCommand cmdUpdateClass = new SqlCommand(" UPDATE tbl_ClassofService SET ClassName=@Classname WHERE ClassId=@Classid", conRailwayReservation);
                cmdUpdateClass.Parameters.AddWithValue("@Classname", className);
                cmdUpdateClass.Parameters.AddWithValue("@Classid", classId);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                returnValue = cmdUpdateClass.ExecuteNonQuery();

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
        /// Method to delete a class
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public int DeleteClass(int classId)
        {
            int returnValue = 0;
            try
            {

                //Command object for deleting a class
                SqlCommand cmdDeleteClass = new SqlCommand("DELETE FROM tbl_ClassofService WHERE ClassId=@Classid", conRailwayReservation);
                cmdDeleteClass.Parameters.AddWithValue("@Classid", classId);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                returnValue = cmdDeleteClass.ExecuteNonQuery();
                

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
        /// Method to fetch the classes
        /// </summary>
        /// <returns></returns>
        public DataTable GetClass()
        {
            DataTable dtClass=new DataTable();
            try
            {
                //Command object for fetching class details
                SqlCommand cmdGetClass = new SqlCommand("SELECT * FROM tbl_ClassofService", conRailwayReservation);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                dtClass.Load(cmdGetClass.ExecuteReader());
              
            }
            catch (SqlException)
            {

                dtClass = null;
            }

            finally
            {
                conRailwayReservation.Close();
            }

            return dtClass;
        }


        /// <summary>
        /// Method to fetch the ClassName from ClassId
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string GetClass(int classId)
        {
            string className = "";
            try
            {
                //Command to fetch the class names
                SqlCommand cmdGetClass = new SqlCommand("SELECT ClassName FROM tbl_ClassofService WHERE ClassId="+classId, conRailwayReservation);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                className = cmdGetClass.ExecuteScalar().ToString();
               
            }

            catch (SqlException)
            {
                className = "Error";
            }

            finally
            {
                conRailwayReservation.Close();
            }

            return className;
        }
    }
}
