<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmMaster.Master" AutoEventWireup="true" CodeBehind="frmTinhTrangHocTapCU.aspx.cs" Inherits="Net2.Forms.frmTinhTrangHocTapCU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Label ID="labTitle" runat="server" Text="THÊM MỚI TÌNH TRẠNG"></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="col-lg-4">
            <form class="panel panel-default" runat="server">
                <div class="panel-heading panel-body">
                    <h4 style="float: left;"><i class="fa fa-file-text-o fa-fw">&nbsp;</i>Thông Tin Khoa </h4>
                </div>
                <div class="panel-body">
                    <p><b>Mã tình trạng: </b></p>
                        <asp:TextBox ID="txtMaTinhTrang" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Mã tình trạng không đc bỏ trống" ControlToValidate="txtMaTinhTrang" ForeColor="Red" ValidationGroup="error" Font-Italic="True"></asp:RequiredFieldValidator>
                    <br />
                    <p><b>Tên tình trạng: </b></p>
                        <asp:TextBox ID="txtTenTinhTrang" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Tên tình trạng không đc bỏ trống" ControlToValidate="txtTenTinhTrang" ForeColor="Red" ValidationGroup="error" Font-Italic="True"></asp:RequiredFieldValidator>


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
                                    <asp:Button ID="btnHuy" runat="server" Text="Hủy" CssClass="btn btn-lg btn-block btn-default" PostBackUrl="~/Forms/frmTinhTrangHocTap.aspx" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
