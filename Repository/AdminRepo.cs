using LoginAndRegistration.Models;
using System;
using System.Data.SqlClient;
using System.Data;


namespace LoginAndRegistration.Repository
{
    public class AdminRepo : IAdminRepo<Admin>
    {    
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static void getcon()
        {

            con = new SqlConnection("Data Source=LAPTOP-6MJE97ED\\SQLSERVER2019G3;Initial Catalog=learningportaldb;Integrated Security=true");
            con.Open();
        }
        public bool deleteadmin(int Admin_id)
        {

            AdminRepo.getcon();
            cmd = new SqlCommand("deleteadmin");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Admin_id", Admin_id);
            if (cmd.ExecuteNonQuery() == 1)
                return true;
            else
                return false;

        }


        public void insertAdmin(Admin A)
        {
            AdminRepo.getcon();
            cmd = new SqlCommand("Insertadmin");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Admin_id", A.Admin_id);
            cmd.Parameters.AddWithValue("@Adminname", A.Admin_name);
            cmd.Parameters.AddWithValue("@Adminage", A.Admin_age);
            cmd.Parameters.AddWithValue("@Email", A.Admin_email);
            cmd.Parameters.AddWithValue("@Adminpass", A.Admin_password);
            cmd.Parameters.AddWithValue("@Adminphoneno", A.Admin_phoneno);
            cmd.Parameters.AddWithValue("@Adminimage", A.Admin_image);
            cmd.Parameters.AddWithValue("@role_id", A.role_id);
            cmd.ExecuteNonQuery();

        }

        public List<Admin> SelectAdminBy_id(int Admin_id)
        {
            List<Admin> adm = new List<Admin>();
            AdminRepo.getcon();
            cmd = new SqlCommand("SelectAdmin_by_id");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Admin_id", Admin_id);
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                Admin a = new Admin();
                a.Admin_id = Convert.ToInt32(dr[0]);
                a.Admin_name = dr[1].ToString();
                a.Admin_age = Convert.ToInt32(dr[2]);
                a.Admin_email = dr[3].ToString();
                a.Admin_password = dr[4].ToString();
                a.Admin_phoneno = dr[5].ToString();
                a.Admin_image = dr[6].ToString();
                a.role_id = Convert.ToInt32(dr[7]);
                adm.Add(a);
            }
            return adm;
        }

        public void updateadmin(Admin A,int Admin_id)
        {
            AdminRepo.getcon();
            cmd = new SqlCommand("updateadmin");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Admin_id", A.Admin_id);
            cmd.Parameters.AddWithValue("@Adminname", A.Admin_name);
            cmd.Parameters.AddWithValue("@Adminage", A.Admin_age);
            cmd.Parameters.AddWithValue("@Email", A.Admin_email);
            cmd.Parameters.AddWithValue("@Adminpass", A.Admin_password);
            cmd.Parameters.AddWithValue("@Adminphoneno", A.Admin_phoneno);
            cmd.Parameters.AddWithValue("@Adminimage", A.Admin_image);
            cmd.Parameters.AddWithValue("@role_id", A.role_id);
            cmd.ExecuteNonQuery();
        }


        public  List<Admin> GetAllAdmins()
        {
            List<Admin> ad = new List<Admin>();
            AdminRepo.getcon();
            cmd = new SqlCommand("SelectallAdmin");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                Admin a = new Admin();
                a.Admin_id = Convert.ToInt32(dr[0]);
                a.Admin_name = dr[1].ToString();
                a.Admin_age = Convert.ToInt32(dr[2]);
                a.Admin_email = dr[3].ToString();
                a.Admin_password = dr[4].ToString();
                a.Admin_phoneno = dr[5].ToString();
                a.Admin_image = dr[6].ToString();
                a.role_id = Convert.ToInt32(dr[7]);
                ad.Add(a);
            }
            return ad;

        }
    }
}

