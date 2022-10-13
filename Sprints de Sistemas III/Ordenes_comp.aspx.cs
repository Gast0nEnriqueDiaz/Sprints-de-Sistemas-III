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
    public partial class Ordenes_comp : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            CrearConexion();
            //con.Open();
            //string qry = "select OC.ID,NombreCompleto,Estado,Fecha from OrdenDeCompra OC inner join Proveedor P on OC.ID_Proveedor=P.ID";
            //SqlCommand SQLCom = new SqlCommand(qry, con);
            //SqlDataAdapter provs = new SqlDataAdapter(SQLCom);
            //DataTable art = new DataTable();
            //provs.Fill(art);
            //Colum_Ord.DataSource = art;
            //Colum_Ord.DataBind();
            

            //con.Close();
        }

        protected void Ord_detalles_Click(object sender, EventArgs e)
        {
            Colum_Detalles_ord.Visible = true;
            NRo_ord_lb.Visible = true;

            //Agregar_art_btn.Visible = true;

            Button ARTBtn_ = sender as Button;
            GridViewRow row = (GridViewRow)ARTBtn_.NamingContainer;
            int I = row.RowIndex;
            Colum_Ord.SelectedIndex = I;
            int ID_ord = Convert.ToInt32(Colum_Ord.DataKeys[I].Value);
            NRo_ord_lb.Text = "N° de orden: " + ID_ord.ToString();
            Label1.Text = ID_ord.ToString();

            con.Open();
            string ver = "select* from OrdenDeCompra where ID=" + Label1.Text + "and Estado='Espera Aprobacion'";
            SqlCommand Rev = new SqlCommand(ver, con);
            SqlDataReader leer = Rev.ExecuteReader();
            if (leer.Read())
            {
                Agregar_art_btn.Visible = true;
            }
            else
            {
                Agregar_art_btn.Visible = false;
            }
            con.Close();
            con.Open();
            string qry = "select O.ID ,ID_ord'N° de orden',Nombre,Cantidad from Detalle_Ord O inner join Articulo A on O.ID_Art=A.ID where O.ID_Ord=@prID";
            SqlCommand SQLCom = new SqlCommand(qry, con);
            SQLCom.Parameters.Add(new SqlParameter("@prID",ID_ord ));
            SqlDataAdapter provs = new SqlDataAdapter(SQLCom);
            DataTable art = new DataTable();
            provs.Fill(art);
            Colum_Detalles_ord.DataSource = art;
            Colum_Detalles_ord.DataBind();
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

        protected void Ord_editBtn_Click(object sender, EventArgs e)
        {
            Button ARTBtn_ = sender as Button;
            GridViewRow row = (GridViewRow)ARTBtn_.NamingContainer;
            int I = row.RowIndex;
            Colum_Ord.SelectedIndex = I;
            int ID_ord = Convert.ToInt32(Colum_Ord.DataKeys[I].Value);
            con.Open();
            string ver = "select* from OrdenDeCompra where ID="+ID_ord.ToString()+"and Estado='Espera Aprobacion'";
            SqlCommand Rev = new SqlCommand(ver, con);
            SqlDataReader leer = Rev.ExecuteReader();
            if (leer.Read())
            {
                Label1.Text = ID_ord.ToString();
                Nomb_Prov_lb.Visible = true;
                Borrar_ord_btn.Visible = true;
                Camb_prov_btn.Visible = true;
                Ord_aprob_btn.Visible = true;
                Lista_provs.Visible = true;

            }
            else
            {
                //mostrar mensaje no se puede editar aprobados
                Nomb_Prov_lb.Visible = false;
                Borrar_ord_btn.Visible = false;
                Camb_prov_btn.Visible = false;
                Ord_aprob_btn.Visible = false;
                Lista_provs.Visible = false;
            }

                

        }

        protected void Buscar_art_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select OC.ID,NombreCompleto,Estado,Fecha from OrdenDeCompra OC inner join Proveedor P on OC.ID_Proveedor=P.ID where P.NombreCompleto like '%"+Buscador_ord_tx.Text+"%' or OC.ID like @prProv or Fecha like '% "+Buscador_ord_tx.Text+"%'";
            SqlCommand SQLCom = new SqlCommand(qry, con);
            SqlDataAdapter provs = new SqlDataAdapter(SQLCom);
            SQLCom.Parameters.Add(new SqlParameter("@prProv",Buscador_ord_tx.Text));
            DataTable art = new DataTable();
            provs.Fill(art);
            Colum_Ord.DataSource = art;
            Colum_Ord.DataBind();


            con.Close();
        }

        protected void NOse_btn_Click(object sender, EventArgs e)
        {
            Label1.Text = Lista_provs.SelectedValue;
            
        }

        protected void Art_editBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            string ver = "select* from OrdenDeCompra where ID=" + Label1.Text + "and Estado='Espera Aprobacion'";
            SqlCommand Rev = new SqlCommand(ver, con);
            SqlDataReader leer2 = Rev.ExecuteReader();
            if (leer2.Read())
            {
                con.Close();
                Button ARTBtn_ = sender as Button;
                GridViewRow row = (GridViewRow)ARTBtn_.NamingContainer;
                int I = row.RowIndex;
                Colum_Detalles_ord.SelectedIndex = I;
                int id_detalle = Convert.ToInt32(Colum_Detalles_ord.DataKeys[I].Value);
                Label2.Visible = true;
                Cant_cam_bt.Visible = true;
                Borar_art.Visible = true;
                Cant_tx.Visible = true;
                ID_deta.Text = id_detalle.ToString();

                con.Open();
                string qry = "select* from Detalle_Ord where ID=@prID";
                SqlCommand SqlCom = new SqlCommand(qry, con);
                SqlCom.Parameters.Add(new SqlParameter("@prID", id_detalle));
                SqlDataReader leer = SqlCom.ExecuteReader();
                leer.Read();
                Cant_tx.Text = leer["Cantidad"].ToString();
                con.Close();
            }
            else
            {

            }

             
        }

        protected void Art_quitartBtn_Click(object sender, EventArgs e)
        {

        }

        protected void Camb_prov_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "update OrdenDeCompra set ID_Proveedor=@prID_prov where ID=@prID";
            SqlCommand SqlCom = new SqlCommand(qry, con);
            SqlCom.Parameters.Add(new SqlParameter("@prID", Label1.Text));
            SqlCom.Parameters.Add(new SqlParameter("@prID_prov",Lista_provs.SelectedValue));
            SqlCom.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.RawUrl);
        }

        protected void Ord_aprob_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "update OrdenDeCompra set Estado='Aprobado' where ID=@prID";
            SqlCommand SQLCom = new SqlCommand(qry, con);
            SQLCom.Parameters.Add(new SqlParameter("@prID",Label1.Text));
            SQLCom.ExecuteNonQuery();

            con.Close();
            Response.Redirect(Request.RawUrl);
        }

        protected void Cant_cam_bt_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "update Detalle_Ord set Cantidad=@prCant where ID=@prID";
            SqlCommand SqlCom = new SqlCommand(qry, con);
            SqlCom.Parameters.Add(new SqlParameter("@prID",ID_deta.Text));
            SqlCom.Parameters.Add(new SqlParameter("@prCant", Cant_tx.Text));
            SqlCom.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.RawUrl);

        }

        protected void Borar_art_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "delete Detalle_Ord where ID=@prID";
            SqlCommand SqlCom = new SqlCommand(qry, con);
            SqlCom.Parameters.Add(new SqlParameter("@prID", ID_deta.Text));
            SqlCom.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.RawUrl);

        }

        protected void Borrar_ord_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "delete Detalle_Ord where ID_ord=@prID";
            SqlCommand SqlCom = new SqlCommand(qry, con);
            SqlCom.Parameters.Add(new SqlParameter("@prID", Label1.Text));
            SqlCom.ExecuteNonQuery();
            con.Close();

            con.Open();
            string qry2 = "delete OrdenDeCompra where ID=@prID";
            SqlCommand SqlCom2 = new SqlCommand(qry2, con);
            SqlCom2.Parameters.Add(new SqlParameter("@prID", Label1.Text));
            SqlCom2.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.RawUrl);
        }

        protected void Agregar_art_btn_Click(object sender, EventArgs e)
        {
                Response.Redirect("~/Detalle_ord.aspx?ID_ord="+Label1.Text);
        }

        protected void Agregar_ord_Click(object sender, EventArgs e)
        {

        }

        protected void Aprob_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select OC.ID,NombreCompleto,Estado,Fecha from OrdenDeCompra OC inner join Proveedor P on OC.ID_Proveedor=P.ID where (P.NombreCompleto like '%" + Buscador_ord_tx.Text + "%' or OC.ID like @prProv or Fecha like '% " + Buscador_ord_tx.Text + "%') and Estado='Aprobado'";
            SqlCommand SQLCom = new SqlCommand(qry, con);
            SqlDataAdapter provs = new SqlDataAdapter(SQLCom);
            SQLCom.Parameters.Add(new SqlParameter("@prProv", Buscador_ord_tx.Text));
            DataTable art = new DataTable();
            provs.Fill(art);
            Colum_Ord.DataSource = art;
            Colum_Ord.DataBind();


            con.Close();
        }

        protected void Fact_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select OC.ID,NombreCompleto,Estado,Fecha from OrdenDeCompra OC inner join Proveedor P on OC.ID_Proveedor=P.ID where (P.NombreCompleto like '%" + Buscador_ord_tx.Text + "%' or OC.ID like @prProv or Fecha like '% " + Buscador_ord_tx.Text + "%') and Estado='Facturada'";
            SqlCommand SQLCom = new SqlCommand(qry, con);
            SqlDataAdapter provs = new SqlDataAdapter(SQLCom);
            SQLCom.Parameters.Add(new SqlParameter("@prProv", Buscador_ord_tx.Text));
            DataTable art = new DataTable();
            provs.Fill(art);
            Colum_Ord.DataSource = art;
            Colum_Ord.DataBind();


            con.Close();
        }

        protected void ESP_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select OC.ID,NombreCompleto,Estado,Fecha from OrdenDeCompra OC inner join Proveedor P on OC.ID_Proveedor=P.ID where (P.NombreCompleto like '%" + Buscador_ord_tx.Text + "%' or OC.ID like @prProv or Fecha like '% " + Buscador_ord_tx.Text + "%') and Estado='Espera Aprobacion'";
            SqlCommand SQLCom = new SqlCommand(qry, con);
            SqlDataAdapter provs = new SqlDataAdapter(SQLCom);
            SQLCom.Parameters.Add(new SqlParameter("@prProv", Buscador_ord_tx.Text));
            DataTable art = new DataTable();
            provs.Fill(art);
            Colum_Ord.DataSource = art;
            Colum_Ord.DataBind();


            con.Close();
        }
    }
}