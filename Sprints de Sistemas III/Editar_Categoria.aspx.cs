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
    public partial class Editar__Nuevo : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            CrearConexion();
            //Label3.Text = Request.Params["ID"];
        }

        protected void Agregar_Cat_Click(object sender, EventArgs e)
        {
            con.Open();
            string ver = "select* from Categorias where Nombre_categoria like '" + Nomb_Cat.Text+"'";
            SqlCommand rev = new SqlCommand(ver, con);
            SqlDataReader leer2 = rev.ExecuteReader();
            if (leer2.Read())
            {
                Alert_lb.Visible = true;
            }
            else
            {
                con.Close();
                con.Open();
                string qry = "insert Categorias(Nombre_categoria,Descipcion) values(@prNombre,@prDesc)";
                SqlCommand SqlCom = new SqlCommand(qry, con);
                SqlCom.Parameters.Add(new SqlParameter("@prNombre", Nomb_Cat.Text));
                SqlCom.Parameters.Add(new SqlParameter("@prDesc", Desct_cat.Text));
                SqlCom.ExecuteNonQuery();
                con.Close();
                Alert_lb.Visible = false;
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
    }
}