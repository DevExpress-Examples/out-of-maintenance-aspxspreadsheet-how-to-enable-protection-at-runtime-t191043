<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxSpreadsheet.v15.2, Version=15.2.20.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpreadsheet" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.20.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASPxSpreadsheet - How to enable protection at runtime</title>
    <script>
        function OnClick(s, e) {
            spreadsheet.PerformCallback(s.GetText());
        }       
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxButton Text="Protect Selection" ID="btn1" AutoPostBack="false" runat="server">
            <ClientSideEvents Click="OnClick" />
        </dx:ASPxButton>     
        <dx:ASPxButton Text="Protect Sheet" ID="btn3" AutoPostBack="false" runat="server">
             <ClientSideEvents Click="OnClick" />
        </dx:ASPxButton>
        <dx:ASPxSpreadsheet ID="ASPxSpreadsheet1" runat="server"  Width="1000px" Height="800px"  OnCallback="ASPxSpreadsheet1_Callback" ClientInstanceName="spreadsheet" OnInit="ASPxSpreadsheet1_Init">

        </dx:ASPxSpreadsheet>
    </form>
</body>
</html>