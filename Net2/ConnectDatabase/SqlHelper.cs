using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;

namespace Net2.ConnectDatabase
{
    public class SqlHelper
    {
        public static string conStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public static SqlCommand cmd;
        public static SqlDataAdapter da;
        private static SqlConnection cnn = new SqlConnection(conStr);
        public SqlHelper()
        {
            openCon();
        }
        public static void DisConnection()
        {
            cnn.Close();
        }
        public static void openCon()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
        }
        public static DataTable GetDataTable(string sql)
        {
            openCon();
            cmd = new SqlCommand(sql, cnn);
            da = new SqlDataAdapter(cmd);
            DataTable db = new DataTable();
            try
            {
                da.Fill(db);

            }
            catch { }
            return db;
        }
        public static bool ExcuteSQL(string sql)
        {
            openCon();
            cmd = new SqlCommand(sql, cnn);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    if (ex.Errors[i].Message.ToString().Contains("REFERENCE"))
                    {
                        errorMessages.Append("Lỗi #" + i + "\n" +
                         "Nội dung lỗi: Không thể xóa trường này khi tồn tại rằng buộc với bảng khác \n" +
                         "Dòng số: " + ex.Errors[i].LineNumber + "\n" +
                         "Nguồn: " + ex.Errors[i].Source + "\n" +
                         "Thủ tục: " + ex.Errors[i].Procedure + "\n");
                        continue;
                    }
                    if (ex.Errors[i].Message.ToString().Contains("PRIMARY KEY"))
                    {
                        errorMessages.Append("Lỗi #" + i + "\n" +
                         "Nội dung lỗi: Mã bị trùng \n" +
                         "Dòng số: " + ex.Errors[i].LineNumber + "\n" +
                         "Nguồn: " + ex.Errors[i].Source + "\n" +
                         "Thủ tục: " + ex.Errors[i].Procedure + "\n"); continue;
                    }
                    if (ex.Errors[i].Message.ToString().Contains("statement has been terminated"))
                    {
                        errorMessages.Append("Lỗi #" + i + "\n" +
                         "Nội dung lỗi: Dữ liệu quá giới hạn \n" +
                         "Dòng số: " + ex.Errors[i].LineNumber + "\n" +
                         "Nguồn: " + ex.Errors[i].Source + "\n" +
                         "Thủ tục: " + ex.Errors[i].Procedure + "\n"); continue;
                    }
                    else
                    {
                        errorMessages.Append("Lỗi #" + i + "\n" +
                        "Nội dung lỗi: " + ex.Errors[i].Message + "\n" +
                        "Dòng số: " + ex.Errors[i].LineNumber + "\n" +
                        "Nguồn: " + ex.Errors[i].Source + "\n" +
                        "Thủ tục: " + ex.Errors[i].Procedure + "\n"); continue;
                    }
                }
                //                MessageBox.Show(errorMessages.ToString());
                return false;
            }
            // return true;
        }

        internal static bool ExcuteSQL1(string sql)
        {
            openCon();
            cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            return true;
        }

        public static int AExcuteSQL(string sql)
        {
            openCon();
            cmd = new SqlCommand(sql, cnn);
            return (int)cmd.ExecuteScalar();
        }
    }
}