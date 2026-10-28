<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageCVs.aspx.cs" Inherits="JobPortal.ManageCVs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="direction: rtl; text-align: right; padding: 20px;">
        <h3><i class="glyphicon glyphicon-folder-open"></i> إدارة السير الذاتية المركزية</h3>
        
        <div class="well" style="margin-top: 20px;">
            <div class="row">
                <div class="col-md-4">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="بحث باسم المتقدم..."></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnSearch" runat="server" Text="بحث" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
            </div>
        </div>

        <asp:GridView ID="gvAllCVs" runat="server" AutoGenerateColumns="False" 
            CssClass="table table-bordered table-hover bg-white" Width="100%">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="اسم المتقدم" />
                <asp:BoundField DataField="Email" HeaderText="البريد الإلكتروني" />
                <asp:TemplateField HeaderText="السيرة الذاتية">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkView" runat="server" NavigateUrl='<%# Eval("FilePath") %>' 
                            Text="📁 فتح الملف" Target="_blank" CssClass="btn btn-default btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="إجراءات">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" runat="server" Text="حذف" 
                            CommandArgument='<%# Eval("CVId") %>' OnClientClick="return confirm('هل أنت متأكد من حذف هذا الملف؟')"
                            CssClass="text-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
