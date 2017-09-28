using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Net2.ConnectDatabase;

namespace Net2.View
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTest.Text = SqlHelper.GetDataTable("select * from ChucVu").Rows[0][1].ToString();
            SqlHelper.ExcuteSQL("INSERT INTO ChucVu (MaChucVu, TenChucVu) VALUES (N'ÔB',N'Ông bà anh')");
        }
    }
}