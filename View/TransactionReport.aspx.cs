using MakeMeUpzz.Model;
using MakeMeUpzz.Dataset;
using MakeMeUpzz.Report;
using MakeMeUpzz.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static MakeMeUpzz.Dataset.DataSet1;

namespace MakeMeUpzz.View
{
    public partial class TransactionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            TransactionHeaderController th = new TransactionHeaderController();
            if (Session["user"] == null && Request.Cookies["user_cookies"] == null)
            {
                Response.Redirect("~/View/LoginPage.aspx");
            }
            else
            {
                user = (User)Session["user"];
            }

            DataSet1 data = getData(th.getAllTransactionHeaders());
            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;
            report.SetDataSource(data);

        }

        public DataSet1 getData(List<TransactionHeader> transaction)
        {
            DataSet1 data = new DataSet1();
            var headertTable = data.transaction_header;
            var detailTable = data.transaction_detail;
            var totalTable = data.Total;
            var totalrow = totalTable.NewRow();
            int total = 0;

            foreach (TransactionHeader t in transaction)
            {
                var hrow = headertTable.NewRow();
                
                
                hrow["TransactionID"] = t.TransactionID;
                hrow["CustomerName"] = t.User.Username;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["Status"] = t.Status;

                headertTable.Rows.Add(hrow);

                foreach(var d in t.TransactionDetails)
                {
                    var drow = detailTable.NewRow();
                    drow["TransactionID"] = d.TransactionID;
                    drow["MakeupName"] = d.Makeup.MakeupName;
                    drow["Quantity"] = d.Quantity;
                    drow["Price"] = d.Makeup.MakeupPrice;
                    drow["Subtotal"] = d.Quantity * d.Makeup.MakeupPrice;

                    total += d.Quantity * d.Makeup.MakeupPrice;

                    detailTable.Rows.Add(drow);
                }
                
            }
            totalrow["Total"] = total;
            totalTable.Rows.Add(totalrow);

            return data;
        }
    }
}