<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Código que se ejecuta al iniciarse la aplicación

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Código que se ejecuta cuando se cierra la aplicación

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Código que se ejecuta al producirse un error no controlado

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Código que se ejecuta cuando se inicia una nueva sesión
        Session["objusuario"] = null;
        Session["idusuario"] = "";
        Session["dsPagos"] = new System.Data.DataSet();
        Session["dsCostos"] = new System.Data.DataSet();
        Session["dsNominas"] = new System.Data.DataSet();
        //Session["dsAnticipo"] = new System.Data.DataSet();
        //Session["dsViaje"] = new System.Data.DataSet();
        Session["idtmp"] = "";
        Session["idcodigo"] = "";
        Session["ruta"] = "";
        Session["archivo"] = "";
     //   Session["fkiIdCliente"] = ""; 

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Código que se ejecuta cuando finaliza una sesión. 
        // Nota: El evento Session_End se desencadena sólo con el modo sessionstate
        // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer 
        // o SQLServer, el evento no se genera.

    }
       
</script>
