<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmMaster.Master" AutoEventWireup="true" CodeBehind="frmHeDaoTao.aspx.cs" Inherits="Net2.Forms.frmHeDaoTao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    HỆ ĐÀO TẠO
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <form runat="server">
            <div class="col-lg-3" style="float: right;">
                <div class="panel panel-default">
                    <div class="panel-heading panel-body">
                        <h4 style="float: left;"><i class="fa fa-search fa-fw">&nbsp;</i>Hiển Thị</h4>
                    </div>
                    <div class="panel-body">
                        <asp:Panel ID="pnlSearchHeDaoTao" CssClass="input-group custom-search-form" runat="server" DefaultButton="btnSearchHeDaoTao">
                            <asp:TextBox ID="txtSearchHeDaoTao" runat="server" CssClass="form-control" placeholder="Từ khóa..."></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:LinkButton ID="btnSearchHeDaoTao" CssClass="btn btn-success" OnClick="btnSearchHeDaoTao_Click" runat="server"><i class="fa fa-search" aria-hidden="true"></i></asp:LinkButton>
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
                        <h4 style="float: left;"><i class="fa fa-file-text-o fa-fw">&nbsp;</i>Danh Sách Hệ Đào Tạo</h4>
                        <div class="col-lg-2" style="float: right;">
                            <asp:Button ID="btnThem" runat="server" Text="Thêm Mới" CssClass="form-control btn-success" PostBackUrl="~/Forms/frmHeDaoTaoCU.aspx" />
                        </div>
                    </div>
                    <div class="panel-body">
                        <div>
                            <asp:PlaceHolder ID="tblHeDaoTao" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>            
        </form>
    </div>
</asp:Content>
