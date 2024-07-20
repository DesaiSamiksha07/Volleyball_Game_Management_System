using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VolleyBall_Final
{
    public partial class _Default : Page
    {
        private readonly string connectionString = "Data Source=DESKTOP-QSEUCTB\\SQLEXPRESS;Initial Catalog=VolleyBall_Game_Points_Table; User ID=sa; Password=Tech@123;Encrypt=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRecords();
            }
        }

        private void LoadRecords()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand comm = new SqlCommand("SELECT * FROM VolleyBall_Game_Points_Table", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(comm))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO VolleyBall_Game_Points_Table (Team, Matches, Won, Lost, Drawn, Points, PCT) VALUES (@Team, @Matches, @Won, @Lost, @Drawn, @Points, @PCT)";
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    comm.Parameters.AddWithValue("@Team", TextBox2.Text);
                    comm.Parameters.AddWithValue("@Matches", int.Parse(TextBox5.Text));
                    comm.Parameters.AddWithValue("@Won", int.Parse(TextBox3.Text));
                    comm.Parameters.AddWithValue("@Lost", int.Parse(TextBox4.Text));
                    comm.Parameters.AddWithValue("@Drawn", int.Parse(TextBox6.Text));
                    comm.Parameters.AddWithValue("@Points", int.Parse(TextBox7.Text));
                    comm.Parameters.AddWithValue("@PCT", double.Parse(TextBox8.Text));

                    con.Open();
                    comm.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted');", true);
                    LoadRecords();
                    
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE VolleyBall_Game_Points_Table SET Team = @Team, Matches = @Matches, Won = @Won, Lost = @Lost, Drawn = @Drawn, Points = @Points, PCT = @PCT WHERE Pos_ID = @Pos_ID";
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    comm.Parameters.AddWithValue("@Pos_ID", int.Parse(TextBox1.Text));
                    comm.Parameters.AddWithValue("@Team", TextBox2.Text);
                    comm.Parameters.AddWithValue("@Matches", int.Parse(TextBox5.Text));
                    comm.Parameters.AddWithValue("@Won", int.Parse(TextBox3.Text));
                    comm.Parameters.AddWithValue("@Lost", int.Parse(TextBox4.Text));
                    comm.Parameters.AddWithValue("@Drawn", int.Parse(TextBox6.Text));
                    comm.Parameters.AddWithValue("@Points", int.Parse(TextBox7.Text));
                    comm.Parameters.AddWithValue("@PCT", double.Parse(TextBox8.Text));

                    con.Open();
                    comm.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);
                    LoadRecords();
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM VolleyBall_Game_Points_Table WHERE Pos_ID = @Pos_ID";
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    comm.Parameters.AddWithValue("@Pos_ID", int.Parse(TextBox1.Text));

                    con.Open();
                    comm.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Deleted');", true);
                    LoadRecords();
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM VolleyBall_Game_Points_Table WHERE Pos_ID = @Pos_ID";
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    comm.Parameters.AddWithValue("@Pos_ID", int.Parse(TextBox1.Text));

                    using (SqlDataAdapter da = new SqlDataAdapter(comm))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM VolleyBall_Game_Points_Table WHERE Pos_ID = @Pos_ID";
                using (SqlCommand comm = new SqlCommand(query, con))
                {
                    comm.Parameters.AddWithValue("@Pos_ID", int.Parse(TextBox1.Text));

                    con.Open();
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TextBox2.Text = reader["Team"].ToString();
                            TextBox5.Text = reader["Matches"].ToString();
                            TextBox3.Text = reader["Won"].ToString();
                            TextBox4.Text = reader["Lost"].ToString();
                            TextBox6.Text = reader["Drawn"].ToString();
                            TextBox7.Text = reader["Points"].ToString();
                            TextBox8.Text = reader["PCT"].ToString();
                        }
                    }
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox5.Text = string.Empty;
            TextBox6.Text = string.Empty;
            TextBox7.Text = string.Empty;
            TextBox8.Text = string.Empty;
        }
    }
}
