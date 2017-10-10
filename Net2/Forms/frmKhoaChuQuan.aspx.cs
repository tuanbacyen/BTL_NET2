using Net2.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Net2.Forms
{
    public partial class frmKhoaChuQuan : System.Web.UI.Page
    {
        Model.QuanLyDoanVienDataContext database = new QuanLyDoanVienDataContext();
        Table<Model.Khoa> khoa;
        StringBuilder sbTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayOnTable("");
            txtSearchKhoa.Focus();
        }
        private void DisplayOnTable(String key)
        {
            sbTable.Clear();
            tblKhoa.Controls.Clear();
            khoa = database.GetTable<Model.Khoa>();
            var query = from kh in khoa
                        where (kh.MaKhoa.Contains(key) || kh.TenKhoa.Contains(key))                  
                        orderby kh.KhoaID
                        select new
                        {
                            STT = kh.KhoaID,
                            kh.MaKhoa,
                            kh.TenKhoa
                        };
            sbTable.Append("<table class='table table-striped table-bordered table-hover'>");
            sbTable.Append("<tr><th style='width: 60px; text-align: center;'>STT</th><th>Mã Khoa</th><th>Tên Khoa</th><th style='width: 150px;'>Tùy Chỉnh</th></tr>");
            if (query.Count() > 0)
            {
                int i = 0;
                foreach (var item in query)
                {
                    i++;
                    sbTable.Append("<tr>");
                    sbTable.Append("<td style='text-align: center'>" + i.ToString() + "</td>");
                    sbTable.Append("<td>" + item.MaKhoa + "</td>");
                    sbTable.Append("<td>" + item.TenKhoa + "</td>");
                    sbTable.Append("<td><a href='frmKhoaChuQuanCU.aspx?id=" + item.MaKhoa + "' class='btn btn-block btn-default'>Tùy Chỉnh</a>");
                    sbTable.Append("</td>");
                    sbTable.Append("</tr>");
                }
            }
            sbTable.Append("</table >");
            tblKhoa.Controls.Add(new Literal { Text = sbTable.ToString() });
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DisplayOnTable(txtSearchKhoa.Text);
            txtSearchKhoa.Focus();
        }
    }
}