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
    public partial class frmSoDoanCU : System.Web.UI.Page
    {

        QuanLyDoanVienDataContext db = new QuanLyDoanVienDataContext();
        Table<CanBoVPDoan> canbovpdoans;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadDataToDDLCanBo();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
        }

        #region method
        private void loadDataToDDLCanBo()
        {
            canbovpdoans = db.GetTable<CanBoVPDoan>();
            var queryCanBo = from cb in canbovpdoans
                           select new { cb.MaCanBoDoan, cb.HoVaTenKhaiSinh };
            if (queryCanBo.Count() > 0)
            {
                foreach (var item in queryCanBo)
                {
                    ListItem itemCB;
                    itemCB = new ListItem(item.HoVaTenKhaiSinh, item.MaCanBoDoan, true);
                    drlCanBo.Items.Add(itemCB);
                }
            }
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void drlCanBo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(),"alert","alert('" + drlCanBo.SelectedValue + "')",true);
        }
    }
}