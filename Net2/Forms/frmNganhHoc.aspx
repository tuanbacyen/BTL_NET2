<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmMaster.Master" AutoEventWireup="true" CodeBehind="frmNganhHoc.aspx.cs" Inherits="Net2.Forms.frmNganhHoc" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    NGÀNH HỌC
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <form runat="server">
            <div class="col-lg-9">
                <div class="panel panel-default">
                    <div class="panel-heading panel-body">
                        <h4 style="float: left;"><i class="fa fa-file-text-o fa-fw">&nbsp;</i>Danh Sách Ngành</h4>
                        <div class="col-lg-2" style="float: right;">
                            <asp:Button ID="btnThem" runat="server" Text="Thêm Mới" CssClass="form-control btn-success" PostBackUrl="~/Forms/frmNganhHocCU.aspx" />
                        </div>
                    </div>
                    <div class="panel-body">
                        <div>
                            <asp:PlaceHolder ID="tblNganh" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="panel panel-default">
                    <div class="panel-heading panel-body">
                        <h4 style="float: left;"><i class="fa fa-search fa-fw">&nbsp;</i>Hiển Thị</h4>
                    </div>
                    <div class="panel-body">
                        <asp:Panel ID="pnlSearchNganh" CssClass="input-group custom-search-form" runat="server" DefaultButton="btnSearchNganh">
                            <asp:TextBox ID="txtSearchNganh" runat="server" CssClass="form-control" placeholder="Từ khóa..."></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:LinkButton ID="btnSearchNganh" CssClass="btn btn-default" OnClick="btnSearch_Click" runat="server"><i class="fa fa-search" aria-hidden="true"></i></asp:LinkButton>
                            </span>
                        </asp:Panel>
                        <hr />
                        <asp:DropDownList ID="drlKhoa" runat="server" CssClass="form-control input-group" AutoPostBack="True" OnSelectedIndexChanged="drlKhoa_TextChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>

