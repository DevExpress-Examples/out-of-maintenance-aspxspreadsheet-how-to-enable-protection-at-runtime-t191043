Imports DevExpress.Spreadsheet
Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Protected Sub ASPxSpreadsheet1_Init(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            Dim docId = Guid.NewGuid().ToString()
            Dim docPath = Server.MapPath("~/MonthlyBudget.xlsx")
            ASPxSpreadsheet1.Open(docId, DocumentFormat.Xlsx, Function() File.ReadAllBytes(docPath))
        End If
    End Sub
    Protected Sub ASPxSpreadsheet1_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.CallbackEventArgsBase)
        Dim callbakInfo = e.Parameter
        If String.IsNullOrWhiteSpace(callbakInfo) Then
            Return
        End If
        SetupProtection(callbakInfo)
    End Sub
    Public Sub SetupProtection(ByVal command As String)
        Dim activeSheet = ASPxSpreadsheet1.Document.Worksheets.ActiveWorksheet
        If activeSheet.IsProtected Then
            activeSheet.Unprotect("password")
        End If
        activeSheet("$A:$XFD").Protection.Locked = False
        Select Case command
            Case "Protect Selection"
                activeSheet.Selection.Protection.Locked = True
            Case "Protect Sheet"
                activeSheet("$A:$XFD").Protection.Locked = True
            Case Else
        End Select
        activeSheet.Protect("password", WorksheetProtectionPermissions.Default)
    End Sub
End Class