<%@ Page Title="" Language="C#" MasterPageFile="~/headsite.Master" AutoEventWireup="true" CodeBehind="webbtestquestion.aspx.cs" Inherits="Group3WebProject.webbtestquestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Frågorna</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Välkommen till test tryck på start för att påbörja</h2>
        <p>Obs tiden startas då du trycker på start </p>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label">Välj fråga: </asp:Label>
        <asp:DropDownList ID="alque" runat="server" CssClass="dropdown-toggle" OnSelectedIndexChanged="alque_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Spara" CssClass="btn-primary" />
    </div>
    <div id="qu">
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:RadioButtonList ID="queston" runat="server" OnUnload="queston_Unload"></asp:RadioButtonList>
    </div>
    <div>
        <asp:Button ID="btnPrevious" runat="server" Text="Föregående" OnClick="btnPrevious_Click" />&nbsp;&nbsp;&nbsp;<asp:Button ID="btnNext" runat="server" Text="Nästa" OnClick="btnNext_Click" />
    </div>
</asp:Content>
