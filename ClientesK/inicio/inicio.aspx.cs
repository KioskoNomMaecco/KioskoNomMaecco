using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using wcfKioskoCli;

public partial class inicio_inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["objusuario"] == null)
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("../default.aspx");
        }
        if (!IsPostBack)
        {
            DataTable usuario = (DataTable)Session["objusuario"];
           lblnombre.Text = usuario.Rows[0]["nombre"].ToString();


            DateTime thisDay = DateTime.Today;

            // Difference in days, hours, and minutes.
            String tmp = usuario.Rows[0]["fechapass"].ToString();
            if (!tmp.Equals(""))
            {
                DateTime passDate = Convert.ToDateTime(tmp.Remove(18));
                TimeSpan ts = thisDay - passDate;

                // Difference in days.  
                int differenceInDays = ts.Days;
                // ScriptManager.RegisterStartupScript(this, typeof(string), "alerta", "alert('" + differenceInDays.ToString() + "');", true);

                if (differenceInDays >= 90)
                {
                    // Response.Redirect("/configurar/Contra.aspx");

                    Response.Redirect("http://www.maecco.net/kc/Pass.aspx");

                    // ScriptManager.RegisterStartupScript(this, typeof(string), "alerta", "alert('Necesita actualizar su contraseña por seguridad');", true);
                }

            }
            else
            {
                IsvcKioskoCliClient Manejador = new IsvcKioskoCliClient();
                //Guardar Fecha de pass      
                    Tabla MiTabla2 = Manejador.getEjecutaStoredProcedure1("setActualizarFechaPass", usuario.Rows[0]["Usuario"].ToString() + "|" + thisDay.ToShortDateString());

                if (MiTabla2 != null)
                {
                    //Response.Redirect("inicio/inicio.aspx");
                }
            }   

        }
    }
}