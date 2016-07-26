using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    /// <summary>
    /// Data Access Layer class for operations related to User roles
    /// </summary>
   public class Role
    {
        SqlConnection conRailwayReservation;
        public Role()
        {           
            conRailwayReservation = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Con"].ConnectionString);
            
        }

        /// <summary>
        /// Method to insert a role
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public int AddRole(string roleName)
        {
            int returnValue = 0;
            try
            {
                //Command to insert new roles
                SqlCommand cmdInsertRole = new SqlCommand("INSERT INTO tbl_UserRole VALUES(@rolename)", conRailwayReservation);
                cmdInsertRole.Parameters.AddWithValue("@rolename", roleName);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                returnValue = cmdInsertRole.ExecuteNonQuery();
                

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
        /// Method to update a role
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int UpdateRole(string roleName,int roleId)
        {
            int returnValue = 0;
            try
            {
                //Method to update the role
                SqlCommand cmdUpdateRole = new SqlCommand(" UPDATE tbl_UserRole SET RoleName=@RoleName WHERE RoleId=@RoleId", conRailwayReservation);
                cmdUpdateRole.Parameters.AddWithValue("@RoleName", roleName);
                cmdUpdateRole.Parameters.AddWithValue("@RoleId", roleId);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                returnValue = cmdUpdateRole.ExecuteNonQuery();
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
        /// Method to delete a role
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int DeleteRole(int roleId)
        {
            int returnValue = 0;
            try
            {
                SqlCommand cmdDeleteRole = new SqlCommand("DELETE FROM tbl_UserRole WHERE RoleId=@RoleId", conRailwayReservation);
                cmdDeleteRole.Parameters.AddWithValue("@RoleId", roleId);
                conRailwayReservation.Open();
                returnValue = cmdDeleteRole.ExecuteNonQuery();
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
        /// Method to fetch the roles
        /// </summary>
        /// <returns></returns>
        public DataTable GetRoles()
        {
            DataTable dtRoles=new DataTable();
            try
            {
                //Command to fetch the roles
                SqlCommand cmdGetRoles = new SqlCommand("SELECT * FROM tbl_UserRole", conRailwayReservation);

                //Open the connection and execute the command
                conRailwayReservation.Open();
                dtRoles.Load(cmdGetRoles.ExecuteReader());

            }
            catch (SqlException)
            {

                dtRoles = null;
            }

            finally
            {
                conRailwayReservation.Close();
            }

            return dtRoles;
        }

    }
}
