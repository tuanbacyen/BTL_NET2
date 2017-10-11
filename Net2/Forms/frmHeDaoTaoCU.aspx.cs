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
    public partial class frmHeDaoTaoCU : System.Web.UI.Page
    {
        QuanLyDoanVienDataContext database = new QuanLyDoanVienDataContext();
        Table<LoaiHeDaoTao> heDaoTao;
        protected void Page_Load(object sender, EventArgs e)
        {
            heDaoTao = database.GetTable<LoaiHeDaoTao>();
            txtMaHeDaoTao.Focus();
            if (Request.QueryString["id"] != null && txtMaHeDaoTao.Text == "")
                TuyChon();
        }
        private void TuyChon()
        {
            labTitle.Text = "CHỈNH SỬA LOẠI HỆ ĐÀO TẠO";
            txtMaHeDaoTao.Text = Request.QueryString["id"];
            txtMaHeDaoTao.Enabled = false;
            txtTenHeDaoTao.Focus();
            if(txtMaHeDaoTao.Text != "")
            {
                var query = from hdt in heDaoTao
                            where hdt.MaHeDaoTao.Equals(txtMaHeDaoTao.Text)
                            select new
                            {
                                hdt.MaHeDaoTao,
                                hdt.TenHeDaoTao
                            };
                if (query.Count() > 0)
                {
                    foreach(var item in query)
                    {
                        txtTenHeDaoTao.Text = item.TenHeDaoTao;
                        btnXoa.Enabled = true;
                    }
                }
            }
        }
        private void LuuThem()
        {
            bool MaTonTai = heDaoTao.Any(row => row.MaHeDaoTao == txtMaHeDaoTao.Text);
            if (MaTonTai)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Mã khoa đã tồn tại!')", true);
            }
            else
            {
                try
                {
                    LoaiHeDaoTao obj = new LoaiHeDaoTao();
                    obj.MaHeDaoTao = txtMaHeDaoTao.Text.Trim();
                    obj.TenHeDaoTao = txtTenHeDaoTao.Text.Trim();

                    heDaoTao = database.GetTable<LoaiHeDaoTao>();
                    heDaoTao.InsertOnSubmit(obj);
                    database.SubmitChanges();
                    Response.Redirect("frmHeDaoTao.aspx");
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Mã khoa đã tồn tại!')", true);
                }
            }
        }
        private void LuuSua()
        {
            try
            {
                LoaiHeDaoTao obj = heDaoTao.Single(hdt => hdt.MaHeDaoTao == Request.QueryString["id"]);
                obj.TenHeDaoTao = txtTenHeDaoTao.Text.Trim();
                database.SubmitChanges();
                Response.Redirect("frmHeDaoTao.aspx");
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
                LoaiHeDaoTao obj = heDaoTao.Single(hdt => hdt.MaHeDaoTao == Request.QueryString["id"]);

                heDaoTao.DeleteOnSubmit(obj);
                database.SubmitChanges();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Xóa thành công!')", true);
                Response.Redirect("frmHeDaoTao.aspx");

            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Đã xảy ra lỗi!')", true);
            }
        }
    }
}