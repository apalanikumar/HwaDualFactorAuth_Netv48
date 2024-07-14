using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.Web.Script.Serialization;
using System.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace HwaDualFactorAuth_Netv48
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
            //    this.BindGrid();
            //}
        }

        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Email, PhoneNumber, Username FROM AspNetUsers"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
        protected void DataLoad_Click(object sender, EventArgs e)
        {           
            BindGrid();

        }
    }
}