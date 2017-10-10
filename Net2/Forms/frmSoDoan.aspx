<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmMaster.Master" AutoEventWireup="true" CodeBehind="frmSoDoan.aspx.cs" Inherits="Net2.Forms.frmSoDoan" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    SỔ ĐOÀN VIÊN
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <form class="panel panel-default" runat="server">
                <div class="panel-heading panel-body">
                    <h4 style="float: left;"><i class="fa fa-file-text-o fa-fw">&nbsp;</i>Danh Sách Sổ Đoàn</h4>
                    <div class="col-lg-4" style="float: right;">
                        <div class="input-group custom-search-form">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Từ khóa..."></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="btnSearch" CssClass="btn btn-default" runat="server" Text="Search" />
                            </span>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div style="max-width: 300px; margin-bottom: 20px;">
                        <asp:Button ID="btnThem" runat="server" Text="Thêm Mới" CssClass="btn btn-lg btn-success btn-block" PostBackUrl="~/Forms/frmKhoaChuQuanCU.aspx" />
                    </div>
                        <asp:PlaceHolder ID="tblSoDoan" runat="server"></asp:PlaceHolder>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
