<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/frmMaster.Master" AutoEventWireup="true" CodeBehind="frmLopChuQuanCU.aspx.cs" Inherits="Net2.Forms.frmLopChuQuanCU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Label ID="labTitle" runat="server" Text="THÊM MỚI LỚP"></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="col-lg-4">
            <form class="panel panel-default" runat="server">
                <div class="panel-heading panel-body">
                    <h4 style="float: left;"><i class="fa fa-file-text-o fa-fw">&nbsp;</i>Thông Tin Khoa </h4>
                </div>
                <div class="panel-body">
                    <p><b>Mã lớp: </b></p>
                    <asp:TextBox ID="txtMaLop" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Mã lớp không đc bỏ trống" ControlToValidate="txtMaLop" ForeColor="Red" ValidationGroup="error" Font-Italic="True"></asp:RequiredFieldValidator>
                    <br />
                    <p><b>Tên lớp: </b></p>
                    <asp:TextBox ID="txtTenLop" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Tên lớp không đc bỏ trống" ControlToValidate="txtTenLop" ForeColor="Red" ValidationGroup="error" Font-Italic="True"></asp:RequiredFieldValidator>
                    <hr />
                    <p><b>Khoa: </b></p>
                    <asp:DropDownList ID="drlKhoa" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="drlKhoa_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Mời bạn chọn khoa" ControlToValidate="drlKhoa" ForeColor="Red" ValidationGroup="error" Font-Italic="True"></asp:RequiredFieldValidator>
                    <br />
                    <p><b>Ngành: </b></p>
                    <asp:DropDownList ID="drlNganh" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Mời bạn chọn ngành" ControlToValidate="drlNganh" ForeColor="Red" ValidationGroup="error" Font-Italic="True"></asp:RequiredFieldValidator>
                    <br />
                    <p><b>Loại hệ đào tạo: </b></p>
                    <asp:DropDownList ID="drlLoaiHeDaoTao" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Mời bạn chọn ngành" ControlToValidate="drlLoaiHeDaoTao" ForeColor="Red" ValidationGroup="error" Font-Italic="True"></asp:RequiredFieldValidator>
                    <br />
                    <p><b>Sĩ số: </b></p>
                    <asp:TextBox ID="txtSiSo" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Sĩ số không đc bỏ trống" ControlToValidate="txtSiSo" ForeColor="Red" ValidationGroup="error" Font-Italic="True"></asp:RequiredFieldValidator>
                    <br />
                    <p><b>Khóa học: </b></p>
                    <asp:TextBox ID="txtKhoaHoc" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Khóa học không đc bỏ trống" ControlToValidate="txtTenLop" ForeColor="Red" ValidationGroup="error" Font-Italic="True"></asp:RequiredFieldValidator>
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
                                    <asp:Button ID="btnHuy" runat="server" Text="Hủy" CssClass="btn btn-lg btn-block btn-default" PostBackUrl="~/Forms/frmLopChuQuan.aspx" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
