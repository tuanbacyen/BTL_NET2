<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmMaster.Master" AutoEventWireup="true" CodeBehind="frmKhoaChuQuan.aspx.cs" Inherits="Net2.Forms.frmKhoaChuQuan" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    QUẢN LÝ KHOA
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <form runat="server">
            <div class="col-lg-3" style="float: right;">
                <div class="panel panel-default">
                    <div class="panel-heading panel-body">
                        <h4 style="float: left;"><i class="fa fa-search fa-fw">&nbsp;</i>Hiển Thị</h4>
                    </div>
                    <div class="panel-body">
                        <asp:Panel ID="pnlSearchKhoa" CssClass="input-group custom-search-form" runat="server" DefaultButton="btnSearchKhoa">
                            <asp:TextBox ID="txtSearchKhoa" runat="server" CssClass="form-control" placeholder="Từ khóa..."></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:LinkButton ID="btnSearchKhoa" CssClass="btn btn-default btn-success" OnClick="btnSearch_Click" runat="server"><i class="fa fa-search" aria-hidden="true"></i></asp:LinkButton>
                            </span>
                        </asp:Panel>
                        <hr />
                        <asp:Button ID="btlReset" runat="server" Text="Tạo Lại" CssClass="form-control btn-success" OnClick="btnReset_Click"/>
                    </div>
                </div>
            </div>
            <div class="col-lg-9" style="float: left;">
                <div class="panel panel-default">
                    <div class="panel-heading panel-body">
                        <h4 style="float: left;"><i class="fa fa-file-text-o fa-fw">&nbsp;</i>Danh Sách Khoa</h4>
                        <div class="col-lg-2" style="float: right;">
                            <asp:Button ID="btnThem" runat="server" Text="Thêm Mới" CssClass="form-control btn-success" PostBackUrl="~/Forms/frmKhoaChuQuanCU.aspx" />
                        </div>
                    </div>
                    <div class="panel-body">
                        <div>
                            <asp:PlaceHolder ID="tblKhoa" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>            
        </form>
    </div>
</asp:Content>

