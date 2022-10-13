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
    public partial class Detalle_ord : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            CrearConexion();
            ID_ord.Text = Request["ID_ord"].ToString();
            ////cargar la lista de articulos
            //con.Open();
            //string qry = "select A.ID,Nombre_categoria,Nombre,Descripcion,Stock,Precio from Articulo A join Categorias C on A.Categoria=C.ID";
            //SqlCommand ArtSQLCom = new SqlCommand(qry, con);
            //SqlDataAdapter Articulos = new SqlDataAdapter(ArtSQLCom);
            //DataTable art = new DataTable();
            //Articulos.Fill(art);
            //Articulos_Colum.DataSource = art;
            //Articulos_Colum.DataBind();
            //con.Close();
            //cargar los de la orden
            con.Open();
            string qry2 = "select O.ID ,ID_ord'N° de orden',Nombre,Cantidad from Detalle_Ord O inner join Articulo A on O.ID_Art=A.ID where O.ID_Ord=@prID";
            SqlCommand SQLCom2 = new SqlCommand(qry2, con);
            SQLCom2.Parameters.Add(new SqlParameter("@prID", ID_ord.Text));
            SqlDataAdapter provs = new SqlDataAdapter(SQLCom2);
            DataTable art2 = new DataTable();
            provs.Fill(art2);
            Colum_Detalles_ord.DataSource = art2;
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
        protected void Articulo_SelectBtn_Click(object sender, EventArgs e)
        {
            Agre_art_ord.Visible = true;

            Button ARTBtn_ = sender as Button;
            GridViewRow row = (GridViewRow)ARTBtn_.NamingContainer;
            int I = row.RowIndex;
            Articulos_Colum.SelectedIndex = I;
            int ID_ord = Convert.ToInt32(Articulos_Colum.DataKeys[I].Value);
            ID_art.Text = ID_ord.ToString();

            con.Open();
            string qry = "select* from Articulo where ID=@prID";
            SqlCommand SQLCom = new SqlCommand(qry, con);
            SQLCom.Parameters.Add(new SqlParameter("@prID", ID_art.Text));
            SqlDataReader leer = SQLCom.ExecuteReader();
            leer.Read();
            Nomb_art_lb.Text = leer["Nombre"].ToString();


            con.Close();
        }

        protected void Agre_art_ord_Click(object sender, EventArgs e)
        {
            con.Open();
            string ver = "select O.ID ,ID_ord'N° de orden',Nombre,Cantidad from Detalle_Ord O inner join Articulo A on O.ID_Art=A.ID where O.ID_Ord like '%" + ID_ord.Text + "%' and  ID_art like '%"+ID_art.Text+"%'";
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
                string qry = "insert Detalle_Ord(ID_ord,ID_Art,Cantidad)values(@prID_ord,@prID_art,@prCant)";
                SqlCommand SQLCom = new SqlCommand(qry, con);
                SQLCom.Parameters.Add(new SqlParameter("@prID_art", ID_art.Text));
                SQLCom.Parameters.Add(new SqlParameter("@prID_ord", ID_ord.Text));
                SQLCom.Parameters.Add(new SqlParameter("@prCant", Cant_tx.Text));
                SQLCom.ExecuteNonQuery();

                con.Close();
                Nomb_art_lb.Text = "Seleccione un articulo";
                Agre_art_ord.Visible = false;
                Alert_lb.Visible = false;
                Response.Redirect(Request.RawUrl);
            }
            con.Close();
                
        }

        protected void Quitar_artBtn_Click(object sender, EventArgs e)
        {
            Button ARTBtn_ = sender as Button;
            GridViewRow row = (GridViewRow)ARTBtn_.NamingContainer;
            int I = row.RowIndex;
            Colum_Detalles_ord.SelectedIndex = I;
            int ID_ord = Convert.ToInt32(Colum_Detalles_ord.DataKeys[I].Value);


            con.Open();
            string qry = "delete Detalle_Ord where ID=@prID";
            SqlCommand SqlCom = new SqlCommand(qry, con);
            SqlCom.Parameters.Add(new SqlParameter("@prID",ID_ord));
            SqlCom.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.RawUrl);
        }

        protected void Buscar_art_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select A.ID,Nombre_categoria,Nombre,Descripcion,Stock,Precio from Articulo A join Categorias C on A.Categoria=C.ID where Nombre like '%" + Buscador_art.Text + "%' or C.Nombre_categoria like '%" + Buscador_art.Text + "%' or A.ID like '" + Buscador_art.Text + "'";
            SqlCommand Com = new SqlCommand(qry, con);
            Com.ExecuteNonQuery();
            SqlDataAdapter Articulos = new SqlDataAdapter(Com);
            DataTable art = new DataTable();
            Articulos.Fill(art);
            Articulos_Colum.DataSource = art;
            Articulos_Colum.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}