using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using wcfKioskoCli;

public partial class nomina_costosnomina : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["objusuario"] == null)
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("../default.aspx");
        }

        //CAMBIOS

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
        dsNominas.Tables[0].Columns.Add("iIdPeriodo");
        dsNominas.Tables[0].Columns.Add("Serie");
        dsNominas.Tables[0].Columns.Add("Tipo");
        dsNominas.Tables[0].Columns.Add("fkIidPeriodo");
        dsNominas.Tables[0].Columns.Add("iEstatusEmpleado");
        dsNominas.Tables[0].Columns.Add("iTipoNomina");
        //dsNominas.Tables[0].Columns.Add("fkiIdPeriodo");
        //dsNominas.Tables[0].Columns.Add("fkIidEmpleadoC");
        //dsNominas.Tables[0].Columns.Add("fkiIdEmpresa");
        //dsNominas.Tables[0].Columns.Add("fkiIdPuesto");
        //dsNominas.Tables[0].Columns.Add("fkIidDepartamento");
        //dsNominas.Tables[0].Columns.Add("iEstatusEmpleado");
        //dsNominas.Tables[0].Columns.Add("Edad");
        //dsNominas.Tables[0].Columns.Add("Puesto");
        //dsNominas.Tables[0].Columns.Add("Buque");
        ////dsNominas.Tables[0].Columns.Add("TipoInfonavit");
        ////dsNominas.Tables[0].Columns.Add("fvalor");
        ////dsNominas.Tables[0].Columns.Add("fSalarioBase");
        ////dsNominas.Tables[0].Columns.Add("fSalarioDiario");
        ////dsNominas.Tables[0].Columns.Add("fSalarioBC");
        ////dsNominas.Tables[0].Columns.Add("iDiasTrabajandos");
        ////dsNominas.Tables[0].Columns.Add("TipoIncapacidad");
        ////dsNominas.Tables[0].Columns.Add("iNumeroDias");
        ////dsNominas.Tables[0].Columns.Add("fSueltoBruto");
        ////dsNominas.Tables[0].Columns.Add("fExtraOcasional");




        try
        {
            Tabla tbNominas = Manejador.getEjecutaStoredProcedure1("getNominasMesAno", (cbomes.SelectedIndex + 1) + "|" + cboanio.Text);
            if (tbNominas != null)
            {
                DataTable dtNominas = clFunciones.convertToDatatable(tbNominas);
                for (int x = 0; x < dtNominas.Rows.Count; x++)
                {
                    String nombreEmpleado = "";
                    Tabla tbPeriodo = Manejador.getEjecutaStoredProcedure1("getPeriodoxId", dtNominas.Rows[x]["fkIidPeriodo"].ToString());
                    if (tbPeriodo != null)
                    {
                        DataTable dtPeriodo = clFunciones.convertToDatatable(tbPeriodo);
                        for (int y = 0; y < dtPeriodo.Rows.Count; y++)
                        {
                            //DataTable dtE = clFunciones.convertToDatatable(tbPeriodo);
                            dsNominas.Tables[0].Rows.Add(dtNominas.Rows[x]["fkIidPeriodo"].ToString(),
                                                dtNominas.Rows[x]["iEstatusEmpleado"].ToString(),
                                                dtNominas.Rows[x]["iTipoNomina"].ToString(),
                                                dtPeriodo.Rows[y]["dFechaPeriodo"],
                                                series(dtNominas.Rows[x]["iEstatusEmpleado"].ToString()),
                                                tipo(dtNominas.Rows[x]["iTipoNomina"].ToString()));



                        }


                    }



                }

                Session["dsPagos"] = dsNominas;
                dtgnominas.DataSource = dsNominas;
                Session["dsCostos"] = null;
                dtgcostos.DataSource = null;

            }
            else
            {
                Session["dsPagos"] = null;
                dtgnominas.DataSource = null;
                lblmensaje.Text = "Sin Nominas";
                Session["dsCostos"] = null;
                dtgcostos.DataSource = null;
            }
            dtgnominas.DataBind();
            dtgcostos.DataBind();
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

                wcfKioskoCli.IsvcKioskoCliClient Manejador = new IsvcKioskoCliClient();


                int id = Convert.ToInt32(e.CommandArgument);

                string Periodo = ((Label)dtgnominas.Rows[id].FindControl("lblPeriodo")).Text;
                string Serie = ((Label)dtgnominas.Rows[id].FindControl("lblSerie")).Text;
                string Tipo = ((Label)dtgnominas.Rows[id].FindControl("lblTipo")).Text;


                DataSet dsCosto = new DataSet();
                dsCosto.Tables.Add("Tabla");
                dsCosto.Tables[0].Columns.Add("iIdNomina");
                dsCosto.Tables[0].Columns.Add("EmpleadoC");
                dsCosto.Tables[0].Columns.Add("IMSS");
                dsCosto.Tables[0].Columns.Add("RCV");
                dsCosto.Tables[0].Columns.Add("INFONAVIT");
                dsCosto.Tables[0].Columns.Add("ISN");
                dsCosto.Tables[0].Columns.Add("TOTAL");





                Tabla tbNominas = Manejador.getEjecutaStoredProcedure1("getNominasPeriodoSerieTipo", Periodo + "|" + Serie + "|" + Tipo);
                    if (tbNominas != null)
                    {
                        DataTable dtNominas = clFunciones.convertToDatatable(tbNominas);
                        for (int x = 0; x < dtNominas.Rows.Count; x++)
                        {
                            
                                
                                    //DataTable dtE = clFunciones.convertToDatatable(tbPeriodo);
                            dsCosto.Tables[0].Rows.Add(dtNominas.Rows[x]["iIdNomina"],
                                                        dtNominas.Rows[x]["cNombreLargo"],
                                                        dtNominas.Rows[x]["fImssCS"],
                                                        dtNominas.Rows[x]["fRcvCS"],
                                                        dtNominas.Rows[x]["fInfonavitCS"],
                                                        dtNominas.Rows[x]["fIsnCS"],
                                                        dtNominas.Rows[x]["fTotalCostoSocial"]);



                                



                                //nombreEmpleado = dtE.Rows[0]["cNombre"].ToString();

                            



                        }

                        Tabla tbSumas = Manejador.getEjecutaStoredProcedure1("getNominasPeriodoSerieTipoSUMACOSTO", Periodo + "|" + Serie + "|" + Tipo);
                        if (tbSumas != null)
                        {
                            DataTable dtSumas = clFunciones.convertToDatatable(tbSumas);
                            for (int x = 0; x < dtSumas.Rows.Count; x++)
                            {
                                dsCosto.Tables[0].Rows.Add("10000",
                                                        "TOTAL",
                                                        dtSumas.Rows[x]["fImssCS"],
                                                        dtSumas.Rows[x]["fRcvCS"],
                                                        dtSumas.Rows[x]["fInfonavitCS"],
                                                        dtSumas.Rows[x]["fIsnCS"],
                                                        dtSumas.Rows[x]["fTotalCostoSocial"]);
                            }
                        
                        }



                        Session["dsCostos"] = dsCosto;
                        dtgcostos.DataSource = dsCosto;

                    }
                    else
                    {
                        Session["dsCostos"] = null;
                        dtgcostos.DataSource = null;
                        lblmensaje.Text = "Sin Nominas";

                    }
                    dtgcostos.DataBind();

            }

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



    public String series(String tipo)
    {
        switch (tipo)
        {
            case "0": return "A";
            case "1": return "B";
            case "2": return "C";
            case "3": return "D";
            case "4": return "E";
            default: return "A";

        }
    }
    public String tipo(String t)
    {
        switch (t)
        {
            case "0": return "Abordo";
            case "1": return "Descanso";

            default: return "Abordo";

        }
    }

}