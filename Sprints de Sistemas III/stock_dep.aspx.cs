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
    public partial class stock_dep : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            CrearConexion();
            string ID_dep = Request.Params["ID"];
            Label1.Text = ID_dep;
            con.Open();
            string qry = "select A.ID, Nombre_categoria,Nombre,Descripcion,Stock_Deposit from Articulo A inner join Stock_Depo on A.ID=Stock_Depo.ID_art and Stock_Depo.ID_dep=@prID join Categorias C on A.Categoria=C.ID";
            SqlCommand ArtSQLCom = new SqlCommand(qry, con);
            ArtSQLCom.Parameters.Add(new SqlParameter("@prID", ID_dep));
            SqlDataAdapter Articulos = new SqlDataAdapter(ArtSQLCom);
            DataTable art = new DataTable();
            Articulos.Fill(art);
            Articulos_Colum.DataSource = art;
            Articulos_Colum.DataBind();
            con.Close();

            Articulos_Colum.Visible = true;
            //Categorias_colum.Visible = false;
            //Depositos_col.Visible = false;
            //Agregar_Art_btn.Visible = true;
            //Agregar_Cat_btn.Visible = false;
            //Agregar_Dep_btn.Visible = false;
        }

        protected void Articulo_editBtn_Click(object sender, EventArgs e)
        {
            Button ARTBtn_ = sender as Button;
            GridViewRow row = (GridViewRow)ARTBtn_.NamingContainer;
            int I = row.RowIndex;
            Articulos_Colum.SelectedIndex = I;
            int ID_art = Convert.ToInt32(Articulos_Colum.DataKeys[I].Value);
            Label2.Text = ID_art.ToString();
            //Art_nom_lb.Visible = true;
            //Art_nom.Visible = true;
            //Art_cat_lb.Visible = true;
            //Art_cat.Visible = true;
            //Art_desc_lb.Visible = true;
            //Art_desc.Visible = true;
            //Art_Pre_lb.Visible = true;
            //Art_precio.Visible = true;
            Art_stk_lb.Visible = true;
            Art_stk.Visible = true;
            Art_camb_btn.Visible = true;
            //Art_elin_byn.Visible = true;

            con.Open();
            string qry = "select Nombre_categoria,Nombre,Descripcion,Stock_Deposit from Articulo A inner join Stock_Depo on A.ID=Stock_Depo.ID_art and Stock_Depo.ID_dep="+Label1.Text+"join Categorias C on A.Categoria=C.ID where A.ID=@prID";
            SqlCommand CatSqlCom = new SqlCommand(qry, con);
            //SqlDataAdapter Categorias = new SqlDataAdapter(CatSqlCom);
            CatSqlCom.Parameters.Add(new SqlParameter("@prID", ID_art));
            SqlDataReader leer = CatSqlCom.ExecuteReader();
            leer.Read();
            //Art_precio.Text = leer["Precio"].ToString();
            Art_stk.Text = leer["Stock_Deposit"].ToString();
            Cant_orig.Text = leer["Stock_Deposit"].ToString();
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

        protected void Art_camb_btn_Click(object sender, EventArgs e)
        {


            con.Open();
            string qry = "update Stock_Depo set Stock_Deposit="+Art_stk.Text+ " where ID_art="+Label2.Text+"and ID_dep="+Label1.Text;
            SqlCommand Com = new SqlCommand(qry, con);
            Com.ExecuteNonQuery();
            con.Close();

            con.Open();
            int Cantidad = 0;
            string act = "";
            if (Convert.ToInt32(Art_stk.Text) > Convert.ToInt32(Cant_orig.Text))
            {
                Cantidad = Convert.ToInt32(Art_stk.Text) - Convert.ToInt32(Cant_orig.Text);
                act = "insert Stock_Mov(ID_dep,ID_art,Activ,Cantidad,Fecha_hora) values(" + Label1.Text + "," + Label2.Text + ",'Ingreso'," + Cantidad + ",@prDate)";

            }
            else
            {
                Cantidad =  Convert.ToInt32(Cant_orig.Text) - Convert.ToInt32(Art_stk.Text) ;
                act = "insert Stock_Mov(ID_dep,ID_art,Activ,Cantidad,Fecha_hora) values(" + Label1.Text + "," + Label2.Text + ",'Retiro'," +Cantidad +",@prDate)";
            }
            SqlCommand can = new SqlCommand(act, con);
            can.Parameters.Add(new SqlParameter("@prDate", DateTime.Now.TimeOfDay));
            can.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.RawUrl);
        }

        protected void Art_elin_byn_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Bus_art_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select A.ID,Nombre_categoria,Nombre,Descripcion,Stock,Precio from Articulo A join Categorias C on A.Categoria=C.ID where Nombre like '%" + Busc_art_txt.Text + "%' or C.Nombre_categoria like '%" + Busc_art_txt.Text + "%' or A.ID like '"+Busc_art_txt.Text+"'";
            SqlCommand Com = new SqlCommand(qry, con);
            Com.ExecuteNonQuery();
            SqlDataAdapter Articulos = new SqlDataAdapter(Com);
            DataTable art = new DataTable();
            Articulos.Fill(art);
            Articulos_Colum0.DataSource = art;
            Articulos_Colum0.DataBind();
            con.Close();
        }

        protected void Articulo_selectBtn0_Click(object sender, EventArgs e)
        {
            Stock_lb2.Visible = true;
            Art_add_Stock.Visible = true;
            Add_art_btn.Visible = true;
            Button ARTBtn_ = sender as Button;
            GridViewRow row = (GridViewRow)ARTBtn_.NamingContainer;
            int I = row.RowIndex;
            Articulos_Colum.SelectedIndex = I;
            int ID_art = Convert.ToInt32(Articulos_Colum0.DataKeys[I].Value);
            ID_art_add.Text = ID_art.ToString();
        }

        protected void Ver_art_btn_Click(object sender, EventArgs e)
        {
            Busc_lb.Visible = true;
            Busc_art_txt.Visible = true;
            Bus_art_btn.Visible = true;
        }

        protected void Add_art_btn_Click(object sender, EventArgs e)
        {
            con.Open();

            string ver = "select* from Stock_Depo where ID_dep="+Label1.Text+" and ID_art="+ID_art_add.Text+"";
            SqlCommand rev = new SqlCommand(ver, con);
            SqlDataReader leer = rev.ExecuteReader();
            ////primero reviso si no esta ya ese articulo en el deposito
            if (leer.Read())
            {
                Alerta_lb.Visible = true;
            }
            else
            {
                con.Close();
                con.Open();
                string QRY = "insert Stock_Depo(ID_art,ID_dep,Stock_Deposit) values(" + ID_art_add.Text + "," + Label1.Text + "," + Art_add_Stock.Text + ")";
                SqlCommand SQLcom = new SqlCommand(QRY, con);
                SQLcom.ExecuteNonQuery();
                //primero reviso si no esta ya ese articulo en el deposito
                string qry2 = "insert Stock_Mov(ID_dep,ID_art,Activ,Cantidad,Fecha_hora) values(" + Label1.Text + "," + ID_art_add.Text + ",'Ingreso'," + Art_add_Stock.Text + ",@prDate)";
                SqlCommand sqlCommand = new SqlCommand(qry2, con);
                sqlCommand.Parameters.Add(new SqlParameter("@prDate", DateTime.Now.TimeOfDay));
                sqlCommand.ExecuteNonQuery();
                con.Close();
                Alerta_lb.Visible = false;
                Art_add_Stock.Text = "1";
                Response.Redirect(Request.RawUrl);
            }
            con.Close();

            //string QRY = "insert Stock_Depo(ID_art,ID_dep,Stock_Deposit) values("+ID_art_add.Text+","+Label1.Text+","+Art_add_Stock.Text+")";
            //SqlCommand SQLcom = new SqlCommand(QRY, con);
            //SQLcom.ExecuteNonQuery();
            //string qry2 = "insert Stock_Mov(ID_dep,ID_art,Activ,Cantidad,Fecha_hora) values(" + Label1.Text + "," + ID_art_add.Text + ",'Ingreso'," + Art_add_Stock.Text + ",@prDate)";
            //SqlCommand sqlCommand = new SqlCommand(qry2, con);
            //sqlCommand.Parameters.Add(new SqlParameter("@prDate", DateTime.Now.TimeOfDay));
            //sqlCommand.ExecuteNonQuery();
            //con.Close();
        }
    }
}