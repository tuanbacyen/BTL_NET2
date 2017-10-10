﻿<%@ page title="" language="C#" masterpagefile="~/Forms/frmMaster.Master" autoeventwireup="true" codebehind="frmKhoaChuQuanCU.aspx.cs" inherits="Net2.Forms.frmKhoaChuQuanCU" %>

<asp:content id="Content1" contentplaceholderid="head" runat="server">
    <asp:Label ID="labTitle" runat="server" Text="Thêm Mới Khoa"></asp:Label>
</asp:content>
<asp:content id="Content2" contentplaceholderid="content" runat="server">
    <div class="row">
        <div class="col-lg-4">
            <form class="panel panel-default" runat="server">
                <div class="panel-heading panel-body">
                    <h4 style="float: left;"><i class="fa fa-file-text-o fa-fw">&nbsp;</i>Thông Tin Khoa </h4>
                </div>
                <div class="panel-body">
                    <p><b>Mã khoa: </b></p>
                        <asp:TextBox ID="txtMaKhoa" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Mã khoa không đc bỏ trống" ControlToValidate="txtMaKhoa" ForeColor="Red" ValidationGroup="error" Font-Italic="True"></asp:RequiredFieldValidator>
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
                                    <asp:Button ID="Button1" runat="server" Text="Hủy" CssClass="btn btn-lg btn-danger btn-block" PostBackUrl="~/Forms/frmKhoaChuQuan.aspx" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </form>
        </div>
    </div>
</asp:content>
