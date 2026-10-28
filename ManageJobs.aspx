<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageJobs.aspx.cs" Inherits="JobPortal.ManageJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <div style="padding: 20px; direction: rtl; text-align: right;">
    <h2>إدارة وظائفي المنشورة</h2>
    <hr />
    <asp:GridView ID="gvMyJobs" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" Width="100%">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="اسم الوظيفة" />
            <asp:BoundField DataField="CreatedDate" HeaderText="تاريخ النشر" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:TemplateField HeaderText="المتقدمين">
                <ItemTemplate>
                    <asp:HyperLink ID="hlViewApps" runat="server" 
                        NavigateUrl='<%# "ViewApplications.aspx?jobid=" + Eval("JobId") %>' 
                        Text="عرض المتقدمين"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>


</asp:Content>
