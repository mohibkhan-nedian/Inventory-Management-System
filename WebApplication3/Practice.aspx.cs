using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WebApplication3
{
    public partial class Practice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string UploadFolderPath = "~/Uploads/";

        protected void FileUploadComplete(object sender, EventArgs e)
        {
            string filename = System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
            AsyncFileUpload1.SaveAs(Server.MapPath(this.UploadFolderPath) + filename);
        }
    }
}