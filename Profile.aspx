<%@ Page Title="ملفي الشخصي" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="JobPortal.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .cv-section {
            background-color: #f9f9f9;
            padding: 15px;
            border-radius: 8px;
            border-right: 5px solid #3498db;
            margin-bottom: 30px;
        }
        .upload-btn {
            background-color: #3498db;
            color: white;
            border: none;
            padding: 8px 20px;
            border-radius: 4px;
            cursor: pointer;
            transition: background 0.3s;
        }
        .upload-btn:hover { background-color: #2980b9; }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="direction: rtl; text-align: right; padding: 20px; background: white; border-radius: 10px; box-shadow: 0 4px 6px rgba(0,0,0,0.1);">
        
        <div class="row">
            <div class="col-md-12">
                <h2 style="color: #2c3e50;">
                    <i class="glyphicon glyphicon-user"></i> ملفي الشخصي
                </h2>
                <hr />
                <h4>مرحباً، <asp:Label ID="lblUserName" runat="server" CssClass="text-primary" Font-Bold="true"></asp:Label></h4>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="cv-section">
                    <h3 style="margin-top: 0;"><i class="glyphicon glyphicon-file"></i> السيرة الذاتية (CV)</h3>
                    <p style="color: #666;">ارفع سيرتك الذاتية مرة واحدة لتتمكن من التقديم على جميع الوظائف بضغطة زر.</p>
                    
                    <div style="margin: 15px 0;">
                        <asp:FileUpload ID="fuCV" runat="server" CssClass="form-control" style="width: auto; display: inline-block;" />
                        <asp:Button ID="btnUploadCV" runat="server" Text="حفظ السيرة الذاتية" OnClick="btnUploadCV_Click" CssClass="upload-btn" />
                    </div>
                    
                    <asp:Label ID="lblCVStatus" runat="server" Font-Bold="true" Text=""></asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <h3 style="border-bottom: 2px solid #f4f4f4; padding-bottom: 10px;">طلبات التوظيف السابقة</h3>
                <br />
                <asp:GridView ID="gvMyApplications" runat="server" AutoGenerateColumns="False" 
                    CssClass="table table-striped table-hover" GridLines="None" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="اسم الوظيفة" HeaderStyle-CssClass="text-right" ItemStyle-CssClass="text-right" />
                        <asp:BoundField DataField="Location" HeaderText="الموقع" HeaderStyle-CssClass="text-right" ItemStyle-CssClass="text-right" />
                        <asp:BoundField DataField="ApplyDate" HeaderText="تاريخ التقديم" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-CssClass="text-right" ItemStyle-CssClass="text-right" />
                        
                        <asp:TemplateField HeaderText="حالة الطلب">
                            <ItemTemplate>
                                <asp:Label ID="lblStatusTest" runat="server" Text='<%# Eval("Status") %>' 
                                    style="padding: 3px 10px; border-radius: 12px; color: green;"
                                    CssClass='<%# GetStatusLabelClass(Eval("Status")) %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
                <asp:Panel ID="pnlNoData" runat="server" Visible="false" CssClass="alert alert-info text-center">
                    لا توجد طلبات تقديم حالية. ابدأ بالبحث عن وظائف الآن!
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

