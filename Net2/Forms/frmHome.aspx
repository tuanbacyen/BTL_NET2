<%@ Page Title="QLĐV - Trang Chủ" Language="C#" MasterPageFile="~/Forms/frmMaster.Master" AutoEventWireup="true" CodeBehind="frmHome.aspx.cs" Inherits="QuanLyDoanVien.Forms.frmHome" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    Trang Chủ
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="col-lg-8">
            <form class="panel panel-default" runat="server">
                <div class="panel-heading panel-body">
                    <h5 style="float: left;"><i class="fa fa-file-text fa-fw">&nbsp;</i>Danh Sách </h5>                       
                    <div class="col-lg-4" style="float: right;">
                        <div class="input-group custom-search-form">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Nhập từ khóa..."></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="btnSearch" CssClass="btn btn-default" runat="server" Text="Tìm Kiếm" />
                            </span>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                </div>
            </form>
        </div>
        <div class="col-lg-4">
            <div class="panel panel-default">
                <div class="panel-heading panel-body">
                    <h5 style="float: left;"><i class="fa fa-plus fa-fw">&nbsp;</i>Thông Tin Thêm Mới</h5>                       
                </div>
                <div class="panel-body">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
