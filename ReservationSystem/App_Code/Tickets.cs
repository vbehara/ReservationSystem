using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using RailwayDataAccessLayer;

namespace DataAccessLayer
{
    /// <summary>
    /// Data Access Layer class for operations related to ticket booking and cancellation
    /// </summary>
   public class Tickets_DAL
    {
        SqlConnection conRailwayReservation;
        SqlTransaction tran;
       
        public Tickets_DAL()
        {
            conRailwayReservation = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        }

        /// <summary>
        /// Method to book a ticket
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="dateOfJourney"></param>
        /// <param name="trainId"></param>
        /// <param name="classId"></param>
        /// <param name="noOfTickets"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="pnrNumber"></param>
        /// <param name="status"></param>
        /// <param name="insertSeat"></param>
        /// <returns></returns>
        public int BookTicket(string userId, DateTime dateOfJourney, int trainId, int classId, int noOfTickets, string source, string destination, out int pnrNumber, out string status, params InsertSeatDetails[] insertSeat)
        {
            int returnValue = 0;
            SqlParameter prmPNRNumber = new SqlParameter();
            SqlParameter prmStatus = new SqlParameter();
            SqlParameter prmRet = new SqlParameter();
           // conRailwayReservation.Open();

           // tran = conRailwayReservation.BeginTransaction();
            try
            {
                //Command to execute the stored procedure usp_BookTicket
                SqlCommand cmdBookTicket = new SqlCommand("usp_BookTicket", conRailwayReservation);
                cmdBookTicket.CommandType = CommandType.StoredProcedure;
                cmdBookTicket.Transaction = tran;

                cmdBookTicket.Parameters.AddWithValue("@UserId", userId);
                cmdBookTicket.Parameters.AddWithValue("@DateofJourney ", dateOfJourney);
                cmdBookTicket.Parameters.AddWithValue("@TrainId", trainId);
                cmdBookTicket.Parameters.AddWithValue("@CLassId", classId);
                cmdBookTicket.Parameters.AddWithValue("@NumberofSeats", noOfTickets);
                cmdBookTicket.Parameters.AddWithValue("@FromStation", source);
                cmdBookTicket.Parameters.AddWithValue("@ToStation", destination);


                prmPNRNumber.ParameterName = "@PNRNumber";
                prmPNRNumber.SqlDbType = System.Data.SqlDbType.Int;
                prmPNRNumber.Direction = System.Data.ParameterDirection.Output;


                prmStatus.ParameterName = "@Status";
                prmStatus.SqlDbType = System.Data.SqlDbType.VarChar;
                prmStatus.Size = 20;
                prmStatus.Direction = System.Data.ParameterDirection.Output;


                prmRet.ParameterName = "@RetVal";
                prmRet.SqlDbType = System.Data.SqlDbType.Int;
                prmRet.Direction = System.Data.ParameterDirection.ReturnValue;

                cmdBookTicket.Parameters.Add(prmPNRNumber);
                cmdBookTicket.Parameters.Add(prmStatus);
                cmdBookTicket.Parameters.Add(prmRet);

                //Execute the command
                cmdBookTicket.ExecuteNonQuery();


                int[] ret = new int[noOfTickets];
                for (int i = 0; i < noOfTickets; i++)
                {
                    
                    ret[i] = InsertSeatInfo(Convert.ToInt32(prmPNRNumber.Value), insertSeat[i].PassengerName, insertSeat[i].Age, insertSeat[i].Gender);
                    if (ret[i] == 1 || ret[i] == 2)
                    {
                        if (i == noOfTickets - 1)
                        {
                            //tran.Commit();
                        }
                    }
                    else
                    {
                        tran.Rollback();
                    }

                }
               


            }
            catch (SqlException)
            {
                //In case of any exception, set value of return value to -2
                returnValue = -2;
                tran.Rollback();
            }
            finally
            {
                //conRailwayReservation.Close();
            }


            pnrNumber = Convert.ToInt32(prmPNRNumber.Value);
            status = prmStatus.Value.ToString();
            returnValue = Convert.ToInt32(prmRet.Value);
            return returnValue;
            
            
        }


        /// <summary>
        /// Method to insert the seat details
        /// </summary>
        /// <param name="pnrNumber"></param>
        /// <param name="passengerName"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public int InsertSeatInfo(int pnrNumber,string passengerName,int age,char gender)
        {
           
            int returnValue = 0;
            try
            {
                //Command to execute the stored procedure usp_InsertSeatDetails
                SqlCommand cmdInsertSeatDetails = new SqlCommand("dbo.usp_InsertSeatDetails", conRailwayReservation);
                cmdInsertSeatDetails.CommandType = CommandType.StoredProcedure;
                cmdInsertSeatDetails.Transaction = tran;
                cmdInsertSeatDetails.Parameters.AddWithValue("@PNRNumber", pnrNumber);
                cmdInsertSeatDetails.Parameters.AddWithValue("@PassengerName", passengerName);
                cmdInsertSeatDetails.Parameters.AddWithValue("@Age", age);
                cmdInsertSeatDetails.Parameters.AddWithValue("@Gender", gender);

                SqlParameter prmRet = new SqlParameter();
                prmRet.ParameterName = "@ret";
                prmRet.SqlDbType = System.Data.SqlDbType.Int;
                prmRet.Direction = ParameterDirection.ReturnValue;

                cmdInsertSeatDetails.Parameters.Add(prmRet);
               // conRailwayReservation.Open();
                cmdInsertSeatDetails.ExecuteNonQuery();
                returnValue = Convert.ToInt32(prmRet.Value);
                
            }
            catch (SqlException)
            {
                //In case of any exception, set value of return value to -3
                return -3;
                    
            }

            finally
            {
                //conRailwayReservation.Close();
            }

            return returnValue;
        }


