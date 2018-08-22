using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using wcfKioskoCli;


public partial class contabilidad_declaraciones : System.Web.UI.Page
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
            cargar_empresas();


        }
    }

    private void cargar_empresas()
    {
        IsvcKioskoCliClient Manejador = new IsvcKioskoCliClient();

        Tabla TablaEmpresas = Manejador.getEjecutaStoredProcedure1("getListadoEmpresaCliente", Session["idusuario"].ToString());
        cboempresas.Items.Clear();

        if (TablaEmpresas != null)
        {
            DataTable dtEmpresas = clFunciones.convertToDatatable(TablaEmpresas);
            for (int x = 0; x < dtEmpresas.Rows.Count; x++)
            {
                cboempresas.Items.Add(new ListItem(dtEmpresas.Rows[x]["nombre"].ToString(), dtEmpresas.Rows[x]["iIdEmpresa"].ToString()));
            }
        }
        else
        {
            cboempresas.Items.Add(new ListItem("Sin Empresas", "-1"));

        }
    }

    protected void cmdbuscar_Click(object sender, EventArgs e)
    {
        lblmensaje.Text = "";

        cargar_grid();
    }

    private void cargar_grid()
    {
        wcfKioskoCli.IsvcKioskoCliClient Manejador = new IsvcKioskoCliClient();



        DataSet dsEmpresas = new DataSet();
        dsEmpresas.Tables.Add("Tabla");
        dsEmpresas.Tables[0].Columns.Add("iIdInfoKiosko");
        dsEmpresas.Tables[0].Columns.Add("anio");
        dsEmpresas.Tables[0].Columns.Add("mes");
        dsEmpresas.Tables[0].Columns.Add("fecha");
        dsEmpresas.Tables[0].Columns.Add("nombrearchivo");





        try
        {
            Tabla tbEmpresas = Manejador.getEjecutaStoredProcedure1("getDeclaracionesMesAno_KC", Session["idusuario"].ToString() + "|" + cboempresas.SelectedValue + "|" + (cbomes.SelectedIndex + 1) + "|" + cboanio.Text);
            if (tbEmpresas != null)
            {
                DataTable dtEmpresas = clFunciones.convertToDatatable(tbEmpresas);
                for (int x = 0; x < dtEmpresas.Rows.Count; x++)
                {
                    dsEmpresas.Tables[0].Rows.Add(dtEmpresas.Rows[x]["iIdInfoKiosko"],
                                                    dtEmpresas.Rows[x]["anio"],
                                                    dtEmpresas.Rows[x]["mes"],
                                                    DateTime.Parse(dtEmpresas.Rows[x]["fecha"].ToString()).ToShortDateString(),
                                                    dtEmpresas.Rows[x]["nombrearchivo"]);



                }

                Session["dsPagos"] = dsEmpresas;
                dtgnominas.DataSource = dsEmpresas;

            }
            else
            {
                Session["dsPagos"] = null;
                dtgnominas.DataSource = null;
                lblmensaje.Text = "Sin Documentos";

            }
            dtgnominas.DataBind();

        }
        catch (Exception EX)
        {
            clFunciones.JQMensaje(this, EX.Message.Replace("'", ""), TipoMensaje.Error);
        }

    }

    protected void dtgnominas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Select")
            {
                int id = Convert.ToInt32(e.CommandArgument);


                //DateTime fecha = DateTime.Parse(((Label)dtgnominas.Rows[id].FindControl("lblfecha")).Text);
                string archivo = ((Label)dtgnominas.Rows[id].FindControl("nombrearchivo")).Text;

                Session["ruta"] = "infodown/" + archivo;
                String path = Server.MapPath("../infodown") + "\\" + archivo;
                String path2 = "../infodown/" + archivo;



                Session["archivo"] = archivo;

                System.IO.FileInfo toDownload = new System.IO.FileInfo(path);
                if (toDownload.Exists)
                {
                    Response.Redirect("../descarga.aspx", false);
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + path2  + "','_blank')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('No se encuentra el archivo ');", true);

                }

            }
            //if (e.CommandName == "Delete")
            //{
            //    int id = Convert.ToInt32(e.CommandArgument);


            //    //DateTime fecha = DateTime.Parse(((Label)dtgnominas.Rows[id].FindControl("lblfecha")).Text);
            //    string sindicato = ((Label)dtgnominas.Rows[id].FindControl("lbldpagosin")).Text;

            //    Session["ruta"] = "pagosn/" + sindicato + ".pdf";
            //    String path = Server.MapPath("../pagosn") + "\\" + sindicato + ".pdf";
            //    String path2 = "../pagosn/" + sindicato + ".pdf";
            //    Session["archivo"] = sindicato + ".pdf";
            //    System.IO.FileInfo toDownload = new System.IO.FileInfo(path);
            //    if (toDownload.Exists)
            //    {
            //        Response.Redirect("../descargar.aspx", true);
            //        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + path2 + "','_blank')", true);
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "mensaje('No se encuentra el archivo ');", true);

            //    }

            //}

        }
        catch (Exception EX)
        {
            clFunciones.JQMensaje(this, EX.Message.Replace("'", ""), TipoMensaje.Error);
        }
    }



    protected void dtgnominas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dtgnominas.DataSource = (DataSet)Session["dsPagos"];
        dtgnominas.PageIndex = e.NewPageIndex;
        dtgnominas.DataBind();
    }

    protected void dtgnominas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}