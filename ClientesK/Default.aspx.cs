using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using wcfKioskoCli;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void cmdaceptar_Click(object sender, EventArgs e)
    {
        try
        {
            Session["objusuario"] = "";
            Session["idusuario"] = "";
            Session["idtmp"] = "";
            Session["usuario"] = "";

            IsvcKioskoCliClient Manejador = new IsvcKioskoCliClient();
            Tabla MiTabla = Manejador.getEjecutaStoredProcedure1("getvalidarusuario_KC", txtusuario.Text + "|" + txtcontra.Text);
            if (MiTabla != null)
            {
                DataTable dtusuario = clFunciones.convertToDatatable(MiTabla);

                //if (dtusuario.Rows[0]["iEstatus"].ToString() == "2")
                //    {

                //        Response.Redirect("Buscar.aspx");

                //    }
                //    else
                //    {
 
                        if (dtusuario.Rows[0]["verificaremail"].ToString() == "0")
                        {
                            Session["objusuario"] = dtusuario;
                            //Session["idusuario"] = dtusuario.Rows[0]["fkiIdCliente"].ToString();
                            Session["idtmp"] = dtusuario.Rows[0]["iIdUsuarioK"].ToString();
                             Session["usuario"] = dtusuario.Rows[0]["usuario"].ToString();
                             Response.Redirect("ValidarEmail.aspx");
                        }
                        else
                        {

                            Session["objusuario"] = dtusuario;
                            //Session["idusuario"] = dtusuario.Rows[0]["fkiIdCliente"].ToString();
                            Session["idtmp"] = dtusuario.Rows[0]["iIdUsuarioK"].ToString();
                            Session["usuario"] = dtusuario.Rows[0]["usuario"].ToString();
                       
                            Response.Redirect("inicio/inicio.aspx");

                            //ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Usuario correcto');", true);
                        }
                    }

            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Usuario o contraseña incorrecta');", true);
            //}


        }
        catch (Exception EX)
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('" + EX.Message + "');", true);
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Recuperar.aspx");

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Soporte.aspx");
    }
}