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
    public partial class Menu_Proveedores : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)//agregar proveedor
        {
            Colum_Prov.Visible = false;
            Nomb_lb.Visible = true;
            Nomb_prov.Visible = true;
            Telf_lb.Visible = true;
            Telf_prov.Visible = true;
            Direc_lb.Visible = true;
            Direcc_prov.Visible = true;
        }

        protected void Prov_editBtn_Click(object sender, EventArgs e)
        {
            Colum_Prov.Visible = false;
            Edit_prov_camb_btn.Visible = true;
            Nomb_lb.Visible = true;
            Nomb_prov.Visible = true;
            Telf_lb.Visible = true;
            Telf_prov.Visible = true;
            Direc_lb.Visible = true;
            Direcc_prov.Visible = true;

            Button ARTBtn_ = sender as Button;
            GridViewRow row = (GridViewRow)ARTBtn_.NamingContainer;
            int I = row.RowIndex;
            Colum_Prov.SelectedIndex = I;
            int ID_ = Convert.ToInt32(Colum_Prov.DataKeys[I].Value);
            ID_prov.Text = ID_.ToString();

            Edit_prov_camb_btn.Visible = true;

            con.Open();
            string qry = "select* from Proveedor Where ID=@prID";
            SqlCommand SqlCom = new SqlCommand(qry, con);
            SqlCom.Parameters.Add(new SqlParameter("@prID", ID_prov.Text));
            SqlDataReader leer = SqlCom.ExecuteReader();
            leer.Read();
            Nomb_prov.Text = leer["NombreCompleto"].ToString();
            Telf_prov.Text = leer["Telefono"].ToString();
            Direcc_prov.Text = leer["Direccion"].ToString();
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

        protected void Guardar_btn_Click(object sender, EventArgs e)//YA NO EXISTE ESTE, ES UNA NUEVA PANTALLA agregar uno nuevo
        {
            con.Open();
            string qry = "insert Proveedor(NombreCompleto,Telefono,Direccion) values(@prNombre,@prTelf,@prDesc)";
            SqlCommand SQLCom = new SqlCommand(qry, con);
            SQLCom.Parameters.Add(new SqlParameter("@prNombre",Nomb_prov.Text));
            SQLCom.Parameters.Add(new SqlParameter("@prTelf",Telf_prov.Text));
            SQLCom.Parameters.Add(new SqlParameter("@prDesc",Direcc_prov.Text));
            SQLCom.ExecuteNonQuery();
            con.Close();
        }

        protected void Edit_prov_camb_btn_Click(object sender, EventArgs e)// para guardar los cambios
        {
            con.Open();
            string ver = "select* from Proveedor where NombreCompleto like '%" + Nomb_prov.Text + "%' and ID!="+ID_prov.Text;
            SqlCommand Rev = new SqlCommand(ver, con);
            SqlDataReader leer = Rev.ExecuteReader();
            if (leer.Read())
            {
                Alert_lb.Visible = true;
            }
            else
            {
                con.Close();
                con.Open();
                string qry = "update Proveedor set NombreCompleto=@prNombre,Direccion=@prUbi,Telefono=@prTelf  where ID=@prID";
                SqlCommand Com = new SqlCommand(qry, con);
                Com.Parameters.Add(new SqlParameter("@prNombre", Nomb_prov.Text));
                Com.Parameters.Add(new SqlParameter("@prUbi", Direcc_prov.Text));
                Com.Parameters.Add(new SqlParameter("@prTelf", Telf_prov.Text));
                Com.Parameters.Add(new SqlParameter("@prID", ID_prov.Text));
                Com.ExecuteNonQuery();
                con.Close();
                Response.Redirect(Request.RawUrl);
            }

            
        }

        protected void Buscar_art_btn_Click(object sender, EventArgs e)
        {
            //try
            Colum_Prov.Visible = true;

            con.Open();
            string qry = "select* from Proveedor where ID like '%"+Buscador_prov_tx.Text +"%' or NombreCompleto like '%"+ Buscador_prov_tx.Text+"%'" ;
            SqlCommand SQLCom = new SqlCommand(qry, con);
            SqlDataAdapter provs = new SqlDataAdapter(SQLCom);
            DataTable art = new DataTable();
            provs.Fill(art);
            Colum_Prov.DataSource = art;
            Colum_Prov.DataBind();
            con.Close();
        }
    }
}