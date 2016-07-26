using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for PaymentService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class PaymentService : System.Web.Services.WebService {

  
    public PaymentService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public int InsertCreditAmount(string creditcardNumber,double crditAmount,ref SqlTransaction tran,ref SqlConnection conn) {

        int result = 0;
        //SqlConnection con = null;
        try
        {
            //string conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            //con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("usp_InsertCreditAmount", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //con.Open();
           // tran = conn.BeginTransaction(); 
            cmd.Transaction = tran;
            cmd.Parameters.AddWithValue("@CreditCardNumber", creditcardNumber);
            cmd.Parameters.AddWithValue("@CreditAmount", crditAmount);
            
            SqlParameter returnParam = new SqlParameter();
            returnParam.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add(returnParam);

           // con.Open();
            cmd.ExecuteNonQuery();

            result = (int)returnParam.Value;
        }
        catch (SqlException ex)
        {
            //tran.Rollback();
            result = -1;
        }
        finally
        {
            //con.Close();
        }
        return result;
    }
    
}
