<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JobDetails.aspx.cs" Inherits="JobPortal.JobDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <div style="padding: 20px; max-width: 700px; margin: auto; direction: rtl; text-align: right; border: 1px solid #ddd; border-radius: 10px;">
    <h2 style="color: #2c3e50;"><asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
    <hr />
    
    <p><strong>الموقع:</strong> <asp:Label ID="lblLocation" runat="server"></asp:Label></p>
    <p><strong>الراتب:</strong> <asp:Label ID="lblSalary" runat="server"></asp:Label> جنيه</p>
    <p><strong>تاريخ النشر:</strong> <asp:Label ID="lblDate" runat="server"></asp:Label></p>
    
    <div style="background: #f9f9f9; padding: 15px; border-radius: 5px;">
        <p><strong>وصف الوظيفة:</strong></p>
        <asp:Label ID="lblDesc" runat="server"></asp:Label>
    </div>
    
    <br />
    <asp:Button ID="btnApply" runat="server" Text="التقديم لهذه الوظيفة الآن" 
        CssClass="btn btn-success btn-lg" OnClick="btnApply_Click" Visible="false" />
    
    <hr />
    <asp:Label ID="lblMsg" runat="server" Font-Bold="true"></asp:Label>
</div>
</asp:Content>
