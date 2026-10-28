<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="JobPortal.AdminDashborard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="direction: rtl; text-align: right; padding: 20px;">
        <h2 class="text-primary"><i class="glyphicon glyphicon-dashboard"></i> لوحة التحكم المركزية</h2>
        <hr />

        <div class="row text-center">
            <div class="col-md-3">
                <div class="panel panel-info" style="padding: 20px;">
                    <h3 id="hUsersCount" runat="server">0</h3>
                    <p>إجمالي المستخدمين</p>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-success" style="padding: 20px;">
                    <h3 id="hJobsCount" runat="server">0</h3>
                    <p>وظائف معروضة</p>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-warning" style="padding: 20px;">
                    <h3 id="hAppsCount" runat="server">0</h3>
                    <p>طلبات توظيف</p>
                </div>
            </div>
             <div class="col-md-3">
                <div class="panel panel-danger" style="padding: 20px;">
                    <h3 id="hCVsCount" runat="server">0</h3>
                    <p>سير ذاتية مرفوعة</p>
                </div>
            </div>
        </div>

        <div class="row" style="margin-top: 30px;">
            <div class="col-md-6">
                <div class="well">
                    <h4><i class="glyphicon glyphicon-list"></i> آخر الوظائف المضافة</h4>
                    <asp:GridView ID="gvLatestJobs" runat="server" CssClass="table table-condensed" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Title" HeaderText="الوظيفة" />
                            <asp:BoundField DataField="CreatedDate" HeaderText="التاريخ" DataFormatString="{0:dd/MM}" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnDeleteJob" runat="server" Text="حذف" CssClass="btn btn-xs btn-danger" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="col-md-6">
                <div class="well">
                    <h4><i class="glyphicon glyphicon-user"></i> مراقبة المستخدمين الجدد</h4>
                    <asp:GridView ID="gvRecentUsers" runat="server" CssClass="table table-condensed" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="الاسم" />
                            <asp:BoundField DataField="Role" HeaderText="النوع" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkStatus" runat="server" Checked="true" Text="نشط" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
