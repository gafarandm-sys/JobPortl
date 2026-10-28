<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewApplications.aspx.cs" Inherits="JobPortal.ViewApplications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <div style="padding: 20px; direction: rtl; text-align: right;">
    <h3>إدارة المتقدمين للوظيفة</h3>
    <hr />
    <asp:GridView ID="gvApplicants" runat="server" CssClass="table table-hover" 
        AutoGenerateColumns="False" OnRowCommand="gvApplicants_RowCommand">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="اسم المتقدم" />
            <asp:BoundField DataField="ApplyDate" HeaderText="تاريخ التقديم" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="Status" HeaderText="الحالة الحالية" />
            
            <asp:TemplateField HeaderText="اتخاذ إجراء">
                <ItemTemplate>
                    <asp:Button ID="btnAccept" runat="server" Text="قبول" CommandName="Accept" 
                        CommandArgument='<%# Eval("ApplicationId") %>' CssClass="btn btn-success btn-sm" />
                    
                    <asp:Button ID="btnReject" runat="server" Text="رفض" CommandName="Reject" 
                        CommandArgument='<%# Eval("ApplicationId") %>' CssClass="btn btn-danger btn-sm" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblActionMsg" runat="server" Font-Bold="true"></asp:Label>
</div>


   
</asp:Content>
