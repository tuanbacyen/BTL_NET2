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
    public partial class frmNganhHoc : System.Web.UI.Page
    {
        Model.QuanLyDoanVienDataContext database = new QuanLyDoanVienDataContext();
        Table<Model.NganhHoc> nganh;
        Table<Model.Khoa> khoa;
        StringBuilder sbTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayOnTable("");
            txtSearchNganh.Focus();
            getKhoa();
        }
        private void DisplayOnTable(String key)
        {
            sbTable.Clear();
            tblNganh.Controls.Clear();
            nganh = database.GetTable<Model.NganhHoc>();
            khoa = database.GetTable<Model.Khoa>();
            sbTable.Append("<table class='table table-striped table-bordered table-hover'>");
            sbTable.Append("<thread><tr><th style='width: 60px; text-align: center;'>STT</th><th>Mã Ngành</th><th>Tên Ngành</th><th>Tên Khoa</th><th style='width: 150px;'>Tùy Chỉnh</th></tr></thread>");
            sbTable.Append("<tbody>");
            var query1 = from nh in nganh
                         join kh in khoa on nh.MaKhoa equals kh.MaKhoa
                         where ((nh.MaNganh.Contains(key) || nh.TenNganh.Contains(key)) && nh.MaKhoa.Equals(drlKhoa.SelectedValue))
                         orderby nh.MaKhoa
                         select new
                         {
                             STT = nh.NganhHocID,
                             nh.MaNganh,
                             nh.TenNganh,
                             kh.TenKhoa
                         };
            var query2 = from nh in nganh
                        join kh in khoa on nh.MaKhoa equals kh.MaKhoa
                        where (nh.MaNganh.Contains(key) || nh.TenNganh.Contains(key))
                        orderby nh.MaKhoa
                        select new
                        {
                            STT = nh.NganhHocID,
                            nh.MaNganh,
                            nh.TenNganh,
                            kh.TenKhoa
                        };
            if (drlKhoa.SelectedValue != "")
            {
                var query = query1;
                if (query.Count() > 0)
                {
                    int i = 0;
                    foreach (var item in query)
                    {
                        i++;
                        sbTable.Append("<tr>");
                        sbTable.Append("<td style='text-align: center;'>" + i.ToString() + "</td>");
                        sbTable.Append("<td>" + item.MaNganh + "</td>");
                        sbTable.Append("<td>" + item.TenNganh + "</td>");
                        sbTable.Append("<td>" + item.TenKhoa + "</td>");
                        sbTable.Append("<td><a href='frmNganhHocCU.aspx?id=" + item.MaNganh + "' class='btn btn-block btn-default'>Tùy Chỉnh</a>");
                        sbTable.Append("</tr>");
                    }
                }
            }
            else
            {
                var query = query2;
                if (query.Count() > 0)
                {
                    int i = 0;
                    foreach (var item in query)
                    {
                        i++;
                        sbTable.Append("<tr>");
                        sbTable.Append("<td style='text-align: center;'>" + i.ToString() + "</td>");
                        sbTable.Append("<td>" + item.MaNganh + "</td>");
                        sbTable.Append("<td>" + item.TenNganh + "</td>");
                        sbTable.Append("<td>" + item.TenKhoa + "</td>");
                        sbTable.Append("<td><a href='frmNganhHocCU.aspx?id=" + item.MaNganh + "' class='btn btn-block btn-default'>Tùy Chỉnh</a>");
                        sbTable.Append("</tr>");
                    }
                }
            }
            
            sbTable.Append("</tbody>");
            sbTable.Append("</table >");
            tblNganh.Controls.Add(new Literal { Text = sbTable.ToString() });
        }
        private void getKhoa()
        {
            if (drlKhoa.SelectedItem == null)
            {
                List<ListItem> items = new List<ListItem>();
                khoa = database.GetTable<Khoa>();
                var query = from kh in khoa
                            orderby kh.KhoaID
                            select new
                            {
                                kh.MaKhoa,
                                kh.TenKhoa
                            };
                if (query.Count() > 0)
                {
                    drlKhoa.Items.Clear();
                    items.Add(new ListItem("Chọn khoa", ""));
                    foreach (var item in query)
                    {
                        items.Add(new ListItem(item.TenKhoa.ToString(), item.MaKhoa.ToString()));
                    }
                    drlKhoa.Items.AddRange(items.ToArray());
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DisplayOnTable(txtSearchNganh.Text);
            txtSearchNganh.Focus();
        }

        protected void drlKhoa_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }
        protected void btnReset_Click(Object sender, EventArgs e)
        {
            txtSearchNganh.Text = "";
            drlKhoa.SelectedValue = "";
            DisplayOnTable("");
            txtSearchNganh.Focus();
        }
    }
}