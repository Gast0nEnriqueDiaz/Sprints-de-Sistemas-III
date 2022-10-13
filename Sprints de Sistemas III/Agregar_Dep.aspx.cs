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
    public partial class Agregar_Dep : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            CrearConexion();
        }

        protected void Agregar_depo_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "insert Deposito(Nombre,Direccion) values(@prNombre,@prDesc)";
            SqlCommand SqlCom = new SqlCommand(qry, con);
            SqlCom.Parameters.Add(new SqlParameter("@prNombre", Nomb_dep.Text));
            SqlCom.Parameters.Add(new SqlParameter("@prDesc", Direcc_dep.Text));
            SqlCom.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.RawUrl);

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