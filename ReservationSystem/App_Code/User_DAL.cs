using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RailwayReservation;

namespace DataAccessLayer
{
   public class User_DAL
    {
         SqlConnection conRailwayReservation;
        public User_DAL()
        {
            conRailwayReservation = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
            
        }
       
        /// <summary>
        /// Method to add a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(User user)
        {
            int returnValue = 0;
            try
            {
                //Command to insert a new user
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_User VALUES(@UserId,@Name,@Age,@Gender,@Password,@RoleId)", conRailwayReservation);
                cmd.Parameters.AddWithValue("@UserId", user.CustomerID);
                cmd.Parameters.AddWithValue("@Name", user.CustomerName);
                cmd.Parameters.AddWithValue("@Age", user.Age);
                cmd.Parameters.AddWithValue("@Gender", user.Gender.ToString());
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@RoleId", user.Role);
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
        /// Method to add a new user by accepting individual parameters
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="age"></param>
        /// <param name="password"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int AddUser(string  userId,string name,char gender,int age,string password,int roleId)
        {
            int returnValue = 0;
            try
            {
                //Command to insert a new user
                SqlCommand cmdAddUser = new SqlCommand("INSERT INTO tbl_user VALUES(@UserId,@Name,@Age,@Gender,@Password,@RoleId)", conRailwayReservation);
                cmdAddUser.Parameters.AddWithValue("@UserId", userId);
                cmdAddUser.Parameters.AddWithValue("@Name", name);
                cmdAddUser.Parameters.AddWithValue("@Age", age);
                cmdAddUser.Parameters.AddWithValue("@Gender", gender);
                cmdAddUser.Parameters.AddWithValue("@Password", password);
                cmdAddUser.Parameters.AddWithValue("@RoleId", roleId);
                conRailwayReservation.Open();
                returnValue = cmdAddUser.ExecuteNonQuery();
            }

            catch (SqlException)
            {
                //In case of any exception, set the value of return value to -1
                returnValue = -1;
            }

            finally
            {
                conRailwayReservation.Close();
            }

            return returnValue;
        }


        /// <summary>
        /// Command to change password
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="oldpassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public int UpdatePassword(string userId, string oldPassword, string newPassword)
        {
            int returnValue = 0;
            try
            {
                //Command to execcute the stored procedure to change the password
                SqlCommand cmdChangePassword = new SqlCommand("usp_ChangePassword", conRailwayReservation);
                cmdChangePassword.CommandType = CommandType.StoredProcedure;
                cmdChangePassword.Parameters.AddWithValue("@UserId", userId);
                cmdChangePassword.Parameters.AddWithValue("@OldPassword", oldPassword);
                cmdChangePassword.Parameters.AddWithValue("@NewPassword", newPassword);

                SqlParameter prmRet = new SqlParameter();
                prmRet.ParameterName = "@Ret";
                prmRet.SqlDbType = System.Data.SqlDbType.Int;
                prmRet.Direction = ParameterDirection.ReturnValue;
                cmdChangePassword.Parameters.Add(prmRet);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                returnValue = cmdChangePassword.ExecuteNonQuery();


            }
            catch (SqlException)
            {
                //In case of any exception, set the value of return value to -1
                returnValue = -1;
            }

            finally
            {
                conRailwayReservation.Close();

            }

            return returnValue;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int UpdateUser(string userId, string userName, int age, char gender)
        {
            int returnValue = 0;
            try
            {
                //Command to update the details of an user
                SqlCommand cmdUpdateUser = new SqlCommand("UPDATE tbl_User SET Name=@Name,Age=@Age ,Gender=@Gender WHERE UserId=@UserId", conRailwayReservation);
                cmdUpdateUser.Parameters.AddWithValue("@UserId", userId);
                cmdUpdateUser.Parameters.AddWithValue("@Name", userName);
                cmdUpdateUser.Parameters.AddWithValue("@Age", age);
                cmdUpdateUser.Parameters.AddWithValue("@Gender", gender);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                returnValue = cmdUpdateUser.ExecuteNonQuery();


            }
            catch (SqlException)
            {
                //In case of any exception, set the value of return value to -2
                returnValue = -2;
            }

            finally
            {
                conRailwayReservation.Close();
            }

            return returnValue;
        }


        /// <summary>
        /// Method to delete an user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int DeleteUser(int userId)
        {
            int returnValue = 0;
            try
            {
                //Command to delete an user
                SqlCommand cmdDeleteUser = new SqlCommand("DELETE FROM tbl_User WHERE UserId=@Userid", conRailwayReservation);
                cmdDeleteUser.Parameters.AddWithValue("@Userid", userId);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                returnValue = cmdDeleteUser.ExecuteNonQuery();


            }
            catch (SqlException)
            {
                //In case of any exception, set the return value to -1
                returnValue = -1;
            }

            finally
            {
                conRailwayReservation.Close();
            }

            return returnValue;
        }



        /// <summary>
        /// Method to fetch the details of all users
        /// </summary>
        /// <returns></returns>
        public DataTable GetUsers()
        {
            DataTable dtUsers = new DataTable();
            try
            {
                //Command to fetch the details of all users
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_User", conRailwayReservation);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                dtUsers.Load(cmd.ExecuteReader());
             

            }
            catch (SqlException)
            {

                dtUsers = null;
            }

            finally
            {
                conRailwayReservation.Close();
            }

            return dtUsers;
        }


        /// <summary>
        /// Method to validate an user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int ValidateUser(string userId, string password)
        {
            int returnValue = 0;
            DataTable dtUser=new DataTable();
            try
            {
                //Command to validate the user by executing the function ufn_FetchRole
                SqlCommand cmdValidateUser = new SqlCommand("SELECT * FROM dbo.tbl_User where UserId='"+userId+"' and Password='"+password+"'", conRailwayReservation);
                //Open the connection and execute the command
                conRailwayReservation.Open();
            dtUser.Load(cmdValidateUser.ExecuteReader());
            returnValue = dtUser.Rows.Count;

            }
            catch (SqlException)
            {
                //In case of any exception, set the value of return value to -2
                returnValue = -2;
            }


            finally
            {
                conRailwayReservation.Close();
            }

            return returnValue;
        }

    }
}
