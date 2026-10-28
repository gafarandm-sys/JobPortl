<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="JobPortal._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron text-center" style="background: linear-gradient(135deg, #2c3e50, #3498db); color: white; padding: 60px 20px; border-radius: 15px; margin-bottom: 30px;">
        <h3>  اهلا بك يا<asp:Label ID="lblUser" runat="server"></asp:Label> </h3>
        <h1 style="font-weight: bold;">مرحباً بك في منصة وظيفتي</h1>
        <p style="font-size: 20px;">الوجهة الأولى للباحثين عن عمل وأصحاب الشركات في السودان</p>
        <p>
            <asp:LinkButton ID="btnAction" runat="server" OnClick="btnAction_Click" 
        CssClass="btn btn-warning btn-lg" style="border-radius: 25px; padding: 10px 30px; text-decoration:none;">
        ابدأ الآن
    </asp:LinkButton>
        </p>
        
    </div>

    <div class="row text-center" style="margin-bottom: 40px;">
        <div class="col-md-4">
            <div style="padding: 20px; background: white; border-radius: 10px; box-shadow: 0 4px 6px rgba(0,0,0,0.05);">
                <i class="glyphicon glyphicon-briefcase" style="font-size: 40px; color: #3498db;"></i>
                <h3 style="font-weight: bold;">+500</h3>
                <p class="text-muted">وظيفة متاحة حالياً</p>
            </div>
        </div>
        <div class="col-md-4">
            <div style="padding: 20px; background: white; border-radius: 10px; box-shadow: 0 4px 6px rgba(0,0,0,0.05);">
                <i class="glyphicon glyphicon-user" style="font-size: 40px; color: #27ae60;"></i>
                <h3 style="font-weight: bold;">+2000</h3>
                <p class="text-muted">باحث عن عمل مسجل</p>
            </div>
        </div>
        <div class="col-md-4">
            <div style="padding: 20px; background: white; border-radius: 10px; box-shadow: 0 4px 6px rgba(0,0,0,0.05);">
                <i class="glyphicon glyphicon-home" style="font-size: 40px; color: #f39c12;"></i>
                <h3 style="font-weight: bold;">+150</h3>
                <p class="text-muted">شركة ومؤسسة</p>
            </div>
        </div>
    </div>

    <div class="row" style="padding: 40px 0;">
        <h2 class="text-center" style="margin-bottom: 30px;">كيف تبدأ مع وظيفتي؟</h2>
        <div class="col-md-4 text-center">
            <span class="badge" style="background: #3498db; font-size: 20px; padding: 10px 15px; border-radius: 50%;">1</span>
            <h4>أنشئ حسابك</h4>
            <p>سجل كباحث عن عمل أو صاحب عمل مجاناً</p>
        </div>
        <div class="col-md-4 text-center">
            <span class="badge" style="background: #3498db; font-size: 20px; padding: 10px 15px; border-radius: 50%;">2</span>
            <h4>ابحث عن فرص</h4>
            <p>استخدم محرك البحث المتطور للوصول للوظيفة المناسبة</p>
        </div>
        <div class="col-md-4 text-center">
            <span class="badge" style="background: #3498db; font-size: 20px; padding: 10px 15px; border-radius: 50%;">3</span>
            <h4>قدم بضغطة زر</h4>
            <p>ارسل طلبك مباشرة لصاحب العمل وتابع حالة طلبك</p>
        </div>
    </div>
</asp:Content>


