<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmMaster.Master" AutoEventWireup="true" CodeBehind="frmSoDoanCU.aspx.cs" Inherits="Net2.Forms.frmSoDoanCU" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Label ID="labTitle" runat="server" Text="Thêm mới sổ đoàn"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="col-lg-4">
            <form class="panel panel-default" runat="server">
                <div class="panel-heading panel-body">
                    <h4 style="float: left;"><i class="fa fa-file-text-o fa-fw">&nbsp;</i>Thông Tin Sổ Đoàn</h4>
                </div>
                <div class="panel-body">
                    <p><b>Mã Sổ Đoàn: </b></p>
                        <asp:TextBox ID="txtSoDoan" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Mã sổ đoàn không đc bỏ trống" ControlToValidate="txtSoDoan" ForeColor="Red" ValidationGroup="error" Font-Italic="True"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <p><b>Cán Bộ: </b></p>
                        <asp:DropDownList ID="drlCanBo" runat="server" CssClass="form-control" OnSelectedIndexChanged="drlCanBo_SelectedIndexChanged"></asp:DropDownList>
                    <br />
                    <br />
                    <p><b>Tên khoa: </b></p>
                        <asp:TextBox ID="txtTenKhoa" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Tên khoa không đc bỏ trống" ControlToValidate="txtTenKhoa" ForeColor="Red" ValidationGroup="error" Font-Italic="True"></asp:RequiredFieldValidator>


                    <table style="max-width: 300px; margin: auto; margin-top: 15px;">
                        <tr>
                            <td style="width: 150px">
                                <div style="width: 95%; float: left;">
                                    <asp:Button ID="btnThem" runat="server" Text="Lưu" CssClass="btn btn-lg btn-success btn-block" OnClick="btnThem_Click" ValidationGroup="error" />
                                </div>
                            </td>
                            <td style="width: 150px;">
                                <div style="width: 95%; float: right;">
                                    <asp:Button ID="Button1" runat="server" Text="Hủy" CssClass="btn btn-lg btn-danger btn-block" PostBackUrl="~/Forms/frmKhoaChuQuan.aspx" OnClick="Button1_Click" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
