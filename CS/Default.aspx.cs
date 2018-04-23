using DevExpress.Spreadsheet;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ASPxSpreadsheet1_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var docId = Guid.NewGuid().ToString();
            var docPath = Server.MapPath("~/MonthlyBudget.xlsx");
            ASPxSpreadsheet1.Open(docId, DocumentFormat.Xlsx, () => File.ReadAllBytes(docPath));
        }
    }
    protected void ASPxSpreadsheet1_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        var callbakInfo = e.Parameter;
        if (String.IsNullOrWhiteSpace(callbakInfo))
            return;
        SetupProtection(callbakInfo);
    }
    public void SetupProtection(string command)
    {
        var activeSheet = ASPxSpreadsheet1.Document.Worksheets.ActiveWorksheet;
        if (activeSheet.IsProtected)
        {
            activeSheet.Unprotect("password");
        }
        activeSheet["$A:$XFD"].Protection.Locked = false;
        switch (command)
        {
            case "Protect Selection":
                activeSheet.Selection.Protection.Locked = true;
                break;
            case "Protect Sheet":
                activeSheet["$A:$XFD"].Protection.Locked = true;
                break;
            default:
                break;
        }
        activeSheet.Protect("password", WorksheetProtectionPermissions.Default);
    }
}