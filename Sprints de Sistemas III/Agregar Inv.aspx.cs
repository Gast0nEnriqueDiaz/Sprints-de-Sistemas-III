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
    public partial class Agregar_Inv : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            CrearConexion();
            Articulos_Colum.Visible = false;
            Categorias_colum.Visible = false;
            Depositos_col.Visible = false;
            Agregar_Art_btn.Visible = false;
            Agregar_Cat_btn.Visible = false;
            Agregar_Dep_btn.Visible = false;


            ////Categorias
            //con.Open();
            //string qry = "select* from Categorias";
            //SqlCommand CatSqlCom = new SqlCommand(qry, con);
            //SqlDataAdapter Categorias = new SqlDataAdapter(CatSqlCom);
            //DataTable cat = new DataTable();
            //Categorias.Fill(cat);
            //Categorias_colum.DataSource = cat;
            //Categorias_colum.DataBind();
            //con.Close();
            ////Depositos
            //con.Open();
            //qry = "select* from Deposito";
            //SqlCommand DepSQLCom = new SqlCommand(qry, con);
            //SqlDataAdapter Depositos = new SqlDataAdapter(DepSQLCom);
            //DataTable Dep = new DataTable();
            //Depositos.Fill(Dep);
            //Depositos_col.DataSource = Dep;
            //Depositos_col.DataBind();
            //con.Close();
            ////Articulos
            //con.Open();
            //qry = "select* from Articulo";
            //SqlCommand ArtSQLCom = new SqlCommand(qry, con);
            //SqlDataAdapter Articulos = new SqlDataAdapter(ArtSQLCom);
            //DataTable art = new DataTable();
            //Articulos.Fill(art);
            //Articulos_Colum.DataSource = art;
            //Articulos_Colum.DataBind(); 
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

        protected void Categorias_colum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Agregar_Cat_btn_Click(object sender, EventArgs e)//agregar categoria
        {

        }

        protected void ImagenBtn___Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void CategoriaBtn_Click(object sender, EventArgs e)//este es el de editar Categorias, ya anda
        {
            Button CategoriaBtn_ = sender as Button;
            GridViewRow row = (GridViewRow)CategoriaBtn_.NamingContainer;
            int I = row.RowIndex;
            Categorias_colum.SelectedIndex = I;
            //var row = Categorias_colum.SelectedDataKey;
            //Label1.Text = I.ToString();
            int ID_cat = Convert.ToInt32(Categorias_colum.DataKeys[I].Value);

            //AHORA PARA QUE SE MUESTREN LAS COSAS
            Nombre_cat_edit.Visible = true;
            Nomb_cat_ed.Visible = true;
            Desc_cat_ed.Visible = true;
            Desc_cat_edit.Visible = true;
            Camb_cat_btn.Visible = true;
            Eliminar_cat_btn.Visible = true;

            //AHORA PARA QUE ME SALGAN LOS DATOS SOLOS
            con.Open();
            string qry = "select* from Categorias Where ID=@prID";
            SqlCommand CatSqlCom = new SqlCommand(qry, con);
            SqlDataAdapter Categorias = new SqlDataAdapter(CatSqlCom);
            CatSqlCom.Parameters.Add(new SqlParameter("@prID", ID_cat));
            SqlDataReader leer = CatSqlCom.ExecuteReader();
            leer.Read();
            Nombre_cat_edit.Text = leer["Nombre_categoria"].ToString();
            Desc_cat_edit.Text= leer["Descipcion"].ToString();
            con.Close();

            ID_cat_lb.Text = ID_cat.ToString();
            
        }

        protected void DepositaEditBtn_Click(object sender, EventArgs e)//este es el de editarDepositos
        {
            Button ARTBtn_ = sender as Button;
            GridViewRow row = (GridViewRow)ARTBtn_.NamingContainer;
            int I = row.RowIndex;
            Depositos_col.SelectedIndex = I;
            int ID_dep = Convert.ToInt32(Depositos_col.DataKeys[I].Value);

            //Verlos
            Dep_nom_lb.Visible = true;
            Depos_nom.Visible = true;
            Dep_ubi_lb.Visible = true;
            Depo_ubi.Visible = true;
            Depos_guardar_btn.Visible = true;
            Depor_borrar_btn.Visible = true;

            //AHORA PARA QUE ME SALGAN LOS DATOS SOLOS
            con.Open();
            string qry = "select* from Deposito Where ID=@prID";
            SqlCommand CatSqlCom = new SqlCommand(qry, con);
            CatSqlCom.Parameters.Add(new SqlParameter("@prID", ID_dep));
            SqlDataReader leer = CatSqlCom.ExecuteReader();
            leer.Read();
            Depos_nom.Text = leer["Nombre"].ToString();
            Depo_ubi.Text = leer["Direccion"].ToString();
            con.Close();

            ID_Dep_lb.Text = ID_dep.ToString();
        }

        protected void Articulo_editBtn_Click(object sender, EventArgs e)//este es el de editar Articulos
        {
            Button ARTBtn_ = sender as Button;
            GridViewRow row = (GridViewRow)ARTBtn_.NamingContainer;
            int I = row.RowIndex;
            Articulos_Colum.SelectedIndex = I;
            int ID_art= Convert.ToInt32(Articulos_Colum.DataKeys[I].Value);

            //Hacerlos Visibles
            Art_nom_lb.Visible = true;
            Art_nom.Visible = true;
            Art_cat_lb.Visible = true;
            Categorias_list.Visible = true;
            Art_desc_lb.Visible = true;
            Art_desc.Visible = true;
            Art_Pre_lb.Visible = true;
            Art_precio.Visible = true;
            Art_stk_lb.Visible = true;
            Art_stk.Visible = true;
            Art_camb_btn.Visible = true;
            Art_elin_byn.Visible = true;



            //AHORA PARA QUE ME SALGAN LOS DATOS SOLOS
            con.Open();
            string qry = "select A.ID,Nombre_categoria,Nombre,Descripcion,Stock,Precio from Articulo A join Categorias C on A.Categoria=C.ID Where A.ID=@prID";
            SqlCommand CatSqlCom = new SqlCommand(qry, con);
            SqlDataAdapter Categorias = new SqlDataAdapter(CatSqlCom);
            CatSqlCom.Parameters.Add(new SqlParameter("@prID", ID_art));
            SqlDataReader leer = CatSqlCom.ExecuteReader();
            leer.Read();
            //Categorias_list.Text= leer["Nombre_categoria"].ToString();//debo cambiar para que diga otro nombre
            Art_precio.Text= leer["Precio"].ToString();
            Art_stk.Text = leer["Stock"].ToString();
            Art_nom.Text=leer["Nombre"].ToString();
            Art_desc.Text = leer["Descripcion"].ToString();
            con.Close();

            ID_Art_lb.Text = ID_art.ToString();
        }

        protected void Cate_btn_Click(object sender, EventArgs e)//ver las categorias
        {
            //articulos
            Art_nom_lb.Visible = false;
            Art_nom.Visible = false;
            Art_cat_lb.Visible = false;
            Categorias_list.Visible = false;
            Art_desc_lb.Visible = false;
            Art_desc.Visible = false;
            Art_Pre_lb.Visible = false;
            Art_precio.Visible = false;
            Art_stk_lb.Visible = false;
            Art_stk.Visible = false;
            Art_camb_btn.Visible = false;
            Art_elin_byn.Visible = false;
            Buscador_art.Visible = false;
            Buscar_art_btn.Visible = false;
            //Depositos
            Dep_nom_lb.Visible = false;
            Depos_nom.Visible = false;
            Dep_ubi_lb.Visible = false;
            Depo_ubi.Visible = false;
            Depos_guardar_btn.Visible = false;
            Depor_borrar_btn.Visible = false;


            //con.Open();
            //string qry = "select* from Categorias";
            //SqlCommand CatSqlCom = new SqlCommand(qry, con);
            //SqlDataAdapter Categorias = new SqlDataAdapter(CatSqlCom);
            //DataTable cat = new DataTable();
            //Categorias.Fill(cat);
            //Categorias_colum.DataSource = cat;
            //Categorias_colum.DataBind();
            //con.Close();

            Categorias_colum.Visible = false;
            Articulos_Colum.Visible = false;
            Depositos_col.Visible = false;
            Agregar_Art_btn.Visible = false;
            Agregar_Cat_btn.Visible = true;
            Agregar_Dep_btn.Visible = false;
            Buscador_cat.Visible = true;
            Buscador_cat_btn.Visible = true;
        }

        protected void Deposit_btn_Click(object sender, EventArgs e)//ver los depositos
        {
            Buscador_dep.Visible = true;
            Buscador_dep_btn.Visible = true;

            //categorias
            Nombre_cat_edit.Visible = false;
            Nomb_cat_ed.Visible = false;
            Desc_cat_ed.Visible = false;
            Desc_cat_edit.Visible = false;
            Camb_cat_btn.Visible = false;
            Eliminar_cat_btn.Visible = false;
            //articulos
            Art_nom_lb.Visible = false;
            Art_nom.Visible = false;
            Art_cat_lb.Visible = false;
            Categorias_list.Visible = false;
            Art_desc_lb.Visible = false;
            Art_desc.Visible = false;
            Art_Pre_lb.Visible = false;
            Art_precio.Visible = false;
            Art_stk_lb.Visible = false;
            Art_stk.Visible = false;
            Art_camb_btn.Visible = false;
            Art_elin_byn.Visible = false;
            Buscador_art.Visible = false;
            Buscar_art_btn.Visible = false;


            //con.Open();
            //string qry = "select* from Deposito";
            //SqlCommand DepSQLCom = new SqlCommand(qry, con);
            //SqlDataAdapter Depositos = new SqlDataAdapter(DepSQLCom);
            //DataTable Dep = new DataTable();
            //Depositos.Fill(Dep);
            //Depositos_col.DataSource = Dep;
            //Depositos_col.DataBind();
            //con.Close();

            Depositos_col.Visible = true;
            Articulos_Colum.Visible = false;
            Categorias_colum.Visible = false;
            Agregar_Art_btn.Visible = false;
            Agregar_Cat_btn.Visible = false;
            Agregar_Dep_btn.Visible = true;
        }

        protected void Articulos_btn_Click(object sender, EventArgs e)//ver los articulos
        {
            //Depositos
            Dep_nom_lb.Visible = false;
            Depos_nom.Visible = false;
            Dep_ubi_lb.Visible = false;
            Depo_ubi.Visible = false;
            Depos_guardar_btn.Visible = false;
            Depor_borrar_btn.Visible = false;
            //categorias
            Nombre_cat_edit.Visible = false;
            Nomb_cat_ed.Visible = false;
            Desc_cat_ed.Visible = false;
            Desc_cat_edit.Visible = false;
            Camb_cat_btn.Visible = false;
            Eliminar_cat_btn.Visible = false;

            ////con.Open();
            ////string qry = "select A.ID,Nombre_categoria,Nombre,Descripcion,Stock,Precio from Articulo A join Categorias C on A.Categoria=C.ID";
            ////SqlCommand ArtSQLCom = new SqlCommand(qry, con);
            ////SqlDataAdapter Articulos = new SqlDataAdapter(ArtSQLCom);
            ////DataTable art = new DataTable();
            ////Articulos.Fill(art);
            ////Articulos_Colum.DataSource = art;
            ////Articulos_Colum.DataBind();
            ////con.Close();

            //Articulos_Colum.Visible = true;
            //Categorias_colum.Visible = false;
            //Depositos_col.Visible = false;
            Agregar_Art_btn.Visible = true;
            //Agregar_Cat_btn.Visible = false;
            //Agregar_Dep_btn.Visible = false;
            Buscador_art.Visible = true;
            Buscar_art_btn.Visible = true;
        }

        protected void Dep_Stock_ver_Click(object sender, EventArgs e)//este es para ver los articulos de acada deposito
        {
            Button ARTBtn_ = sender as Button;
            GridViewRow row = (GridViewRow)ARTBtn_.NamingContainer;
            int I = row.RowIndex;
            Articulos_Colum.SelectedIndex = I;
            int ID_Dep = Convert.ToInt32(Depositos_col.DataKeys[I].Value);
            Response.Redirect("stock_dep.aspx?ID="+ID_Dep);
        }

        protected void Art_camb_btn_Click(object sender, EventArgs e)// anda
        {
            con.Open();
            string ver = "select* from Articulo where Nombre like '" + Art_nom.Text + "' and ID!="+ID_Art_lb.Text;
            SqlCommand Rev = new SqlCommand(ver, con);
            SqlDataReader leer2 = Rev.ExecuteReader();

            if (leer2.Read())
            {
                Alert_lb.Visible = true;
            }
            else
            {
                con.Close();
                con.Open();
                string qry1 = "select ID from Categorias where Nombre_categoria=@prN";
                SqlCommand SqlCom2 = new SqlCommand(qry1, con);
                SqlCom2.Parameters.Add(new SqlParameter("@prN", Categorias_list.SelectedValue));
                SqlDataReader Leer = SqlCom2.ExecuteReader();
                Leer.Read();
                string ID_cat = Leer["ID"].ToString();
                con.Close();

                con.Open();
                string qry = "update Articulo set Categoria=@prCat, Nombre=@prNombre, Precio=@prPrecio, Descripcion=@prDesc, Stock=@prStock where ID=@prID";
                SqlCommand Com = new SqlCommand(qry, con);
                Com.Parameters.Add(new SqlParameter("@prCat", ID_cat));
                Com.Parameters.Add(new SqlParameter("@prNombre", Art_nom.Text));
                Com.Parameters.Add(new SqlParameter("@prPrecio", Art_precio.Text));
                Com.Parameters.Add(new SqlParameter("@prDesc", Art_desc.Text));
                Com.Parameters.Add(new SqlParameter("@prStock", Art_stk.Text));
                Com.Parameters.Add(new SqlParameter("@prID", ID_Art_lb.Text));
                Com.ExecuteNonQuery();
                con.Close();

                //dejar invisibles
                Art_nom_lb.Visible = false;
                Art_nom.Visible = false;
                Art_cat_lb.Visible = false;
                Categorias_list.Visible = false;
                Art_desc_lb.Visible = false;
                Art_desc.Visible = false;
                Art_Pre_lb.Visible = false;
                Art_precio.Visible = false;
                Art_stk_lb.Visible = false;
                Art_stk.Visible = false;
                Art_camb_btn.Visible = false;
                Art_elin_byn.Visible = false;
                Alert_lb.Visible = false;

                Response.Redirect(Request.RawUrl);
            }
            
        }

        protected void Depos_guardar_btn_Click(object sender, EventArgs e)//anda
        {
            con.Open();
            string qry = "update Deposito set Nombre=@prNombre,Direccion=@prUbi  where ID=@prID";
            SqlCommand Com = new SqlCommand(qry, con);
            Com.Parameters.Add(new SqlParameter("@prNombre", Depos_nom.Text));
            Com.Parameters.Add(new SqlParameter("@prUbi", Depo_ubi.Text));
            Com.Parameters.Add(new SqlParameter("@prID", ID_Dep_lb.Text));
            Com.ExecuteNonQuery();
            con.Close();

            Dep_nom_lb.Visible = false;
            Depos_nom.Visible = false;
            Dep_ubi_lb.Visible = false;
            Depo_ubi.Visible = false;
            Depos_guardar_btn.Visible = false;
            Depor_borrar_btn.Visible = false;

            Response.Redirect(Request.RawUrl);

        }

        protected void Camb_cat_btn_Click(object sender, EventArgs e)//anda
        {
            con.Open();
            string ver = "select* from Categorias where Nombre_categoria like '" + Nombre_cat_edit.Text + "' and ID!="+ID_cat_lb.Text;
            SqlCommand rev = new SqlCommand(ver, con);
            SqlDataReader leer2 = rev.ExecuteReader();
            if (leer2.Read())
            {
                Alert_lb0.Visible = true;
            }
            else
            {
                con.Close();
                con.Open();
                string qry = "update Categorias set Nombre_categoria=@prNombre,Descipcion=@prDesc  where ID=@prID";
                SqlCommand Com = new SqlCommand(qry, con);
                Com.Parameters.Add(new SqlParameter("@prNombre", Nombre_cat_edit.Text));
                Com.Parameters.Add(new SqlParameter("@prDesc", Desc_cat_edit.Text));
                Com.Parameters.Add(new SqlParameter("@prID", ID_cat_lb.Text));
                Com.ExecuteNonQuery();
                con.Close();
                Nombre_cat_edit.Visible = false;
                Nomb_cat_ed.Visible = false;
                Desc_cat_ed.Visible = false;
                Desc_cat_edit.Visible = false;
                Camb_cat_btn.Visible = false;
                Eliminar_cat_btn.Visible = false;
                Alert_lb0.Visible = false;
                Response.Redirect(Request.RawUrl);
            }


        }

        protected void Art_elin_byn_Click(object sender, EventArgs e)//quitar Articulo
        {
            con.Open();
            string qry = "delete Articulo where ID=@prID";
            SqlCommand Com = new SqlCommand(qry, con);
            Com.Parameters.Add(new SqlParameter("@prID",ID_Art_lb.Text));
            Com.ExecuteNonQuery();
            con.Close();
            //dejar invisibles
            Art_nom_lb.Visible = false;
            Art_nom.Visible = false;
            Art_cat_lb.Visible = false;
            Categorias_list.Visible = false;
            Art_desc_lb.Visible = false;
            Art_desc.Visible = false;
            Art_Pre_lb.Visible = false;
            Art_precio.Visible = false;
            Art_stk_lb.Visible = false;
            Art_stk.Visible = false;
            Art_camb_btn.Visible = false;
            Art_elin_byn.Visible = false;
            Response.Redirect(Request.RawUrl);

        }

        protected void Depor_borrar_btn_Click(object sender, EventArgs e)//eliminar deposito
        {
            con.Open();
            string qry = "delete Deposito where ID=@prID";
            SqlCommand Com = new SqlCommand(qry, con);
            Com.Parameters.Add(new SqlParameter("@prID", ID_Dep_lb.Text));
            Com.ExecuteNonQuery();
            con.Close();

            Dep_nom_lb.Visible = false;
            Depos_nom.Visible = false;
            Dep_ubi_lb.Visible = false;
            Depo_ubi.Visible = false;
            Depos_guardar_btn.Visible = false;
            Depor_borrar_btn.Visible = false;
            Response.Redirect(Request.RawUrl);

        }

        protected void Eliminar_cat_btn_Click(object sender, EventArgs e)//eliminar Categoria
        {
            con.Open();
            string qry = "delete Categorias where ID=@prID";
            SqlCommand Com = new SqlCommand(qry, con);
            Com.Parameters.Add(new SqlParameter("@prID", ID_cat_lb.Text));
            Com.ExecuteNonQuery();
            con.Close();
            Nombre_cat_edit.Visible = false;
            Nomb_cat_ed.Visible = false;
            Desc_cat_ed.Visible = false;
            Desc_cat_edit.Visible = false;
            Camb_cat_btn.Visible = false;
            Eliminar_cat_btn.Visible = false;
            Response.Redirect(Request.RawUrl);
        }

        protected void Buscar_art_btn_Click(object sender, EventArgs e)//Buscador por nombre o categoria
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

            Articulos_Colum.Visible = true;
            Categorias_colum.Visible = false;
            Depositos_col.Visible = false;
            Agregar_Art_btn.Visible = true;
            Agregar_Cat_btn.Visible = false;
            Agregar_Dep_btn.Visible = false;
            con.Close();
            //Depositos
            Dep_nom_lb.Visible = false;
            Depos_nom.Visible = false;
            Dep_ubi_lb.Visible = false;
            Depo_ubi.Visible = false;
            Depos_guardar_btn.Visible = false;
            Depor_borrar_btn.Visible = false;
            //categorias
            Nombre_cat_edit.Visible = false;
            Nomb_cat_ed.Visible = false;
            Desc_cat_ed.Visible = false;
            Desc_cat_edit.Visible = false;
            Camb_cat_btn.Visible = false;
            Eliminar_cat_btn.Visible = false;

            Articulos_Colum.Visible = true;
            Categorias_colum.Visible = false;
            Depositos_col.Visible = false;
            Agregar_Art_btn.Visible = true;
            Agregar_Cat_btn.Visible = false;
            Agregar_Dep_btn.Visible = false;
            Buscador_art.Visible = true;
            Buscar_art_btn.Visible = true;
        }

        protected void Agregar_Art_btn_Click(object sender, EventArgs e)
        {

        }

        protected void Buscador_dep_btn_Click(object sender, EventArgs e)
        {
            //categorias
            Nombre_cat_edit.Visible = false;
            Nomb_cat_ed.Visible = false;
            Desc_cat_ed.Visible = false;
            Desc_cat_edit.Visible = false;
            Camb_cat_btn.Visible = false;
            Eliminar_cat_btn.Visible = false;
            //articulos
            Art_nom_lb.Visible = false;
            Art_nom.Visible = false;
            Art_cat_lb.Visible = false;
            Categorias_list.Visible = false;
            Art_desc_lb.Visible = false;
            Art_desc.Visible = false;
            Art_Pre_lb.Visible = false;
            Art_precio.Visible = false;
            Art_stk_lb.Visible = false;
            Art_stk.Visible = false;
            Art_camb_btn.Visible = false;
            Art_elin_byn.Visible = false;
            Buscador_art.Visible = false;
            Buscar_art_btn.Visible = false;


            con.Open();
            string qry = "select* from Deposito where ID='"+Buscador_dep.Text+"' or Direccion like '%"+Buscador_dep.Text+"%'";
            SqlCommand DepSQLCom = new SqlCommand(qry, con);
            SqlDataAdapter Depositos = new SqlDataAdapter(DepSQLCom);
            DataTable Dep = new DataTable();
            Depositos.Fill(Dep);
            Depositos_col.DataSource = Dep;
            Depositos_col.DataBind();
            con.Close();

            Depositos_col.Visible = true;
            Articulos_Colum.Visible = false;
            Categorias_colum.Visible = false;
            Agregar_Art_btn.Visible = false;
            Agregar_Cat_btn.Visible = false;
            Agregar_Dep_btn.Visible = true;
        }

        protected void Buscador_cat_btn_Click(object sender, EventArgs e)
        {


            con.Open();
            string qry = "select* from Categorias where Nombre_categoria like '%"+Buscador_cat.Text+ "%' or ID like '"+Buscador_cat.Text +"'";
            SqlCommand CatSqlCom = new SqlCommand(qry, con);
            SqlDataAdapter Categorias = new SqlDataAdapter(CatSqlCom);
            DataTable cat = new DataTable();
            Categorias.Fill(cat);
            Categorias_colum.DataSource = cat;
            Categorias_colum.DataBind();
            con.Close();

            Categorias_colum.Visible = true;
            Articulos_Colum.Visible = false;
            Depositos_col.Visible = false;
            Agregar_Art_btn.Visible = false;
            Agregar_Cat_btn.Visible = true;
            Agregar_Dep_btn.Visible = false;
            Buscador_cat.Visible = true;
            Buscador_cat_btn.Visible = true;
        }
    }

}