using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace project02mvc.Controllers
{
    public class EmployeeController : Controller
    {
        //connection in data base
        //SqlConnection con = new SqlConnection("data source=;initial catalog=; integrated security=true");
        SqlConnection con = new SqlConnection("data source=VASHU\\SQLSERVERVISHAL;initial catalog=jquery01; integrated security=true");
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public void EmployeeInsert(string A,string B,long C,string D ,int E)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("emp_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@E_Name", A);
            cmd.Parameters.AddWithValue("@E_City", B);
            cmd.Parameters.AddWithValue("@E_Mobile", C);
            cmd.Parameters.AddWithValue("@E_mail", D);
            cmd.Parameters.AddWithValue("@age", E);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public JsonResult Employeeget()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);

            return Json(data,JsonRequestBehavior.AllowGet);



        }
        public JsonResult EmployeeEdit(int F)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Employee_Edit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empId", F);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);

            return Json(data, JsonRequestBehavior.AllowGet);


        }
        public void EmployeeDelete(int F)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_Delete", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empId ", F);
            cmd.ExecuteNonQuery();
            con.Close();
        }



        public void EmployeeUpdate(string A, string B, long C,  int E, string D, int F)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employee_update", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empId", F);
            cmd.Parameters.AddWithValue("@E_Name", A);
            cmd.Parameters.AddWithValue("@E_City", B);
            cmd.Parameters.AddWithValue("@E_Mobile", C);
            cmd.Parameters.AddWithValue("@E_mail", D);
            cmd.Parameters.AddWithValue("@age", E);


            cmd.ExecuteNonQuery();
            con.Close();

        }

      
    }
}