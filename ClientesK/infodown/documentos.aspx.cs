using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using wcfKioskoCli;

using Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using System.Reflection;

using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Diagnostics;
using System.Drawing.Drawing2D;

public partial class imss_documentos : System.Web.UI.Page
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
            System.Data.DataTable dtEmpresas = clFunciones.convertToDatatable(TablaEmpresas);
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


        DataSet dsDocumento = new DataSet();
        dsDocumento.Tables.Add("Tabla");
        dsDocumento.Tables[0].Columns.Add("Cantidad");
        dsDocumento.Tables[0].Columns.Add("nombrearchivo");

        DataSet dsDoc = new DataSet();
        dsDoc.Tables.Add("Tabla");
        dsDoc.Tables[0].Columns.Add("iIdDocumentos");
        dsDoc.Tables[0].Columns.Add("Documentos");
        dsDoc.Tables[0].Columns.Add("cArea");
        dsDoc.Tables[0].Columns.Add("cPeriodicidad");
        dsDoc.Tables[0].Columns.Add("iEstatus");
        dsDoc.Tables[0].Columns.Add("iTMM");


        try
        {
            if (cboempresas.SelectedValue != "-1")
            {

                acuse(Manejador, dsDocumento, dsDoc);//, 1);

                //if(compararITMM()==true)
                //{
                //    acuse(Manejador, dsDocumento, dsDoc, 1);

                //}
                //else
                //{

                //    acuse(Manejador, dsDocumento, dsDoc, 0);
                //}


                dtgnominas.DataBind();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "mensaje",
            "alert('No tiene empresas!!!');", true);
            }



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
                //  string archivo = ((Label)dtgnominas.Rows[id].FindControl("nombrearchivo")).Text;
                string archivo = "ACUSE.docx";
                string archivo2 = "ACUSE_VALIDACION.pdf";
                //   Session["ruta"] = "infodown/" + archivo;
                String path = Server.MapPath("../infodown") + "\\" + archivo;
                String path2 = "../infodown/" + archivo;
                String patho = Server.MapPath("../infodown") + "\\" + "ACUSE_VALIDACION.pdf";


                CreateDoc(path, patho);
                Session["ruta"] = "infodown//" + archivo2;
                Session["archivo"] = archivo2;

                System.IO.FileInfo toDownload = new System.IO.FileInfo(patho);
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
          

        }
        catch (Exception EX)
        {
            // clFunciones.JQMensaje(this, EX.Message.Replace("'", ""), TipoMensaje.Error);
            ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('" + EX.ToString() + "');", true);

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

    public void selectArea(String area, string mensaje)
    {

        String patrona = " ";
        String cliente = " ";

        IsvcKioskoCliClient Manejador = new IsvcKioskoCliClient();

        Tabla TablaEmpresas = Manejador.getEjecutaStoredProcedure1("getEmpresaPatrona", cboempresas.SelectedValue);

        if (TablaEmpresas != null)
        {
            System.Data.DataTable dtEmpresas = clFunciones.convertToDatatable(TablaEmpresas);
            for (int x = 0; x < dtEmpresas.Rows.Count; x++)
            {
                patrona = dtEmpresas.Rows[x]["nombre"].ToString();
            }
        }
        Tabla TablaClientes = Manejador.getEjecutaStoredProcedure1("getEmpresaCliente", Session["idusuario"].ToString());

        if (TablaClientes != null)
        {
            System.Data.DataTable dtEmpresasC = clFunciones.convertToDatatable(TablaClientes);
            for (int x = 0; x < dtEmpresasC.Rows.Count; x++)
            {
                cliente = dtEmpresasC.Rows[x]["nombre"].ToString();
            }
        }


        String correo = " ", contacto = " ";

        switch (area)
        {
            case "Contabilidad":
                correo = "i.mendez@mbcgroup.mx";
                contacto = "C.P. Israel Mendez";
                break;
            case "IMSS":
                correo = "p.vicente@mbcgroup.mx";
                contacto = "C.P. Petrus Isidro";
                break;
            case "Nomina":
                correo = "e.flores@mbcgroup.mx";
                contacto = "C.P. Elliud Flores";
                break;
            default:
                correo = "soporte@mbcgroup.mx";
                contacto = "SOPORTE";
                break;


        }

        enviarCorreo("e.ruiz@mbcgroup.mx", contacto, mensaje , patrona , cliente);

    }

    public void enviarCorreo(String CorreoContacto, String nombreContacto, String status, String patrona, String cliente)
    {
        string acuseValidar = EnviarCorreos.acuseValidar(nombreContacto, cboarea.Text, status, patrona, cliente);
        string asuntoConfirmar = "ACUSE APLICATIVO DEL SAT" + "¡No se han subido todos los archivos" + "!";

        if (EnviarCorreos.enviarCorreo(CorreoContacto, acuseValidar, asuntoConfirmar) == false)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "mensaje",
            "alert('Error, no se pudo enviar el correo!!!');", true);
        }


    }

    private void CreateDoc(object filename, object savaAs)
    {
        List<int> processesbeforegen = KillProcesos.getRunningProcesses();
        object missing = Missing.Value;
        string tempPath = null;


        Word.Application wordApp = new Word.Application();

        Word.Document aDoc = null;

        if (File.Exists((String)filename))
        {
            DateTime today = DateTime.Now;

            object readOnly = false;
            object inVisible = false;

            wordApp.Visible = false;

            object format = Word.WdSaveFormat.wdFormatPDF;

            aDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing,
                                         ref missing, ref missing, ref missing, ref missing);

            aDoc.Activate();

            //Find and replace:
            this.FindAndReplace(wordApp, "<name>", cbomes.Text);


        }

        object format2 = Word.WdSaveFormat.wdFormatPDF;
        aDoc.SaveAs2(ref savaAs, ref format2, ref missing, ref missing,
                ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing);


        // aDoc.Close();
        //File.Delete(tempPath);

        List<int> processesaftergen = KillProcesos.getRunningProcesses();
        KillProcesos.killProcesses(processesbeforegen, processesaftergen);
    }

    //Methode Find and Replace:
    private void FindAndReplace(Microsoft.Office.Interop.Word.Application wordApp, object findText, String replaceWithText)
    {
        object mes = month(replaceWithText);
        object matchCase = true;
        object matchWholeWord = true;
        object matchWildCards = false;
        object matchSoundLike = false;
        object nmatchAllForms = false;
        object forward = true;
        object format = false;
        object matchKashida = false;
        object matchDiactitics = false;
        object matchAlefHamza = false;
        object matchControl = false;
        object read_only = false;
        object visible = true;
        object replace = 2;
        object wrap = 1;


        wordApp.Selection.Find.Execute(ref findText,
                    ref matchCase, ref matchWholeWord,
                    ref matchWildCards, ref matchSoundLike,
                    ref nmatchAllForms, ref forward,
                    ref wrap, ref format, ref mes,
                    ref replace, ref matchKashida,
                    ref matchDiactitics, ref matchAlefHamza,
                    ref matchControl);
    }



    public void acuse(wcfKioskoCli.IsvcKioskoCliClient Manejador, DataSet dsDocumento, DataSet dsDoc)//, Int16 iTMM)
    {
        Int32 ms = (cbomes.SelectedIndex + 1) % 2;

        
   
        switch (cboarea.SelectedIndex+1)
        {
            //Contabilidad
            case 1:
                Int32 tmp=conta();
                 
                Tabla cargados1 = Manejador.getEjecutaStoredProcedure1("getDocumentosCargadosConta", cboanio.Text + "|" + (cbomes.SelectedIndex + 1) + "|" + (cboarea.SelectedIndex + 1) + "|" + cboempresas.SelectedValue+ "|" + 0 + "|" + tmp + "|" + ms);

                Tabla docload = Manejador.getEjecutaStoredProcedure1("getDocumentosValidarConta", cboanio.Text + "|" + (cbomes.SelectedIndex + 1) + "|" + (cboarea.SelectedIndex + 1) + "|" + cboempresas.SelectedValue + "|" + 0 + "|" + tmp + "|" + ms);
                if (cargados1 != null)
                {
                     
                    if (docload != null)
                    {
                        System.Data.DataTable dtDoc = clFunciones.convertToDatatable(docload);
                        String value = dtDoc.Rows[0]["Cantidad"].ToString();
                      

                        //if (dtDoc.Rows.Count == 0)
                        if (Int32.Parse(value) == 0)
                        {
                            dsDocumento.Tables[0].Rows.Add(dtDoc.Rows[0]["Cantidad"], "Acuse de validación");

                            Session["dsPagos"] = dsDocumento;
                            dtgnominas.DataSource = dsDocumento;

                            Manejador.getEjecutaStoredProcedure1("setHistorialAcuse", Session["idusuario"].ToString() + "|" + cboempresas.SelectedValue + "|" + "NINGUNO" + "|" + cboarea.Text + "|" + DateTime.Now + "|" + 1);
                         
                        }
                        //else if (dtDoc.Rows.Count >= 1)
                        else if (Int32.Parse(value) >= 1)
                        {
                            Tabla documentosfail = Manejador.getEjecutaStoredProcedure1("getDocumentosConta", cboanio.Text + "|" + (cbomes.SelectedIndex + 1) + "|" + (cboarea.SelectedIndex + 1) + "|" + cboempresas.SelectedValue + "|" + 0 + "|" + tmp + "|" + ms);
                            String docfaltante = " ";

                            if (documentosfail != null)
                            {
                                System.Data.DataTable dtDoc2 = clFunciones.convertToDatatable(documentosfail);
                                for (int y = 0; y < dtDoc2.Rows.Count; y++)
                                {

                                    docfaltante += "<br />" + dtDoc2.Rows[y]["Documentos"].ToString();

                                }
                                dtgnominas.DataSource = null;
                                lblmensaje.Text = " ÁREA: <strong>" + cboarea.Text + "</strong>" + "<br>" + "DOCUMENTOS FALTANTES:<strong><br> " + docfaltante + "</strong>";
                                selectArea(cboarea.Text, lblmensaje.Text);
                                Manejador.getEjecutaStoredProcedure1("setHistorialAcuse", Session["idusuario"].ToString() + "|" + cboempresas.SelectedValue + "|" + docfaltante.Replace("<br>", ", ") + "|" + cboarea.Text + "|" + DateTime.Now + "|" + 0);
                            }

                        }
                    }
                }

                else
                {
                    dtgnominas.DataSource = null;
                    lblmensaje.Text = "Sin archivos cargados, en el área de " + cboarea.Text + ", en el mes de " + month(cbomes.Text) + " " + cboanio.Text;
                    selectArea(cboarea.Text, lblmensaje.Text);
                    Manejador.getEjecutaStoredProcedure1("setHistorialAcuse", Session["idusuario"].ToString() + "|" + cboempresas.SelectedValue + "|" +"TODOS" + "|" + cboarea.Text + "|" + DateTime.Now + "|" + 0);
                         
                }
                break;

            case 2:
                Int16 iTMM =compararITMM();

                Tabla docload2 = Manejador.getEjecutaStoredProcedure1("getDocumentosCargadosIMSS", cboanio.Text + "|" + (cbomes.SelectedIndex + 1) + "|" + (cboarea.SelectedIndex + 1) + "|" + cboempresas.SelectedValue + "|" + Session["idusuario"].ToString() + "|" + iTMM + "|" + ms);

                Tabla validar = Manejador.getEjecutaStoredProcedure1("getDocumentosValidar", cboanio.Text + "|" + (cbomes.SelectedIndex + 1) + "|" + (cboarea.SelectedIndex + 1) + "|" + cboempresas.SelectedValue + "|" + Session["idusuario"].ToString() + "|" + iTMM + "|" + ms);

                if (docload2 != null)
                {
                   System.Data.DataTable dtDoc = clFunciones.convertToDatatable(docload2);
 
                    System.Data.DataTable dtDocs = clFunciones.convertToDatatable(validar);
                    String value = dtDocs.Rows[0]["Cantidad"].ToString();

                    //if (dtDoc.Rows.Count == 10)
                    if (Int32.Parse(value) == 0)
                    {

                        dsDocumento.Tables[0].Rows.Add(dtDoc.Rows[0]["cArea"], "Acuse de validación");

                        Session["dsPagos"] = dsDocumento;
                        dtgnominas.DataSource = dsDocumento;

                        Manejador.getEjecutaStoredProcedure1("setHistorialAcuse", Session["idusuario"].ToString() + "|" + cboempresas.SelectedValue + "|" + "NINGUNO" + "|" + cboarea.Text + "|" + DateTime.Now + "|" + 1);
                            
                    }


                    else if (Int32.Parse(value) >= 1)
                    {
                        Tabla documentosfail = Manejador.getEjecutaStoredProcedure1("getDocumentos", cboanio.Text + "|" + (cbomes.SelectedIndex + 1) + "|" + (cboarea.SelectedIndex + 1) + "|" + cboempresas.SelectedValue + "|" + Session["idusuario"].ToString() + "|" + iTMM + "|" + ms);
                        String docfaltante = " ";
                       
                        if (documentosfail != null)
                        {
                            System.Data.DataTable dtDoc2 = clFunciones.convertToDatatable(documentosfail);
                            for (int y = 0; y < dtDoc2.Rows.Count; y++)
                            {

                                docfaltante += dtDoc2.Rows[y]["Documentos"].ToString()+ "<br>" ;
                               
                            }
                            dtgnominas.DataSource = null;
                            lblmensaje.Text = " ÁREA: <strong>" + cboarea.Text + "</strong>" + "<br>" + "DOCUMENTOS FALTANTES:<strong><br> " + docfaltante + "</strong>";
                            selectArea(cboarea.Text, lblmensaje.Text);
                            Manejador.getEjecutaStoredProcedure1("setHistorialAcuse", Session["idusuario"].ToString() + "|" + cboempresas.SelectedValue + "|" + docfaltante.Replace("<br>", ", ") + "|" + cboarea.Text + "|" + DateTime.Now + "|" + 0);
                       
                        }

                    }

                }
                else
                {
                    dtgnominas.DataSource = null;
                    lblmensaje.Text = "Sin archivos cargados, en el área de " + cboarea.Text + ", en el mes de " + month(cbomes.Text) + " " + cboanio.Text;
                    selectArea(cboarea.Text, lblmensaje.Text);
                    Manejador.getEjecutaStoredProcedure1("setHistorialAcuse", Session["idusuario"].ToString() + "|" + cboempresas.SelectedValue + "|" + "TODOS" + "|" + cboarea.Text + "|" + DateTime.Now + "|" + 0);
                        
                }
                break;

            case 3:
                Tabla cargados = Manejador.getEjecutaStoredProcedure1("getDocumentosCargados", cboanio.Text + "|" + (cbomes.SelectedIndex + 1) + "|" + (cboarea.SelectedIndex + 1) + "|" + cboempresas.SelectedValue + "|" + Session["idusuario"].ToString() + "|" + 0 + "|" + ms );
                if (cargados != null)
                {
                    Tabla docload3 = Manejador.getEjecutaStoredProcedure1("getDocumentosValidar", cboanio.Text + "|" + (cbomes.SelectedIndex + 1) + "|" + (cboarea.SelectedIndex + 1) + "|" + cboempresas.SelectedValue + "|" + Session["idusuario"].ToString() + "|" + 0 + "|" + ms);

                    //String periodicidad, tmm = " ";
                    if (docload3 != null)
                    {
                        System.Data.DataTable dtDoc = clFunciones.convertToDatatable(docload3);
                        String value = dtDoc.Rows[0]["Cantidad"].ToString();

                        System.Data.DataTable cargado = clFunciones.convertToDatatable(cargados);
 

                        //if (dtDoc.Rows.Count == 0)
                        if (Int32.Parse(value) == 0)
                        {
                            dsDocumento.Tables[0].Rows.Add(dtDoc.Rows[0]["Cantidad"], "Acuse de validación");


                            Session["dsPagos"] = dsDocumento;
                            dtgnominas.DataSource = dsDocumento;

                            Manejador.getEjecutaStoredProcedure1("setHistorialAcuse", Session["idusuario"].ToString() + "|" + cboempresas.SelectedValue + "|" + "NINGUNO" + "|" + cboarea.Text + "|" + DateTime.Now + "|" + 1);
                          

                        }
                        // else if (dtDoc.Rows.Count >= 1)
                        else if (Int32.Parse(value) >= 1)
                        {
                            Tabla documentosfail = Manejador.getEjecutaStoredProcedure1("getDocumentos", cboanio.Text + "|" + (cbomes.SelectedIndex + 1) + "|" + (cboarea.SelectedIndex + 1) + "|" + cboempresas.SelectedValue + "|" + Session["idusuario"].ToString() + "|" + 0 + "|" + ms);
                            String docfaltante = " ";

                            if (documentosfail != null)
                            {
                                System.Data.DataTable dtDoc2 = clFunciones.convertToDatatable(documentosfail);
                                for (int y = 0; y < dtDoc2.Rows.Count; y++)
                                {

                                    docfaltante += "<br />" + dtDoc2.Rows[y]["Documentos"].ToString();


                                }
                                dtgnominas.DataSource = null;
                                lblmensaje.Text = " ÁREA: <strong>" + cboarea.Text + "</strong>" + "<br>" + "DOCUMENTOS FALTANTES:<strong><br> " + docfaltante + "</strong>";
                                selectArea(cboarea.Text, lblmensaje.Text);

                                Manejador.getEjecutaStoredProcedure1("setHistorialAcuse", Session["idusuario"].ToString() + "|" + cboempresas.SelectedValue + "|" + docfaltante.Replace("<br>", ", ") + "|" + cboarea.Text + "|" + DateTime.Now +"|" + 0);
                            
                            }

                        }
                    }
                }

                else
                {
                    dtgnominas.DataSource = null;
                    lblmensaje.Text = "Sin archivos cargados, en el área de " + cboarea.Text + ", en el mes de " + month(cbomes.Text) + " " + cboanio.Text;

                    selectArea(cboarea.Text, lblmensaje.Text);

                    Manejador.getEjecutaStoredProcedure1("setHistorialAcuse", Session["idusuario"].ToString() + "|" + cboempresas.SelectedValue + "|" + "TODOS" + "|" + cboarea.Text + "|" + DateTime.Now + "|" + 0);
                            

                }

                break;

        }


    }//Fin Acuse

    public Int32 conta()
    {
        switch (cboempresas.SelectedValue)
        {
            case "49":return 49;
            case "48":return 48;
            case "14":return 14;
            case "15":return 15;
            case "16":return 15;
            case "17":return 15;
            case "59":return 22;
            case "37":return 22;
            case "22":return 22;
            case "74":return 22;
            case "25":return 25;
            case "18":return 18;
            case "19":return 18;
            case "69":return 18;
            case "6":return 6;
            case "12":return 12;
            case "50":return 50;
            case "29":return 29;
            case "13":return 13;
            case "11":return 11; 
            case "81":return 81;
            case "58":return 58;
            case "5":return 5;

            default: return 1;
        }

    }

    public Int16 compararITMM()
    {
        List<string> empresasTMM = new List<string>();
        //empresas clientes

        empresasTMM.Add("37");
        empresasTMM.Add("411");
        empresasTMM.Add("420");

        if (empresasTMM.Contains(Session["idusuario"].ToString()))
        {
            return 1;
        }else
        {
            return 0;
        }

    }
    public String month(String n)
    {
        String mes = "";
        switch (Int32.Parse(n))
        {
            case 1: mes = "Enero"; break;
            case 2: mes = "Febrero"; break;
            case 3: mes = "Marzo"; break;
            case 4: mes = "Abril"; break;
            case 5: mes = "Mayo"; break;
            case 6: mes = "Junio"; break;
            case 7: mes = "Julio"; break;
            case 8: mes = "Agosto"; break;
            case 9: mes = "Septiembre"; break;
            case 10: mes = "Octubre"; break;
            case 11: mes = "Noviembre"; break;
            case 12: mes = "Diciembre"; break;
            default: mes = " "; break;
        }
        return mes;
    }

}
