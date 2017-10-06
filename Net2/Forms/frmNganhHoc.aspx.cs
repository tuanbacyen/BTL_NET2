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
            DisplayOnTable();
        }
        private void DisplayOnTable()
        {
            nganh = database.GetTable<Model.NganhHoc>();
            khoa = database.GetTable<Model.Khoa>();
            var query = from nh in nganh
                        join kh in khoa on nh.MaKhoa equals kh.MaKhoa
                        orderby nh.NganhHocID
                        select new
                        {
                            STT = nh.NganhHocID, nh.MaNganh, nh.TenNganh, kh.TenKhoa
                        };
            sbTable.Append("<table class='table table-striped table-bordered table-hover'>");
            sbTable.Append("<tr><th>STT</th><th>Mã Ngành</th><th>Tên Ngành</th><th>Tên Khoa</th></tr>");
            if (query.Count() > 0)
            {
                foreach (var item in query)
                {
                    sbTable.Append("<tr>");
                    sbTable.Append("<td>" + item.STT + "</td>");
                    sbTable.Append("<td>" + item.MaNganh + "</td>");
                    sbTable.Append("<td>" + item.TenNganh + "</td>");
                    sbTable.Append("<td>" + item.TenKhoa + "</td>");
                    sbTable.Append("</tr>");
                }
            }
            sbTable.Append("</table >");
            tblKhoa.Controls.Add(new Literal { Text = sbTable.ToString() });
        }
    }
}