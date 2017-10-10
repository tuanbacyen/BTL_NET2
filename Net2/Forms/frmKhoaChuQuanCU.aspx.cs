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
    public partial class frmKhoaChuQuanCU : System.Web.UI.Page
    {
        QuanLyDoanVienDataContext database = new QuanLyDoanVienDataContext();
        Table<Khoa> khoa;
        protected void Page_Load(object sender, EventArgs e)
        {
            khoa = database.GetTable<Khoa>();
            txtMaKhoa.Focus();
            if (Request.QueryString["id"] != null && txtMaKhoa.Text == "")
            {
                TuyChon();
            }
        }
        private void TuyChon()
        {
            labTitle.Text = "CHỈNH SỬA KHOA";
            txtMaKhoa.Text = Request.QueryString["id"];
            txtMaKhoa.Enabled = false;
            txtTenKhoa.Focus();
            if (txtMaKhoa.Text != "")
            {
                var query = from kh in khoa
                            where kh.MaKhoa.Equals(txtMaKhoa.Text)
                            select new
                            {
                                kh.MaKhoa,
                                kh.TenKhoa
                            };
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                        txtTenKhoa.Text = item.TenKhoa;
                    btnXoa.Enabled = true;
                }
            }
        }
        private void LuuThem()
        {
            bool MaKhoaTonTai = khoa.Any(row => row.MaKhoa == txtMaKhoa.Text);
            if (MaKhoaTonTai)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Mã khoa đã tồn tại!')", true);
            }
            else
            {
                try
                {
                    Khoa obj = new Khoa();
                    obj.MaKhoa = txtMaKhoa.Text.Trim();
                    obj.TenKhoa = txtTenKhoa.Text.Trim();

                    khoa = database.GetTable<Khoa>();
                    khoa.InsertOnSubmit(obj);
                    database.SubmitChanges();
                    Response.Redirect("frmKhoaChuQuan.aspx");

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
                Khoa obj = khoa.Single(kh => kh.MaKhoa == Request.QueryString["id"]);
                obj.TenKhoa = txtTenKhoa.Text.Trim();
                database.SubmitChanges();
                Response.Redirect("frmKhoaChuQuan.aspx");

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
                Khoa obj = khoa.Single(kh => kh.MaKhoa == Request.QueryString["id"]);

                khoa.DeleteOnSubmit(obj);
                database.SubmitChanges();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Xóa thành công!')", true);
                Response.Redirect("frmKhoaChuQuan.aspx");

            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Đã xảy ra lỗi!')", true);
            }
        }
    }
}