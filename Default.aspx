<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HwaDualFactorAuth_Netv48._Default" %>

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
            <dt>Type the City Name here</dt>
            <dd>
                <asp:TextBox ID="txtCity" runat="server" Text="" />
                <asp:Button Text="Get Weather Information" runat="server" OnClick="GetWeatherInfo" />
                <asp:Label ID="lbl_alert" runat="server" ForeColor="Red" Visible="false" />
                <hr />
                <table id="tblWeather" runat="server" border="0" cellpadding="0" cellspacing="0"
                    visible="false">
                    <tr>
                        <th colspan="2">Weather Information
                        </th>
                    </tr>
                    <tr>
                        <td rowspan="3">
                            <asp:Image ID="imgWeatherIcon" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCity_Country" runat="server" />
                            <asp:Image ID="imgCountryFlag" runat="server" />
                            <asp:Label ID="lblDescription" runat="server" />
                            Humidity:
            <asp:Label ID="lblHumidity" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Temperature:
            (Min:
            <asp:Label ID="lblTempMin" runat="server" />
                            Max:
            <asp:Label ID="lblTempMax" runat="server" />
                            Day:
            <asp:Label ID="lblTempDay" runat="server" />
                            Night:
            <asp:Label ID="lblTempNight" runat="server" />)
                        </td>
                    </tr>
                </table>

            </dd>
            <% }
                else
                { %>
            <dd></dd>
            <% } %>
        </dl>
    </main>

</asp:Content>
