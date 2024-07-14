<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" Async="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HwaDualFactorAuth_Netv48._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Welcome to Two Factor Authentication Using SMS</h1>
        </section>
        <br />
        <hr />
        <dl class="dl-horizontal">
            <% if (User.Identity.IsAuthenticated)
                { %>
            <dd>
                <div>
                    <asp:Button Text="Get Data From SQL Server using Web API" runat="server" OnClick="DataLoad_Click" />
                     <br /> <br />
                    <asp:GridView ID="GridView1" runat="server" Width="100%"  AutoGenerateColumns="false" AllowPaging="true"
                        OnPageIndexChanging="OnPageIndexChanging" PageSize="10" CellPadding="6">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="250px" DataField="Id" HeaderText="Customer ID" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Email" HeaderText="Contact Email" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Phonenumber" HeaderText="Phone" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Username" HeaderText="User Name" />
                        </Columns>
                        <HeaderStyle BackColor="#0066cc" Font-Bold="true" ForeColor="White" />
                        <RowStyle BackColor="#bfdfff" ForeColor="Black" />
                    </asp:GridView>
                </div>
            </dd>
            <% }
                else
                { %>
            <dd></dd>
            <% } %>
        </dl>
    </main>

</asp:Content>
