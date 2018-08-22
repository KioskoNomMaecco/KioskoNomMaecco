﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using wcfKioskoCli;

public partial class nomina_nomina : System.Web.UI.Page
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
            


        }
    }

    //private void cargar_empresas()
    //{
    //    IsvcKioskoCliClient Manejador = new IsvcKioskoCliClient();

    //    Tabla TablaEmpresas = Manejador.getEjecutaStoredProcedure1("getListadoEmpresaCliente", Session["idusuario"].ToString());
    //    cboempresas.Items.Clear();

    //    if (TablaEmpresas != null)
    //    {
    //        DataTable dtEmpresas = clFunciones.convertToDatatable(TablaEmpresas);
    //        for (int x = 0; x < dtEmpresas.Rows.Count; x++)
    //        {
    //            cboempresas.Items.Add(new ListItem(dtEmpresas.Rows[x]["nombre"].ToString(), dtEmpresas.Rows[x]["iIdEmpresa"].ToString()));
    //        }
    //    }
    //    else
    //    {
    //        cboempresas.Items.Add(new ListItem("Sin Empresas", "-1"));

    //    }
    //}


    protected void cmdbuscar_Click(object sender, EventArgs e)
    {
        lblmensaje.Text = "";

        cargar_grid();
    }

    private void cargar_grid()
    {
        wcfKioskoCli.IsvcKioskoCliClient Manejador = new IsvcKioskoCliClient();



        DataSet dsNominas = new DataSet();
        dsNominas.Tables.Add("Tabla");
        dsNominas.Tables[0].Columns.Add("iIdNomina");
        dsNominas.Tables[0].Columns.Add("fkiIdPeriodo");
        dsNominas.Tables[0].Columns.Add("fkIidEmpleadoC");
        dsNominas.Tables[0].Columns.Add("fkiIdEmpresa");
        dsNominas.Tables[0].Columns.Add("fkiIdPuesto");
        dsNominas.Tables[0].Columns.Add("fkIidDepartamento");
        dsNominas.Tables[0].Columns.Add("iEstatusEmpleado");
        dsNominas.Tables[0].Columns.Add("Edad");
        dsNominas.Tables[0].Columns.Add("Puesto");
        dsNominas.Tables[0].Columns.Add("Buque");
        //dsNominas.Tables[0].Columns.Add("TipoInfonavit");
        //dsNominas.Tables[0].Columns.Add("fvalor");
        //dsNominas.Tables[0].Columns.Add("fSalarioBase");
        //dsNominas.Tables[0].Columns.Add("fSalarioDiario");
        //dsNominas.Tables[0].Columns.Add("fSalarioBC");
        //dsNominas.Tables[0].Columns.Add("iDiasTrabajandos");
        //dsNominas.Tables[0].Columns.Add("TipoIncapacidad");
        //dsNominas.Tables[0].Columns.Add("iNumeroDias");
        //dsNominas.Tables[0].Columns.Add("fSueltoBruto");
        //dsNominas.Tables[0].Columns.Add("fExtraOcasional");




        try
        {
            Tabla tbNominas = Manejador.getEjecutaStoredProcedure1("getNominasMesAno", (cbomes.SelectedIndex + 1) + "|" + cboanio.Text);
            if (tbNominas != null)
            {
                DataTable dtNominas = clFunciones.convertToDatatable(tbNominas);
                for (int x = 0; x < dtNominas.Rows.Count; x++)
                {
                    String nombreEmpleado="";
                     //Tabla tbEmpleado = Manejador.getEjecutaStoredProcedure1("getEmpleadoxID", dtNominas.Rows[x]["fkiIdEmpleadoC"].ToString());
                     //if (tbEmpleado != null)
                     //{
                     //     DataTable dtE = clFunciones.convertToDatatable(tbEmpleado);
                     //     nombreEmpleado = dtE.Rows[0]["cNombre"].ToString();

                     //}

                    dsNominas.Tables[0].Rows.Add(dtNominas.Rows[x]["fkIid"],
                                                    dtNominas.Rows[x]["fkiIdPeriodo"],
                                                    nombreEmpleado,
                                                    dtNominas.Rows[x]["Puesto"],
                                                    dtNominas.Rows[x]["Buque"]);



                }

                Session["dsPagos"] = dsNominas;
                dtgnominas.DataSource = dsNominas;

            }
            else
            {
                Session["dsPagos"] = null;
                dtgnominas.DataSource = null;
                lblmensaje.Text = "Sin Nominas";

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
                string archivo = ((Label)dtgnominas.Rows[id].FindControl("fkIidEmpleadoC")).Text;

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