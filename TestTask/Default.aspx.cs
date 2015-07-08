using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace TestTask
{
    public partial class _Default : Page
    {
        private DataSet ds = null;
        private SqlDataAdapter dAdapt = null;
        private string connString = ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString;
        private string tableName1 = "Members";
        private string tableName2 = "PhoneNumbers";

        protected void Page_Load(object sender, EventArgs e)
        {
            ds = new DataSet("AccountInfo");
            dAdapt = new SqlDataAdapter(
                "select * from Members",
                connString);
            dAdapt.Fill(ds, tableName1);
            
            dAdapt = new SqlDataAdapter(
                "select * from PhoneNumbers",
                connString);

            dAdapt.Fill(ds, tableName2);          

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int memberId = 0;
            try
            {
                memberId = int.Parse(this.textBoxID.Text);
            }
            catch (Exception ex)
            {
                this.textBoxID.Text = "Incorrect ID";
                return;                
            }
            
            DataTable dt = ds.Tables[tableName1];
            DataTable phoneDTable = ds.Tables[tableName2];

            DataRow[] rowsWithPhone = phoneDTable.Select(string.Format("MemberId = {0}", memberId));

            DataRow[] rows = dt.Select(string.Format("MemberId = {0}",memberId));
            if (rows.Length != 0 && rowsWithPhone.Length != 0)
            {
                var fName = rows[0]["FirstName"];
                if (fName is System.DBNull)
                    this.textBoxFirstName.Text = "No First Name";
                else
                    this.textBoxFirstName.Text = (string)fName;

                
                var lName = rows[0]["LastName"];
                if (fName is System.DBNull)
                    this.textBoxLastName.Text = "No First Name";
                else
                    this.textBoxLastName.Text = (string)lName;
                
                var title = rows[0]["Title"];
                if (title is System.DBNull)
                    this.textBoxTitle.Text = "No Title";
                else
                    this.textBoxTitle.Text = (string)title;
                
                DateTime dob = (DateTime)rows[0]["DOB"];
                int age = DateTime.Now.Year - dob.Year;
                this.TextBoxAge.Text = age.ToString();

                this.TextBoxDateOfBirth.Text = dob.Date.ToShortDateString();

                DataTable tempDataTable = new DataTable();
                DataColumn dCol = new DataColumn("Phone",typeof(string));
                tempDataTable.Columns.Add(dCol);
                DataRow rowFromTempDataTable = tempDataTable.NewRow();
                rowFromTempDataTable["Phone"] = rowsWithPhone[0]["PhoneNumber"];
                tempDataTable.Rows.Add(rowFromTempDataTable);
                this.GridViewTypeEmailNote.DataSource = tempDataTable;
                this.GridViewTypeEmailNote.DataBind();
            }
            else
            {
                this.textBoxFirstName.Text = "No member";
                this.textBoxFirstName.Text = "No member";
                this.textBoxLastName.Text = "No member";
                this.textBoxTitle.Text = "No member";

                this.TextBoxAge.Text = "No member";

                this.TextBoxDateOfBirth.Text = "No member";
            }

        }
    }
}