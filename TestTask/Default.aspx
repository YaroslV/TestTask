<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestTask._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="Label6" runat="server" Text="Enter ID"></asp:Label>
        <asp:TextBox ID="textBoxID" runat="server" Width="109px"></asp:TextBox>

        <asp:Button ID="ButtonFind" runat="server" Height="35px" OnClick="Button1_Click" Text="Find" Width="52px" />
        <br/>
        <asp:Label ID="TitleFNameLName" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
        <asp:TextBox ID="textBoxTitle" runat="server" Width="109px"></asp:TextBox>  
        <br />
        <asp:Label ID="Label2" runat="server" Text="First Name"></asp:Label>
        <asp:TextBox ID="textBoxFirstName" runat="server" Width="109px"></asp:TextBox>        
        <br />
        <asp:Label ID="Label3" runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox ID="textBoxLastName" runat="server" Width="109px" Height="16px"></asp:TextBox>        
        <br />
        <br />
        <asp:GridView ID="GridViewTypeEmailNote" runat="server" >
        </asp:GridView>
        <br />      
        <asp:Label ID="Label4" runat="server" Text="Date of birth"></asp:Label>
        &nbsp;<asp:TextBox ID="TextBoxDateOfBirth" runat="server" Height="16px" Width="97px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label5" runat="server" Text="Age"></asp:Label>
        &nbsp;<asp:TextBox ID="TextBoxAge" runat="server"></asp:TextBox>
        <br />
    </asp:Panel>
    
</asp:Content>
