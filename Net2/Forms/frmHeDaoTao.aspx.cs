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
    public partial class frmHeDaoTao : System.Web.UI.Page
    {
        QuanLyDoanVienDataContext database = new QuanLyDoanVienDataContext();
        Table<LoaiHeDaoTao> hedaotao;
        StringBuilder sbTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayOnTable("");
            txtSearchHeDaoTao.Focus();
        }
        private void DisplayOnTable(String key)
        {
            sbTable.Clear();
            tblHeDaoTao.Controls.Clear();
            hedaotao = database.GetTable<LoaiHeDaoTao>();
            sbTable.Append("<table class='table table-striped table-bordered table-hover'>");
            sbTable.Append("<thread><tr><th style='width: 60px; text-align: center;'>STT</th><th>Mã HĐT</th><th>Tên Hệ Đào Tạo</th><th style='width: 150px;'>Tùy Chỉnh</th></tr></thread>");
            sbTable.Append("<tbody>");

            var query = from hdt in hedaotao
                        orderby hdt.LoaiHeDaoTaoID
                        where (hdt.MaHeDaoTao.Contains(key)||hdt.TenHeDaoTao.Contains(key))
                        select new
                        {
                            hdt.MaHeDaoTao,
                            hdt.TenHeDaoTao
                        };
            if (query.Count() > 0)
            {
                int i = 0;
                foreach(var item in query)
                {
                    i++;
                    sbTable.Append("<tr>");
                    sbTable.Append("<td style='text-align: center;'>" + i.ToString() + "</td>");
                    sbTable.Append("<td>" + item.MaHeDaoTao + "</td>");
                    sbTable.Append("<td>" + item.TenHeDaoTao + "</td>");
                    sbTable.Append("<td><a href='frmHeDaoTaoCU.aspx?id=" + item.MaHeDaoTao + "' class='btn btn-block btn-default'>Tùy Chỉnh</a>");
                    sbTable.Append("</tr>");
                }
            }
            sbTable.Append("</tbody>");
            sbTable.Append("</table>");
            tblHeDaoTao.Controls.Add(new Literal { Text = sbTable.ToString() });
        }
        protected void btnSearchHeDaoTao_Click(Object sender, EventArgs e)
        {
            DisplayOnTable(txtSearchHeDaoTao.Text);
            txtSearchHeDaoTao.Focus();
        }
        protected void btnReset_Click(Object sender, EventArgs e)
        {
            txtSearchHeDaoTao.Text = "";
            DisplayOnTable("");
            txtSearchHeDaoTao.Focus();
        }
    }
}