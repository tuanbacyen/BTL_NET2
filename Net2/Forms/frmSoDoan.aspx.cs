using Net2.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Net2.Forms
{
    public partial class frmSoDoan : System.Web.UI.Page
    {
        QuanLyDoanVienDataContext db = new QuanLyDoanVienDataContext();
        Table<CanBoVPDoan> canbovpdoans;
        Table<SinhVien> sinhviens;
        Table<SoDoanVien> sodoanviens;
        Table<Khoa> khoas;
        Table<NganhHoc> nganhhocs;
        Table<LopQuanLy> lopquanlys;

        string maLop = "";
        StringBuilder sbTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayOnTable();
        }
        private void DisplayOnTable()
        {
            canbovpdoans = db.GetTable<CanBoVPDoan>();
            sinhviens = db.GetTable<SinhVien>();
            sodoanviens = db.GetTable<SoDoanVien>();

            var query = from sd in sodoanviens
                                join cb in canbovpdoans on sd.MaCanBoDoan equals cb.MaCanBoDoan
                                join sv in sinhviens on sd.MaSinhVien equals sv.MaSinhVien
                                where sv.Xoa == false
                                //sv.MaLop == maLop &&
                                select new { sd.MaSoDoan, sv.MaSinhVien, TenSinhVien = sv.HoVaTenKhaiSinh, CanBoThuSoDoan = cb.HoVaTenKhaiSinh, sd.NgayNop, sd.ThongTinSoDoan, sd.NhanXet, sd.GhiChu };

            sbTable.Append("<table class='table table-striped table-bordered table-hover'>");
            sbTable.Append("<tr><th>STT</th>" +
                "<th>Mã sổ đoàn</th>" +
                "<th>Mã sinh viên</th>" +
                "<th>Họ và tên sinh viên</th>" +
                "<th>Họ và tên cán bộ thu</th>" +
                "<th>Ngày nộp</th>" +
                "<th>Thông tin sổ đoàn</th>" +
                "<th>Nhận xét</th>" +
                "<th>Ghi chú</th>" +
                "<th>Tùy Chỉnh</th>" +
                "</tr>");
            if (query.Count() > 0)
            {
                int i = 1;
                foreach (var item in query)
                {
                    sbTable.Append("<tr>");
                    sbTable.Append("<td>" + i + "</td>");
                    sbTable.Append("<td>" + item.MaSoDoan + "</td>");
                    sbTable.Append("<td>" + item.MaSinhVien + "</td>");
                    sbTable.Append("<td>" + item.TenSinhVien + "</td>");
                    sbTable.Append("<td>" + item.CanBoThuSoDoan + "</td>");
                    sbTable.Append("<td>" + item.NgayNop + "</td>");
                    sbTable.Append("<td>" + item.ThongTinSoDoan + "</td>");
                    sbTable.Append("<td>" + item.NhanXet + "</td>");
                    sbTable.Append("<td>" + item.GhiChu + "</td>");
                    sbTable.Append("<td><a href='frmSoDoanCU.aspx?id=" + item.MaSoDoan + "' class='btn btn-success'>Sửa</a><asp:Button ID='btnXoa' runat='server' Text='Xóa' CssClass='btn btn - danger btn - block' OnClick='btnXoa_Click' /></td>");
                    sbTable.Append("</tr>");
                    i++;
                }
            }
            sbTable.Append("</table >");
            tblSoDoan.Controls.Add(new Literal { Text = sbTable.ToString() });
        }
    }
}