        /// <summary>
        /// Method to cancel a ticket
        /// </summary>
        /// <param name="pnrNumber"></param>
        /// <param name="status"></param>
        /// <param name="refundAmount"></param>
        /// <returns></returns>
        public int CancelTicket(int pnrNumber,out decimal refundAmount)
        {
            SqlParameter prmRefundAmount = new SqlParameter();
            SqlParameter prmReturn = new SqlParameter();
            int returnValue = 0;
            try
            {

                //Command to execute the stored procedure usp_CancelTicket
                SqlCommand cmdCancelTicket = new SqlCommand("usp_CancelTicket", conRailwayReservation);
                cmdCancelTicket.CommandType = CommandType.StoredProcedure;
                cmdCancelTicket.Parameters.AddWithValue("@PNRNumber", pnrNumber);


                prmRefundAmount.ParameterName = "@RefundAmount";
                prmRefundAmount.SqlDbType = System.Data.SqlDbType.Money;
                prmRefundAmount.Direction = System.Data.ParameterDirection.Output;
                cmdCancelTicket.Parameters.Add(prmRefundAmount);

                prmReturn.SqlDbType = System.Data.SqlDbType.Int;
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                cmdCancelTicket.Parameters.Add(prmReturn);
                
                conRailwayReservation.Open();
                cmdCancelTicket.ExecuteNonQuery();
                returnValue =Convert.ToInt32( prmReturn.Value);
            }
            catch (SqlException)
            {
                //In case of any exception, set value of return value to -2
                returnValue=-5;
            }


            finally
            {
                conRailwayReservation.Close();
            }

            
            refundAmount = Convert.ToDecimal(prmRefundAmount.Value) ;
            return returnValue;
        }


        /// <summary>
        /// Method to fetch the PNR status 
        /// </summary>
        /// <param name="PNRNumnber"></param>
        /// <returns></returns>
        public DataTable FetchPNRStatus(int PNRNumnber)
        {

            SqlDataAdapter daPNRStatus = new SqlDataAdapter();
            DataTable dtPNRStatus = new DataTable();
            try
            {
                //Command to execute the function ufn_FetchPNRStatus
                SqlCommand cmdFetchPNRStatus = new SqlCommand("SELECT * FROM ufn_FetchPNRStatus(@PNRNumber)", conRailwayReservation);
                cmdFetchPNRStatus.Parameters.AddWithValue("@PNRNumber", PNRNumnber);
                daPNRStatus.SelectCommand = cmdFetchPNRStatus;
                daPNRStatus.Fill(dtPNRStatus);
            }

            catch
            {
                dtPNRStatus = null;
            }

            finally
            {
            }

            return dtPNRStatus;

        }
       /// <summary>
       /// Method to insert payment and transaction 
       /// </summary>
       /// <param name="creditcardNumber"></param>
       /// <param name="ticketInfo"></param>
       /// <param name="userID"></param>
       /// <param name="SeatDetails"></param>
       /// <returns></returns>
        public int PayForTickets(string creditcardNumber, RailwayReservation.Ticket ticketInfo, string userID, RailwayDataAccessLayer.InsertSeatDetails[] SeatDetails,out int PNRNumber,out string status)
        {
            int result;
            int pnrNumber=0;
            string Status = null;
            PaymentService payementservice = new PaymentService();
            conRailwayReservation.Open();
            tran = conRailwayReservation.BeginTransaction(); 
            try
            {

                result = payementservice.InsertCreditAmount(creditcardNumber, ticketInfo.TotalFare, ref tran, ref conRailwayReservation);
                if (result == 1)
                {


                    // declare pnrnum and status
                    
                    
                    result = BookTicket(userID, Convert.ToDateTime(ticketInfo.DateOfJourney), ticketInfo.TrainID, ticketInfo.ClassId, ticketInfo.NumberOfSeats, ticketInfo.FromStation, ticketInfo.ToStation, out pnrNumber, out Status, SeatDetails);
                    PNRNumber = pnrNumber;
                    status = Status;
                    tran.Commit();


                }
                else
                {
                    tran.Rollback();

                }
                
            }
            catch (Exception e)
            {
                tran.Rollback();
                result = -2;
            }
            finally
            {
                
                conRailwayReservation.Close();
            }
            PNRNumber = pnrNumber;
            status = Status;
            return result;
        }

        public DataTable getBookingHistory(string userID,string status)
        {
            DataTable dtBookedTickets= new DataTable();
            try
            {
                //Command to fetch tickets history
                SqlCommand cmdGetTickets = new SqlCommand("SELECT * FROM tbl_TicketBooking where UserId='"+userID+"' and Status='"+status+"'", conRailwayReservation);

                //Open the connection and close the command
                conRailwayReservation.Open();
                dtBookedTickets.Load(cmdGetTickets.ExecuteReader());

            }
            catch (SqlException)
            {

                dtBookedTickets = null;
            }

            finally
            {
                conRailwayReservation.Close();
            }

            return dtBookedTickets;
        }
    }
}
