<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PokerTraining.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="DefaultBehavior.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            POKER APP<asp:ScriptManager runat="server" ID="scriptManager1" EnablePageMethods="true">
            <Scripts>
                <%--            <asp:ScriptReference Path="~/DefaultBehavior.js" />--%>
            </Scripts>
            <Services>
                <asp:ServiceReference Path="~/WebService1.asmx" />
            </Services>
        </asp:ScriptManager>
            <br />
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
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            </asp:UpdatePanel>
            <br />

            <asp:DropDownList ID="ddlNumCommCards" runat="server">
                <asp:ListItem Text="Flop" Value="3"></asp:ListItem>
                <asp:ListItem Text="Turn" Value="4"></asp:ListItem>
                <asp:ListItem Text="River" Value="5"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnDeal" runat="server" Text="Deal" OnClick="btn_Click" />
            <asp:Button ID="btnCall" runat="server" Text="Call" OnClientClick="return CallBtn_Click()" />
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

        <%--    <asp:scriptmanager enablepagemethods="true" id="scpt" runat="server"> </asp:scriptmanager>--%>
    </form>
</body>
</html>
