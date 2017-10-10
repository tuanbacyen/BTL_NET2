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
    public partial class frmNganhHocCU : System.Web.UI.Page
    {
        QuanLyDoanVienDataContext database = new QuanLyDoanVienDataContext();
        Table<NganhHoc> nganh;
        Table<Khoa> khoa;

        protected void Page_Load(object sender, EventArgs e)
        {
            nganh = database.GetTable<NganhHoc>();
            txtMaNganh.Focus();
            getKhoa();
            if (Request.QueryString["id"] != null && txtMaNganh.Text == "")
            {
                TuyChon();
            }
        }
        private void TuyChon()
        {
            labTitle.Text = "CHỈNH SỬA NGÀNH";
            txtMaNganh.Text = Request.QueryString["id"];
            txtMaNganh.Enabled = false;
            txtTenNganh.Focus();
            if (txtMaNganh.Text != "")
            {
                var query = from ng in nganh
                            where ng.MaNganh.Equals(txtMaNganh.Text)
                            select new
                            {
                                ng.MaNganh,
                                ng.TenNganh,
                                ng.MaKhoa
                            };
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        txtTenNganh.Text = item.TenNganh;
                        drlKhoa.SelectedValue = item.MaKhoa;
                    }
                    btnXoa.Enabled = true;
                }
            }
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
                    foreach (var item in query)
                    {
                        items.Add(new ListItem(item.TenKhoa.ToString(), item.MaKhoa.ToString()));
                    }
                    drlKhoa.Items.AddRange(items.ToArray());
                }
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
                NganhHoc obj = nganh.Single(nh => nh.MaNganh == Request.QueryString["id"]);

                nganh.DeleteOnSubmit(obj);
                database.SubmitChanges();
                Response.Redirect("frmNganhHoc.aspx");

            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "thông báo", "alert('đã xảy ra lỗi!')", true);
            }
        }
        private void LuuThem()
        {
            bool MaTonTai = nganh.Any(row => row.MaNganh == txtMaNganh.Text);
            if (MaTonTai)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Mã ngành đã tồn tại!')", true);
            }
            else
            {
                try
                {
                    NganhHoc obj = new NganhHoc();
                    obj.MaNganh = txtMaNganh.Text;
                    obj.TenNganh = txtTenNganh.Text;
                    obj.MaKhoa = drlKhoa.SelectedValue;

                    nganh = database.GetTable<NganhHoc>();
                    nganh.InsertOnSubmit(obj);
                    database.SubmitChanges();
                    Response.Redirect("frmNganhHoc.aspx");
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
                NganhHoc obj = nganh.Single(ng => ng.MaNganh == Request.QueryString["id"]);
                obj.TenNganh = txtTenNganh.Text.Trim();
                obj.MaKhoa = drlKhoa.SelectedValue;
                database.SubmitChanges();
                Response.Redirect("frmNganhHoc.aspx");
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Đã xảy ra lỗi!')", true);
            }
        }
    }
}