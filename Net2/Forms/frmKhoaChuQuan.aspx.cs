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
    public partial class frmKhoaChuQuan : System.Web.UI.Page
    {
        Model.QuanLyDoanVienDataContext database = new QuanLyDoanVienDataContext();
        Table<Model.Khoa> Table;
        StringBuilder sbTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayOnTable();
        }
        private void DisplayOnTable()
        {
            Table = database.GetTable<Model.Khoa>();
            var query = from kh in Table
                        orderby kh.KhoaID
                        select new
                        {
                            STT = kh.KhoaID,
                            kh.MaKhoa,
                            kh.TenKhoa
                        };
            sbTable.Append("<table class='table table-striped table-bordered table-hover'>");
            sbTable.Append("<tr><th>STT</th><th>Mã Khoa</th><th>Tên Khoa</th><th>Tùy Chỉnh</th></tr>");
            if (query.Count() > 0)
            {
                foreach (var item in query)
                {
                    sbTable.Append("<tr>");
                    sbTable.Append("<td>" + item.STT + "</td>");
                    sbTable.Append("<td>" + item.MaKhoa + "</td>");
                    sbTable.Append("<td>" + item.TenKhoa + "</td>");
                    sbTable.Append("<td><a href='frmKhoaChuQuanCU.aspx?id=" + item.MaKhoa + "' class='btn btn-success'>Sửa</a><asp:Button ID='btnXoa' runat='server' Text='Xóa' CssClass='btn btn - danger btn - block' OnClick='btnXoa_Click' /></td>");
                    sbTable.Append("</tr>");
                }
            }
            sbTable.Append("</table >");
            tblKhoa.Controls.Add(new Literal { Text = sbTable.ToString() });
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            
        }
    }
}