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
    public partial class Agregar_Proveedor : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            CrearConexion();
        }

        protected void Guardar_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            string ver = "select* from Proveedor where NombreCompleto like '%" + Nomb_prov.Text + "%'";
            SqlCommand Rev = new SqlCommand(ver, con);
            SqlDataReader leer = Rev.ExecuteReader();
            if (leer.Read())
            {
                Label1.Visible = true;
            }
            else
            {
                con.Close();
                con.Open();
                string qry = "insert Proveedor(NombreCompleto,Telefono,Direccion) values(@prNombre,@prTelf,@prDesc)";
                SqlCommand SQLCom = new SqlCommand(qry, con);
                SQLCom.Parameters.Add(new SqlParameter("@prNombre", Nomb_prov.Text));
                SQLCom.Parameters.Add(new SqlParameter("@prTelf", Telf_prov.Text));
                SQLCom.Parameters.Add(new SqlParameter("@prDesc", Direcc_prov.Text));
                SQLCom.ExecuteNonQuery();
                con.Close();
                Label1.Visible = false;
                Response.Redirect(Request.RawUrl);
            }
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