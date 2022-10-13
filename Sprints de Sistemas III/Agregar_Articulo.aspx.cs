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
    public partial class Agregar_Articulo : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            CrearConexion();
        }

        protected void Agregar_Art_Click(object sender, EventArgs e)
        {
            con.Open();
            string ver = "select* from Articulo where Nombre like '"+Nomb_art.Text+"'";
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
                string qry1 = "select ID from Categorias where Nombre_categoria=@prN";
                SqlCommand SqlCom2 = new SqlCommand(qry1, con);
                SqlCom2.Parameters.Add(new SqlParameter("@prN", Categorias_list.SelectedValue));
                SqlDataReader Leer = SqlCom2.ExecuteReader();
                Leer.Read();
                string ID_cat = Leer["ID"].ToString();
                con.Close();

                con.Open();
                string qry = "insert Articulo (Nombre,Categoria,Precio,Descripcion,Stock) values(@prNombre,@prCat,@prPrecio,@prDesc,0)";
                SqlCommand SqlCom = new SqlCommand(qry, con);
                SqlCom.Parameters.Add(new SqlParameter("@prNombre", Nomb_art.Text));
                SqlCom.Parameters.Add(new SqlParameter("@prCat", ID_cat));
                SqlCom.Parameters.Add(new SqlParameter("@prPrecio", Precio.Text));
                SqlCom.Parameters.Add(new SqlParameter("@prDesc", Descripcion.Text));
                //SqlCom.Parameters.Add(new SqlParameter("@prStock", Stock.Text));
                SqlCom.ExecuteNonQuery();
                Alert_lb.Visible = false;
                con.Close();
                Response.Redirect(Request.RawUrl);
            }



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

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
    }