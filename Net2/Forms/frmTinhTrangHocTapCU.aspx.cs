using Net2.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Net2.Forms
{
    public partial class frmTinhTrangHocTapCU : System.Web.UI.Page
    {
        QuanLyDoanVienDataContext database = new QuanLyDoanVienDataContext();
        Table<TinhTrangHocTap> tinhTrang;
        protected void Page_Load(object sender, EventArgs e)
        {
            tinhTrang = database.GetTable<TinhTrangHocTap>();
            txtMaTinhTrang.Focus();
            if (Request.QueryString["id"] != null && txtMaTinhTrang.Text == "")
                TuyChon();
        }
        private void TuyChon()
        {
            labTitle.Text = "CHỈNH SỬA TÌNH TRẠNG";
            txtMaTinhTrang.Text = Request.QueryString["id"];
            txtMaTinhTrang.Enabled = false;
            txtTenTinhTrang.Focus();
            if (txtMaTinhTrang.Text != "")
            {
                var query = from ttht in tinhTrang
                            where ttht.MaTinhTrangHocTap.Equals(txtMaTinhTrang.Text)
                            select new
                            {
                                ttht.MaTinhTrangHocTap,
                                ttht.TenTinhTrangHocTap
                            };
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        txtTenTinhTrang.Text = item.TenTinhTrangHocTap;
                    }
                    btnXoa.Enabled = true;
                }
            }
        }
        private void LuuThem()
        {
            bool MaTonTai = tinhTrang.Any(row => row.MaTinhTrangHocTap == txtMaTinhTrang.Text);
            if (MaTonTai)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Mã khoa đã tồn tại!')", true);
            }
            else
            {
                try
                {
                    TinhTrangHocTap obj = new TinhTrangHocTap();
                    obj.MaTinhTrangHocTap = txtMaTinhTrang.Text.Trim();
                    obj.TenTinhTrangHocTap = txtTenTinhTrang.Text.Trim();

                    tinhTrang = database.GetTable<TinhTrangHocTap>();
                    tinhTrang.InsertOnSubmit(obj);
                    database.SubmitChanges();
                    Response.Redirect("frmTinhTrangHocTap.aspx");
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Đã xảy ra lỗi!')", true);
                }
            }
        }
        private void LuuSua()
        {
            try
            {
                TinhTrangHocTap obj = tinhTrang.Single(ttht => ttht.MaTinhTrangHocTap == Request.QueryString["id"]);
                obj.TenTinhTrangHocTap = txtTenTinhTrang.Text.Trim();
                database.SubmitChanges();
                Response.Redirect("frmTinhTrangHocTap.aspx");
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Đã xảy ra lỗi!')", true);
            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
                LuuThem();
            else
                LuuSua();
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                TinhTrangHocTap obj = tinhTrang.Single(ttht => ttht.MaTinhTrangHocTap == Request.QueryString["id"]);

                tinhTrang.DeleteOnSubmit(obj);
                database.SubmitChanges();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Xóa thành công!')", true);
                Response.Redirect("frmTinhTrangHocTap.aspx");

            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Đã xảy ra lỗi!')", true);
            }
        }
    }
}