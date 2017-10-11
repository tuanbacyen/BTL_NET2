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
    public partial class frmLopChuQuanCU : System.Web.UI.Page
    {
        QuanLyDoanVienDataContext database = new QuanLyDoanVienDataContext();
        Table<Khoa> khoa;
        Table<NganhHoc> nganh;
        Table<LoaiHeDaoTao> heDaoTao;
        Table<LopQuanLy> lop;
        protected void Page_Load(object sender, EventArgs e)
        {
            lop = database.GetTable<LopQuanLy>();
            nganh = database.GetTable<NganhHoc>();
            khoa = database.GetTable<Khoa>();
            heDaoTao = database.GetTable<LoaiHeDaoTao>();
            txtMaLop.Focus();
            getKhoa();
            if (drlKhoa.SelectedValue != "" && drlNganh.SelectedItem == null)
                getNganh();
            getHeDaoTao();
            if (Request.QueryString["id"] != null && txtMaLop.Text == "")
            {
                TuyChon();
            }
        }
        private void TuyChon()
        {
            labTitle.Text = "CHỈNH SỬA LỚP";
            txtMaLop.Text = Request.QueryString["id"];
            txtMaLop.Enabled = false;
            txtTenLop.Focus();
            if (txtMaLop.Text != "")
            {
                var query = from lp in lop
                            join ng in nganh on lp.MaNganh equals ng.MaNganh
                            join kh in khoa on ng.MaKhoa equals kh.MaKhoa
                            join hdt in heDaoTao on lp.MaHeDaoTao equals hdt.MaHeDaoTao
                            where lp.MaLop.Equals(txtMaLop.Text)
                            orderby lp.MaLop
                            select new
                            {
                                lp.MaLop,
                                lp.TenLop,
                                lp.SiSo,
                                hdt.MaHeDaoTao,
                                ng.MaNganh,
                                kh.MaKhoa,
                                lp.KhoaHoc
                            };
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        txtMaLop.Text = item.MaLop;
                        txtTenLop.Text = item.TenLop;
                        drlKhoa.SelectedValue = item.MaKhoa;
                        getNganh();
                        drlNganh.SelectedValue = item.MaNganh;
                        drlLoaiHeDaoTao.SelectedValue = item.MaHeDaoTao;
                        txtSiSo.Text = item.SiSo.ToString();
                        txtKhoaHoc.Text = item.KhoaHoc.ToString();
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
        private void getNganh()
        {
            List<ListItem> items = new List<ListItem>();
            nganh = database.GetTable<NganhHoc>();
            items.Clear();
            var query = from ng in nganh
                        where (ng.MaKhoa.Equals(drlKhoa.SelectedValue))
                        orderby ng.NganhHocID
                        select new
                        {
                            ng.MaNganh,
                            ng.TenNganh
                        };
            if (query.Count() > 0)
            {
                foreach (var item in query)
                {
                    items.Add(new ListItem(item.TenNganh.ToString(), item.MaNganh.ToString()));
                }
            }
            drlNganh.Items.Clear();
            drlNganh.Items.AddRange(items.ToArray());
        }
        private void getHeDaoTao()
        {
            List<ListItem> items = new List<ListItem>();
            heDaoTao = database.GetTable<LoaiHeDaoTao>();
            items.Clear();
            if (drlLoaiHeDaoTao.SelectedItem == null)
            {
                var query = from hdt in heDaoTao
                            orderby hdt.LoaiHeDaoTaoID
                            select new
                            {
                                hdt.MaHeDaoTao,
                                hdt.TenHeDaoTao
                            };
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        drlLoaiHeDaoTao.Items.Clear();
                        items.Add(new ListItem(item.TenHeDaoTao.ToString(), item.MaHeDaoTao.ToString()));
                    }
                }
                drlLoaiHeDaoTao.Items.AddRange(items.ToArray());
            }
        }

        protected void drlKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            getNganh();
        }
        private void LuuThem()
        {
            bool MaTonTai = lop.Any(row => row.MaLop == txtMaLop.Text);
            if (MaTonTai)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Mã lớp đã tồn tại!')", true);
            }
            else
            {
                try
                {
                    LopQuanLy obj = new LopQuanLy();
                    obj.MaLop = txtMaLop.Text;
                    obj.TenLop = txtTenLop.Text;
                    obj.SiSo = byte.Parse(txtSiSo.Text);
                    obj.MaHeDaoTao = drlLoaiHeDaoTao.SelectedValue;
                    obj.MaNganh = drlNganh.SelectedValue;
                    obj.KhoaHoc = byte.Parse(txtKhoaHoc.Text);

                    lop = database.GetTable<LopQuanLy>();
                    lop.InsertOnSubmit(obj);
                    database.SubmitChanges();
                    Response.Redirect("frmLopChuQuan.aspx");
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Đã xảy ra lỗi!')", true);
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
                LopQuanLy obj = lop.Single(lp => lp.MaLop == Request.QueryString["id"]);

                lop.DeleteOnSubmit(obj);
                database.SubmitChanges();
                Response.Redirect("frmLopChuQuan.aspx");

            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "thông báo", "alert('đã xảy ra lỗi!')", true);
            }
        }
        private void LuuSua()
        {
            try
            {
                LopQuanLy obj = lop.Single(lp => lp.MaLop == Request.QueryString["id"]);
                obj.TenLop = txtTenLop.Text;
                obj.SiSo = byte.Parse(txtSiSo.Text);
                obj.MaHeDaoTao = drlLoaiHeDaoTao.SelectedValue;
                obj.MaNganh = drlNganh.SelectedValue;
                obj.KhoaHoc = byte.Parse(txtKhoaHoc.Text);

                database.SubmitChanges();
                Response.Redirect("frmLopChuQuan.aspx");
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Thông Báo", "alert('Đã xảy ra lỗi!')", true);
            }
        }
    }
}