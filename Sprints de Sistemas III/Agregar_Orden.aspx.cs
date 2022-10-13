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
    public partial class Agregar_Orden : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            CrearConexion();
            //con.Open();
            //string qry = "select* from Proveedor";
            //SqlCommand SQLCom = new SqlCommand(qry, con);
            //SqlDataAdapter provs = new SqlDataAdapter(SQLCom);
            //DataTable art = new DataTable();
            //provs.Fill(art);
            //Colum_Prov.DataSource = art;
            //Colum_Prov.DataBind();
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
        protected void Prov_selectBtn_Click(object sender, EventArgs e)
        {
            Button ARTBtn_ = sender as Button;
            GridViewRow row = (GridViewRow)ARTBtn_.NamingContainer;
            int I = row.RowIndex;
            Colum_Prov.SelectedIndex = I;
            int ID_pr = Convert.ToInt32(Colum_Prov.DataKeys[I].Value);
            ID_prov.Text = ID_pr.ToString();

            con.Open();
            string qry = "select* from Proveedor where ID=@prID";
            SqlCommand SQLCom = new SqlCommand(qry, con);
            SQLCom.Parameters.Add(new SqlParameter("@prID",ID_pr));
            SqlDataReader leer = SQLCom.ExecuteReader();
            leer.Read();
            Nomb_lb.Text = leer["NombreCompleto"].ToString();
            Nomb_lb.Visible = true;
            Telf_lb.Text = leer["Telefono"].ToString();
            Telf_lb.Visible = true;
            Direc_lb.Text = leer["Direccion"].ToString();
            Direc_lb.Visible = true;
            //Nomb_lb.Text = leer["NombreCompleto"].ToString();
            //Nomb_lb.Visible = true;
            Button4.Visible = true;
            Button2.Visible = true;
            Colum_Prov.Visible = false;
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select* from Proveedor where ID like '%" + Buscador_prov_tx.Text + "%' or NombreCompleto like '%" + Buscador_prov_tx.Text + "%'";
            SqlCommand SQLCom = new SqlCommand(qry, con);
            SqlDataAdapter provs = new SqlDataAdapter(SQLCom);
            DataTable art = new DataTable();
            provs.Fill(art);
            Colum_Prov.DataSource = art;
            Colum_Prov.DataBind();
            con.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Colum_Prov.Visible = true;
            Button4.Visible = false;
            Button2.Visible = false;
            Nomb_lb.Visible = false;
            Telf_lb.Visible = false;
            Direc_lb.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)//agregara articulos a la orden despues CAMBIAR ARTICULOS Y/O PONER CATEGORIAS PARA PROVEEDORES
        {
            con.Open();
            string qry = "insert OrdenDeCompra(ID_Proveedor,Fecha) values(@prID_p,@prDate)";
            SqlCommand SQLCom = new SqlCommand(qry, con);
            SQLCom.Parameters.Add(new SqlParameter("@prID_p",ID_prov.Text));
            DateTime dateTime = DateTime.Today;
            SQLCom.Parameters.Add(new SqlParameter("@prDate", dateTime));
            SQLCom.ExecuteNonQuery();
            con.Close();
            con.Open();
            string contra = "select MAX(ID) from OrdenDeCompra";
            SqlCommand SQLaa = new SqlCommand(contra, con);
            SqlDataReader sqlDataReader = SQLaa.ExecuteReader();
            sqlDataReader.Read();
            int ID_ord = Convert.ToInt32(sqlDataReader[""].ToString());
            con.Close();

            Response.Redirect("~/Detalle_ord.aspx?ID_ord=" + ID_ord);
        }
    }
}