using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LoginRegistrationForm
{
    public partial class LoginForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-07B2LFN\\SQLEXPRESS;Initial Catalog=loginreg;Integrated Security=True;TrustServerCertificate=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string email = Request.Form["email"];
            string password = Request.Form["password"];
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('All field are required to filled')", true);
            }
            else
            {
                if (con.State == ConnectionState.Closed)
                {
                    try
                    {
                        con.Open();
                        string selectData = "SELECT  * FROM users WHERE email=@email AND password= @password";

                        using (SqlCommand cmd = new SqlCommand(selectData,con)) {
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@password", password);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows.Count >= 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Login successfully')", true);
                                Session["email"] = email;
                                Response.Redirect("/HomePage.aspx");
                            
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Incorrect username')", true);
                            }

                        }
                    }

                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('connection failed')", true);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}