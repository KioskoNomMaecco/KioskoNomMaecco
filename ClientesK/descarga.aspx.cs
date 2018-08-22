using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class descarga : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Download(Session["ruta"].ToString());

        string path = Server.MapPath(Session["ruta"].ToString()) + "\\" + Session["archivo"].ToString();

        System.IO.FileInfo toDownload = new System.IO.FileInfo(path);
        Response.ClearContent();
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment; filename=" + Session["archivo"].ToString().Replace(" ", "") + ";");
        //Response.AddHeader("Content-Length", toDownload.Length.ToString());
        Response.ContentType = "application/octet-stream";

        //Response.WriteFile(Session["ruta"].ToString());
        Response.TransmitFile(Session["ruta"].ToString());
        Response.Flush();
        Response.End();
    }
}