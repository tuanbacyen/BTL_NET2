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
    public partial class frmChucVuCU : System.Web.UI.Page
    {
        QuanLyDoanVienDataContext database = new QuanLyDoanVienDataContext();
        Table<ChucVu> chucVu;
        protected void Page_Load(object sender, EventArgs e)
        {
            chucVu = database.GetTable<ChucVu>();
            txtMaChucVu.Focus();
            if (Request.QueryString["id"] != null && txtMaChucVu.Text == "")
                TuyChon();
        }
        private void TuyChon()
        {
            labTitle.Text = "CHỈNH SỬA CHỨC VỤ";
            txtMaChucVu.Text = Request.QueryString["id"];
            txtMaChucVu.Enabled = false;
            txtTenChucVu.Focus();
            if (txtMaChucVu.Text != null)
            {
                var query = from cv in chucVu
                            where cv.MaChucVu.Equals(txtMaChucVu.Text)
                            select new
                            {
                                cv.MaChucVu,
                                cv.TenChucVu
                            };
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                        txtTenChucVu.Text = item.TenChucVu;
                    btnXoa.Enabled = true;
                }
            }
        }
        private void LuuThem()
        {
            bool MaTonTai = chucVu.Any(row => row.MaChucVu == txtMaChucVu.Text);
            if (MaTonTai)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Mã khoa đã tồn tại!')", true);
            }
            else
            {
                try
                {
                    ChucVu obj = new ChucVu();
                    obj.MaChucVu = txtMaChucVu.Text.Trim();
                    obj.TenChucVu = txtTenChucVu.Text.Trim();

                    chucVu = database.GetTable<ChucVu>();
                    chucVu.InsertOnSubmit(obj);
                    database.SubmitChanges();
                    Response.Redirect("frmChucVu.aspx");
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
                ChucVu obj = chucVu.Single(cv => cv.MaChucVu == Request.QueryString["id"]);
                obj.TenChucVu = txtTenChucVu.Text.Trim();
                database.SubmitChanges();
                Response.Redirect("frmChucVu.aspx");
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
                ChucVu obj = chucVu.Single(cv => cv.MaChucVu == Request.QueryString["id"]);

                chucVu.DeleteOnSubmit(obj);
                database.SubmitChanges();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Xóa thành công!')", true);
                Response.Redirect("frmChucVu.aspx");

            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Đã xảy ra lỗi!')", true);
            }
        }
    }
}