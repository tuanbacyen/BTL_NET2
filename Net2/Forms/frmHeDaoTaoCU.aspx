<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmMaster.Master" AutoEventWireup="true" CodeBehind="frmHeDaoTaoCU.aspx.cs" Inherits="Net2.Forms.frmHeDaoTaoCU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Label ID="labTitle" runat="server" Text="Thêm Mới Hệ Đào Tạo"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="col-lg-4">
            <form class="panel panel-default" runat="server">
                <div class="panel-heading panel-body">
                    <h4 style="float: left;"><i class="fa fa-file-text-o fa-fw">&nbsp;</i>Thông Tin Hệ Đào Tạo </h4>
                </div>
                <div class="panel-body">
                    <p><b>Mã Hệ Đào Tạo: </b></p>
                        <asp:TextBox ID="txtMaHeDaoTao" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Mã hệ đào tạo không đc bỏ trống" ControlToValidate="txtMaHeDaoTao" ForeColor="Red" ValidationGroup="error" Font-Italic="True"></asp:RequiredFieldValidator>
                    <br />
                    <p><b>Tên Hệ Đào Tạo: </b></p>
                        <asp:TextBox ID="txtTenHeDaoTao" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Tên hệ đào tạo không đc bỏ trống" ControlToValidate="txtTenHeDaoTao" ForeColor="Red" ValidationGroup="error" Font-Italic="True"></asp:RequiredFieldValidator>


                    <table style="max-width: 100%; margin: auto; margin-top: 15px; border-spacing: 10px;">
                        <tr>
                            <td style="width: 30%;">
                                <div style="width: 95%; float: left;">
                                    <asp:Button ID="btnThem" runat="server" Text="Lưu" CssClass="btn btn-lg btn-block btn-success" OnClick="btnThem_Click" ValidationGroup="error" />
                                </div>                                
                            </td>
                            <td style="width: 30%;">
                                <div style="width: 95%; float: left;">
                                    <asp:Button ID="btnXoa" runat="server" Text="Xóa" CssClass="btn btn-lg btn-block btn-danger" OnClick="btnXoa_Click" Enabled="False" />
                                </div>
                            </td>
                            <td style="width: 30%;">
                                <div style="width: 95%; float: left;">
                                    <asp:Button ID="btnHuy" runat="server" Text="Hủy" CssClass="btn btn-lg btn-block btn-default" PostBackUrl="~/Forms/frmHeDaoTao.aspx" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
