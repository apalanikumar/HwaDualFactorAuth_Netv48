<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="HwaDualFactorAuth_Netv48.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <strong>Support:</strong>   <a href="http://localhost:59921/swagger/index.html">Support@example.com</a><br />
        <asp:HyperLink ID="link" runat="server" Text="http://localhost:59921/swagger/index.html"></asp:HyperLink>
    </main>
</asp:Content>
