<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Jobs.aspx.cs" Inherits="JobPortal.Jobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <div style="padding: 20px; direction: rtl; text-align: right;">
    <h2>الوظائف المتاحة حالياً</h2>
    <hr />

    <asp:GridView ID="gvJobs" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" Width="100%">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="المسمى الوظيفي" />
            <asp:BoundField DataField="Location" HeaderText="الموقع" />
            <asp:BoundField DataField="Salary" HeaderText="الراتب" />
            <asp:BoundField DataField="CreatedDate" HeaderText="تاريخ النشر" DataFormatString="{0:yyyy-MM-dd}" />
            
            <asp:TemplateField HeaderText="التفاصيل">
                <ItemTemplate>
                    <asp:HyperLink ID="hlDetails" runat="server" 
                        NavigateUrl='<%# "JobDetails.aspx?id=" + Eval("JobId") %>' 
                        Text="عرض التفاصيل" CssClass="btn btn-info btn-sm" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Label ID="lblInfo" runat="server"></asp:Label>
</div>
</asp:Content>
