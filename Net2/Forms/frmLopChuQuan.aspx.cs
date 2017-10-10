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
    public partial class frmLopChuQuan : System.Web.UI.Page
    {
        QuanLyDoanVienDataContext database = new QuanLyDoanVienDataContext();
        Table<LopQuanLy> lop;
        Table<Khoa> khoa;
        Table<NganhHoc> nganh;
        Table<LoaiHeDaoTao> heDaoTao;
        StringBuilder sbTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayOnTable("");
            txtSearchLop.Focus();
            getKhoa();
            if(drlKhoa.SelectedValue!="" && drlNganh.SelectedItem==null)
                getNganh();
            getHeDaoTao();
        }
        private void DisplayOnTable(String key)
        {
            sbTable.Clear();
            tblLop.Controls.Clear();
            lop = database.GetTable<LopQuanLy>();
            khoa = database.GetTable<Khoa>();
            nganh = database.GetTable<NganhHoc>();
            heDaoTao = database.GetTable<LoaiHeDaoTao>();
            sbTable.Append("<table class='table table-striped table-bordered table-hover'>");
            sbTable.Append("<thread><tr><th style='width: 60px; text-align: center;'>STT</th><th>Mã Lớp</th><th>Tên Lớp</th><th>Sĩ Số</th><th>Hệ Đào Tạo</th><th>Khoa</th><th>Ngành</th><th>Khóa Học</th><th style='width: 150px;'>Tùy Chỉnh</th></tr></thread>");
            sbTable.Append("<tbody>");
            //Không chọn bộ lọc
            var query1 = from lp in lop
                         join ng in nganh on lp.MaNganh equals ng.MaNganh
                         join kh in khoa on ng.MaKhoa equals kh.MaKhoa
                         join hdt in heDaoTao on lp.MaHeDaoTao equals hdt.MaHeDaoTao
                         where ((lp.MaLop.Contains(key) || lp.TenLop.Contains(key)))
                         orderby lp.MaLop
                         select new
                         {
                             lp.MaLop,
                             lp.TenLop,
                             lp.SiSo,
                             hdt.TenHeDaoTao,
                             ng.TenNganh,
                             kh.TenKhoa,
                             lp.KhoaHoc
                         };
            //Chỉ chọn hệ đào tạo
            var query2 = from lp in lop
                         join ng in nganh on lp.MaNganh equals ng.MaNganh
                         join kh in khoa on ng.MaKhoa equals kh.MaKhoa
                         join hdt in heDaoTao on lp.MaHeDaoTao equals hdt.MaHeDaoTao
                         where ((lp.MaLop.Contains(key) || lp.TenLop.Contains(key)) && lp.MaHeDaoTao.Equals(drlHeDaoTao.SelectedValue))
                         orderby lp.MaLop
                         select new
                         {
                             lp.MaLop,
                             lp.TenLop,
                             lp.SiSo,
                             hdt.TenHeDaoTao,
                             ng.TenNganh,
                             kh.TenKhoa,
                             lp.KhoaHoc
                         };
            //Chỉ chọn khoa
            var query3 = from lp in lop
                         join ng in nganh on lp.MaNganh equals ng.MaNganh
                         join kh in khoa on ng.MaKhoa equals kh.MaKhoa
                         join hdt in heDaoTao on lp.MaHeDaoTao equals hdt.MaHeDaoTao
                         where ((lp.MaLop.Contains(key) || lp.TenLop.Contains(key)) && kh.MaKhoa.Equals(drlKhoa.SelectedValue))
                         orderby lp.MaLop
                         select new
                         {
                             lp.MaLop,
                             lp.TenLop,
                             lp.SiSo,
                             hdt.TenHeDaoTao,
                             ng.TenNganh,
                             kh.TenKhoa,
                             lp.KhoaHoc
                         };
            //Chọn khoa và ngành
            var query4 = from lp in lop
                         join ng in nganh on lp.MaNganh equals ng.MaNganh
                         join kh in khoa on ng.MaKhoa equals kh.MaKhoa
                         join hdt in heDaoTao on lp.MaHeDaoTao equals hdt.MaHeDaoTao
                         where ((lp.MaLop.Contains(key) || lp.TenLop.Contains(key)) && ng.MaNganh.Equals(drlNganh.SelectedValue))
                         orderby lp.MaLop
                         select new
                         {
                             lp.MaLop,
                             lp.TenLop,
                             lp.SiSo,
                             hdt.TenHeDaoTao,
                             ng.TenNganh,
                             kh.TenKhoa,
                             lp.KhoaHoc
                         };
            //Chọn khoa và hệ đào tạo
            var query5 = from lp in lop
                         join ng in nganh on lp.MaNganh equals ng.MaNganh
                         join kh in khoa on ng.MaKhoa equals kh.MaKhoa
                         join hdt in heDaoTao on lp.MaHeDaoTao equals hdt.MaHeDaoTao
                         where ((lp.MaLop.Contains(key) || lp.TenLop.Contains(key)) && kh.MaKhoa.Equals(drlKhoa.SelectedValue) && hdt.MaHeDaoTao.Equals(drlHeDaoTao.SelectedValue))
                         orderby lp.MaLop
                         select new
                         {
                             lp.MaLop,
                             lp.TenLop,
                             lp.SiSo,
                             hdt.TenHeDaoTao,
                             ng.TenNganh,
                             kh.TenKhoa,
                             lp.KhoaHoc
                         };
            //Chọn khoa, ngành và hệ đào tạo
            var query6 = from lp in lop
                         join ng in nganh on lp.MaNganh equals ng.MaNganh
                         join kh in khoa on ng.MaKhoa equals kh.MaKhoa
                         join hdt in heDaoTao on lp.MaHeDaoTao equals hdt.MaHeDaoTao
                         where ((lp.MaLop.Contains(key) || lp.TenLop.Contains(key)) && ng.MaNganh.Equals(drlNganh.SelectedValue) && hdt.MaHeDaoTao.Equals(drlHeDaoTao.SelectedValue))
                         orderby lp.MaLop
                         select new
                         {
                             lp.MaLop,
                             lp.TenLop,
                             lp.SiSo,
                             hdt.TenHeDaoTao,
                             ng.TenNganh,
                             kh.TenKhoa,
                             lp.KhoaHoc
                         };
            var query = query1;
            if (drlHeDaoTao.SelectedValue != "")
            {
                if (drlKhoa.SelectedValue != "")
                {
                    if (drlNganh.SelectedValue != "")
                        query = query6;
                    else
                        query = query5;
                }
                else
                    query = query2;
            }
            else
            {
                if (drlKhoa.SelectedValue != "")
                {
                    if (drlNganh.SelectedValue != "")
                        query = query4;
                    else
                        query = query3;
                }
                else
                    query = query1;
            }
            if (query.Count() > 0)
            {
                int i = 0;
                foreach (var item in query)
                {
                    i++;
                    sbTable.Append("<td style='text-align: center;'>" + i.ToString() + "</td>");
                    sbTable.Append("<td>" + item.MaLop + "</td>");
                    sbTable.Append("<td>" + item.TenLop + "</td>");
                    sbTable.Append("<td>" + item.SiSo + "</td>");
                    sbTable.Append("<td>" + item.TenHeDaoTao + "</td>");
                    sbTable.Append("<td>" + item.TenNganh + "</td>");
                    sbTable.Append("<td>" + item.TenKhoa + "</td>");
                    sbTable.Append("<td>" + item.KhoaHoc + "</td>");
                    sbTable.Append("<td><a href='frmLopChuQuanCU.aspx?id=" + item.MaLop + "' class='btn btn-block btn-default'>Tùy Chỉnh</a>");
                    sbTable.Append("</tr>");
                }
            }
            sbTable.Append("</tbody>");
            sbTable.Append("</table >");
            tblLop.Controls.Add(new Literal { Text = sbTable.ToString() });
        }
        private void getKhoa()
        {
            List<ListItem> items = new List<ListItem>();
            khoa = database.GetTable<Khoa>();
            items.Clear();
            items.Add(new ListItem("Chọn khoa", ""));
            if (drlKhoa.SelectedItem == null)
            {
                var query = from kh in khoa
                            orderby kh.KhoaID
                            select new
                            {
                                kh.MaKhoa,
                                kh.TenKhoa
                            };
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        drlKhoa.Items.Clear();
                        items.Add(new ListItem(item.TenKhoa.ToString(), item.MaKhoa.ToString()));
                    }
                }
                drlKhoa.Items.AddRange(items.ToArray());
            }
        }
        private void getNganh()
        {
            List<ListItem> items = new List<ListItem>();
            nganh = database.GetTable<NganhHoc>();
            items.Clear();
            items.Add(new ListItem("Chọn ngành", ""));
            var query = from ng in nganh
                        where (ng.MaKhoa.Equals(drlKhoa.SelectedValue))
                        orderby ng.NganhHocID
                        select new
                        {
                            ng.MaNganh,
                            ng.TenNganh
                        };
            if (query.Count() > 0)
            {
                foreach (var item in query)
                {
                    items.Add(new ListItem(item.TenNganh.ToString(), item.MaNganh.ToString()));
                }
            }
            drlNganh.Items.Clear();
            drlNganh.Items.AddRange(items.ToArray());
        }
        private void getHeDaoTao()
        {
            List<ListItem> items = new List<ListItem>();
            heDaoTao = database.GetTable<LoaiHeDaoTao>();
            items.Clear();
            items.Add(new ListItem("Chọn hệ đào tạo", ""));
            if (drlHeDaoTao.SelectedItem == null)
            {
                var query = from hdt in heDaoTao
                            orderby hdt.LoaiHeDaoTaoID
                            select new
                            {
                                hdt.MaHeDaoTao,
                                hdt.TenHeDaoTao
                            };
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        drlHeDaoTao.Items.Clear();
                        items.Add(new ListItem(item.TenHeDaoTao.ToString(), item.MaHeDaoTao.ToString()));
                    }
                }
                drlHeDaoTao.Items.AddRange(items.ToArray());
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DisplayOnTable(txtSearchLop.Text);
            txtSearchLop.Focus();
        }
        protected void drlKhoa_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
            getNganh();
        }
        protected void drlNganh_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }
        protected void drlHeDaoTao_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }
        protected void btnReset_Click(Object sender, EventArgs e)
        {
            txtSearchLop.Text = "";
            drlHeDaoTao.SelectedValue = "";
            drlNganh.Items.Clear();
            drlKhoa.SelectedValue = "";
            DisplayOnTable("");
            txtSearchLop.Focus();
        }
    }
}