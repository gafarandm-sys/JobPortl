<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostJob.aspx.cs" Inherits="JobPortal.PostJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div style="padding: 20px; max-width: 600px; margin: auto; direction: rtl; text-align: right;">
    <h2>إضافة وظيفة جديدة</h2>
    <hr />
    
    <div class="form-group">
        <label>عنوان الوظيفة:</label>
        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtTitle" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <label>وصف الوظيفة:</label>
        <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
    </div>

    <div class="form-group">
        <label>الموقع (المدينة):</label>
        <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label>الراتب المتوقع:</label>
        <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
    </div>
    <br />
    <asp:Button ID="btnPost" runat="server" Text="نشر الوظيفة الآن" OnClick="btnPost_Click" CssClass="btn btn-primary" />
    <hr />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
</div>
</asp:Content>
