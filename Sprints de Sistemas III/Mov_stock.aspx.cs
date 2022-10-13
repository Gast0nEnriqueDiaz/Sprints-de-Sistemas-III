using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Sprints_de_Sistemas_III
{
    public partial class Mov_stock : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            CrearConexion();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select S.ID,D.Nombre,A.Nombre'AN',Fecha_hora,Activ,S.Cantidad from Stock_Mov S inner join Deposito D on S.ID_dep=D.ID inner join Articulo A on S.ID_art=A.ID where A.Nombre like '%"+TextBox1.Text+"%' or D.Nombre like '%"+TextBox1.Text+"%' or A.ID like '%"+TextBox1.Text+"%'";
            SqlCommand SQLcom = new SqlCommand(qry, con);
            SQLcom.ExecuteNonQuery();
            DataTable stk = new DataTable();
            SqlDataAdapter sk = new SqlDataAdapter(SQLcom);
            sk.Fill(stk);
            Stk_colum.DataSource = stk;
            Stk_colum.DataBind();
            Stk_colum.Visible = true;
            con.Close();
        }
        void CrearConexion()
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();

            //cs.DataSource = @"LAPTOP-HUIOQ9EK\MSSQLSERVER_5";
            cs.DataSource = @"DESKTOP-DE5NP25";
            cs.InitialCatalog = "hospital";
            cs.UserID = "Visual";
            cs.Password = "123456";


            con = new SqlConnection(cs.ConnectionString);
        }

    }
}