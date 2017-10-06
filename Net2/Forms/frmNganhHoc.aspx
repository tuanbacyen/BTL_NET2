<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmMaster.Master" AutoEventWireup="true" CodeBehind="frmNganhHoc.aspx.cs" Inherits="Net2.Forms.frmNganhHoc" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    NGÀNH HỌC
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <form class="panel panel-default" runat="server">
                <div class="panel-heading panel-body">
                    <h4 style="float: left;"><i class="fa fa-file-text-o fa-fw">&nbsp;</i>Danh Sách Ngành</h4>
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
                        <asp:Button ID="btnThem" runat="server" Text="Thêm Mới" CssClass="btn btn-lg btn-success btn-block" PostBackUrl="~/Forms/frmNganhHocCU.aspx" />
                    </div>
                    <asp:PlaceHolder ID="tblKhoa" runat="server"></asp:PlaceHolder>
                </div>
            </form>
        </div>
    </div>
</asp:Content>

