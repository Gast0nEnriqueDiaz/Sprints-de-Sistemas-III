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
    public partial class Facturas : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            CrearConexion();

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
        protected void Button1_Click(object sender, EventArgs e)//buscador
        {
            try
            {
                ID_ord.Text = Num_ord.Text;
                con.Open();
                string qry = "select O.ID ,ID_ord'N° de orden',Nombre,Cantidad from Detalle_Ord O inner join Articulo A on O.ID_Art=A.ID inner join OrdenDeCompra OPC on OPC.ID=O.ID_ord where O.ID_Ord=@prID and OPC.Estado='Aprobado'";
                SqlCommand SQLCom = new SqlCommand(qry, con);
                SQLCom.Parameters.Add(new SqlParameter("@prID",ID_ord.Text));
                SqlDataReader leer4 = SQLCom.ExecuteReader();
                if (leer4.Read())
                {
                    con.Close();
                    con.Open();
                    SqlDataAdapter provs = new SqlDataAdapter(SQLCom);
                    DataTable art = new DataTable();
                    provs.Fill(art);
                    Colum_Detalles_ord.DataSource = art;
                    Colum_Detalles_ord.DataBind();
                    con.Close();

                    Nomb_lb.Visible = true;
                    Cuil_lb.Visible = true;
                    Telf_lb.Visible = true;
                    Mail_lb.Visible = true;
                    Direc_lb.Visible = true;

                    con.Open();
                    string qry2 = "select P.ID,NombreCompleto,Telefono,Direccion from Proveedor P inner join OrdenDeCompra C on C.ID_Proveedor=P.ID  where C.ID=@prID";
                    SqlCommand SQLCom2 = new SqlCommand(qry2, con);
                    SQLCom2.Parameters.Add(new SqlParameter("@prID", ID_ord.Text));
                    SqlDataReader leer = SQLCom2.ExecuteReader();
                    leer.Read();
                    Nomb_lb.Text = leer["NombreCompleto"].ToString();
                    Nomb_lb.Visible = true;
                    Telf_lb.Text = leer["Telefono"].ToString();
                    Telf_lb.Visible = true;
                    Direc_lb.Text = leer["Direccion"].ToString();
                    Direc_lb.Visible = true;
                    ID_prov.Text = leer["ID"].ToString();

                    con.Close();
                }
                else
                {

                }
                
                
                con.Close();

            }
            catch
            {

            }
            finally
            {

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string qry2 = "insert Factura(Fecha,ID_ord,Tipo,ID_prov,MontoPagar,MetodoPago) values(@prFecha,@prID_ord,@prTipo,@prID_prov,@prMonto,@prMetodo)";
                SqlCommand SQLCom2 = new SqlCommand(qry2, con);
                SQLCom2.Parameters.Add(new SqlParameter("@prID_ord", ID_ord.Text));
                SQLCom2.Parameters.Add(new SqlParameter("@prID_prov", ID_prov.Text));
                SQLCom2.Parameters.Add(new SqlParameter("@prTipo", Tipo_fact.Text));
                SQLCom2.Parameters.Add(new SqlParameter("@prMonto", Total_fac.Text));
                SQLCom2.Parameters.Add(new SqlParameter("@prFecha", DateTime.Today));
                SQLCom2.Parameters.Add(new SqlParameter("@prMetodo", Met_pago.Text));
                SQLCom2.ExecuteNonQuery();
                con.Close();

                con.Open();
                string qry = "update OrdenDeCompra set Estado='Facturada' where ID="+ID_ord.Text;
                SqlCommand actord = new SqlCommand(qry, con);
                actord.ExecuteNonQuery();
                con.Close();
                Response.Redirect("~/Factura_ver.aspx?");

            }
            catch
            {

            }
            finally
            {
            }
            
        }
    }
}