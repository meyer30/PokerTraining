<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PokerTraining.WebForm1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        POKER APP<br />
        <br />
        <br />
        <asp:Table ID="TablePocket" runat="server" BorderStyle="Solid" CellPadding="0" CellSpacing="1" GridLines="Both" Width="285px">
            <asp:TableRow>
                <asp:TableCell>Pocket Card 1</asp:TableCell>
                <asp:TableCell>Pocket Card 2</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
        <br />
        <br />
        <asp:Table ID="TableCommunity" runat="server" BorderStyle="Solid" CellPadding="0" CellSpacing="1" GridLines="Both" Width="649px">
            <asp:TableRow>
                <asp:TableCell>Flop 1</asp:TableCell>
                <asp:TableCell>Flop 2</asp:TableCell>
                <asp:TableCell>Flop 3</asp:TableCell>
                <asp:TableCell>Turn</asp:TableCell>
                <asp:TableCell>River</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
        <br />
    
        <br />
        <asp:Table ID="TablePotOdds" runat="server" BorderStyle="Solid" CellPadding="0" CellSpacing="1" GridLines="Both" Width="287px">
            <asp:TableRow>
                <asp:TableCell>Bet to Call</asp:TableCell>
                <asp:TableCell>Pot Total</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
        <br />
        <br />
    
        <asp:DropDownList ID="ddlNumCommCards" runat="server">
            <asp:ListItem Text="Flop" Value="3"></asp:ListItem>
            <asp:ListItem Text="Turn" Value="4"></asp:ListItem>
            <asp:ListItem Text="River" Value="5"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnDeal" runat="server" Text="Deal" OnClick="btn_Click" />
        <asp:Button ID="btnCall" runat="server" Text="Call" OnClientClick="CallBtn_Click()" />
        <asp:Button ID="btnFold" runat="server" Text="Fold" OnClick="btn_Click" />
        <br />
        <br />
<%--        <asp:Table ID="TableResults" runat="server" BorderStyle="Solid" CellPadding="0" CellSpacing="1" GridLines="Both" Width="287px">
            <asp:TableRow>
                <asp:TableCell>Pot Odds</asp:TableCell>
                <asp:TableCell>Percent Win</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    --%>
        <br />
    </div>
        <script type="text/javascript" src="Scripts/DefaultBehavior.js"></script>

<%--        <asp:ScriptManager runat="server" ID="scriptManager1" EnablePageMethods="true">
        <Scripts>
            <asp:ScriptReference Path="~/DefaultBehavior.js" />
        </Scripts>
</asp:ScriptManager>--%>
    </form>
</body>
</html>
