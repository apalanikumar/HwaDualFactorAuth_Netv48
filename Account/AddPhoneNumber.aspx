<%@ Page Title="Phone Number" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPhoneNumber.aspx.cs" Inherits="HwaDualFactorAuth_Netv48.Account.AddPhoneNumber" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h4>Add a phone number</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <div class="row">
            <asp:Label runat="server" AssociatedControlID="PhoneNumber" CssClass="col-md-2 col-form-label"> Select Country Code with Phone Number</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" Width ="25%" ></asp:DropDownList>
                <asp:TextBox runat="server" ID="PhoneNumber" CssClass="form-control" MaxLength="15" TextMode="Phone" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNumber"
                    CssClass="text-danger" ValidationExpression="^\s*\+?[0-9]\d?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$" ErrorMessage="The PhoneNumber field is required." />
                <asp:Label ID="lblphone" runat="server" Visible ="false" ForeColor="Red" Text =""></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <div class="offset-md-2 col-md-10">
                <asp:Button runat="server" OnClick="PhoneNumber_Click"
                    Text="Submit" CssClass="btn btn-outline-dark" />
            </div>
        </div>
    </main>
</asp:Content>
