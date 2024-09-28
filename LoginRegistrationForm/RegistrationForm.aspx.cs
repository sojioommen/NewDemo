using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using System.Drawing;
using System.Net.Mail;

namespace LoginRegistrationForm
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-07B2LFN\\SQLEXPRESS;Initial Catalog=loginreg;Integrated Security=True;TrustServerCertificate=True");
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button5_Click(object sender, EventArgs e)
        {

           string email = Request.Form["email"];
            string password = Request.Form["password"];
            string cpassword = Request.Form["cpassword"];

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(cpassword))
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
                        string selectEmail = "SELECT * FROM users WHERE email=@email";
                        using (SqlCommand cmd = new SqlCommand(selectEmail, con))
                        {
                            cmd.Parameters.AddWithValue("@email", email);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable ta = new DataTable();
                            adapter.Fill(ta);
                            if (ta.Rows.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email you have entered has been taken already')", true);
                            }
                            else if (password != cpassword)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password doesnot match')", true);
                            }

                            else if (password.Length < 8)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invaild password ,8 character needed')", true);
                            }

                            else
                            {
                                DateTime today = DateTime.Now;
                                string insertData = "INSERT INTO users(email,password,date)VALUES(@email,@password,@date)";
                                using (SqlCommand insertD = new SqlCommand(insertData, con))
                                {
                                    insertD.Parameters.AddWithValue("@email", email);
                                    insertD.Parameters.AddWithValue("@password", password);
                                    insertD.Parameters.AddWithValue("@date", today);
                                    insertD.ExecuteNonQuery();
                                   
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Registered Successfully')", true);
                                    sendEmail();

                                    Response.Redirect("/LoginForm.aspx");

                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        lblError.Text = ex.Message;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Failed Connection')", true);
                    }

                     finally
                    {
                        con.Close();
                    }

                     }

                  }

              }

        private void sendEmail()
        { string smtpUserName;
            string smtpPassword;
            MailMessage mail = new MailMessage();
            SmtpClient smpt_Client = new SmtpClient(System.Configuration.ConfigurationSettings.AppSettings["smtpClient"]);
            smtpUserName = System.Configuration.ConfigurationSettings.AppSettings["smtpUserName"];
            smtpPassword = System.Configuration.ConfigurationSettings.AppSettings["smtpPassword"];
            mail.From = new MailAddress(smtpUserName);
            mail.To.Add(email.Text.Trim());
            mail.Subject = "Email Configuration project";
            mail.Body = ("Name:" + name .Text.Trim() + Environment.NewLine + "Welcome,Your registration has been successfully completed");
            smpt_Client.Port = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["smtpPort"]);
            smpt_Client.Credentials=new System.Net.NetworkCredential(smtpUserName, smtpPassword);
            smpt_Client.EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationSettings.AppSettings["enableSSL"]);
       smpt_Client.Send(mail);
        
        }

    }
}