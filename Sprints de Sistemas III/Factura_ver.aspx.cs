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
    public partial class Factura_ver : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            CrearConexion();
            //con.Open();
            //string qry = "select F.ID,Fecha,ID_ord,Tipo,NombreCompleto,MontoPagar,MetodoPago from Factura F inner join Proveedor P on F.ID_prov=P.ID";
            //SqlCommand SQLCom = new SqlCommand(qry, con);
            ////SQLCom.Parameters.Add(new SqlParameter("@prID", ID_ord.Text));
            //SqlDataAdapter provs = new SqlDataAdapter(SQLCom);
            //DataTable art = new DataTable();
            //provs.Fill(art);
            //Fact_colum.DataSource = art;
            //Fact_colum.DataBind();
            //con.Close();
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select F.ID,Fecha,ID_ord,Tipo,NombreCompleto,MontoPagar,MetodoPago from Factura F inner join Proveedor P on F.ID_prov=P.ID where F.ID like'"+Buscador_fact_tx.Text+"' or ID_ord like '"+Buscador_fact_tx.Text +"' or P.NombreCompleto like '%"+Buscador_fact_tx.Text+"%'";
            SqlCommand SQLCom = new SqlCommand(qry, con);
            //SQLCom.Parameters.Add(new SqlParameter("@prID", ID_ord.Text));
            SqlDataAdapter provs = new SqlDataAdapter(SQLCom);
            DataTable art = new DataTable();
            provs.Fill(art);
            Fact_colum.DataSource = art;
            Fact_colum.DataBind();
            con.Close();
        }

        protected void Pagar_Btn_Click(object sender, EventArgs e)
        {

        }
    }
}