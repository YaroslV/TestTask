using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Configuration;
using System.Text;

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
                "select * from PhoneNumbers join PhoneTypes on PhoneNumbers.PhoneTypeID = PhoneTypes.PhoneTypeID",
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

            StringBuilder labelText = new StringBuilder();
            if (rows.Length != 0)
            {
                var title = rows[0]["Title"];
                if (title is System.DBNull)
                {
                    this.textBoxTitle.Text = "No Title";
                }
                else
                {
                    this.textBoxTitle.Text = (string)title;
                    labelText.Append((string)title);
                    labelText.Append(" ");
                }


                var fName = rows[0]["FirstName"];
                if (fName is System.DBNull)
                {
                    this.textBoxFirstName.Text = "No First Name";
                }
                else
                {
                    this.textBoxFirstName.Text = (string)fName;
                    labelText.Append((string)fName);
                    labelText.Append(" ");
                }
                
                var lName = rows[0]["LastName"];
                if (fName is System.DBNull)
                {
                    this.textBoxLastName.Text = "No First Name";
                }
                else
                {
                    this.textBoxLastName.Text = (string)lName;
                    labelText.Append((string)lName);
                    labelText.Append(" ");
                }
                
                
                
                DateTime dob = (DateTime)rows[0]["DOB"];
                int age = DateTime.Now.Year - dob.Year;
                this.TextBoxAge.Text = age.ToString();
                this.TitleFNameLName.Text = labelText.ToString();
                this.TextBoxDateOfBirth.Text = dob.Date.ToShortDateString();                
            }
            else
            {
                this.TitleFNameLName.Text = "";
                this.textBoxFirstName.Text = "No member";
                this.textBoxFirstName.Text = "No member";
                this.textBoxLastName.Text = "No member";
                this.textBoxTitle.Text = "No member";

                this.TextBoxAge.Text = "No member";

                this.TextBoxDateOfBirth.Text = "No member";
            }

            DataTable tempDataTable = new DataTable();
            DataColumn dCol0 = new DataColumn("Type", typeof(string));
            DataColumn dCol1 = new DataColumn("Phone", typeof(string));
            DataColumn dCol2 = new DataColumn("Note", typeof(string));
            tempDataTable.Columns.AddRange(new DataColumn[] { dCol0, dCol1, dCol2 });
            DataRow rowFromTempDataTable = tempDataTable.NewRow();
            if (rowsWithPhone.Length != 0)
            {                
                rowFromTempDataTable["Phone"] = rowsWithPhone[0]["PhoneNumber"];
                rowFromTempDataTable["Type"] = rowsWithPhone[0]["Type"];
                rowFromTempDataTable["Note"] = rowsWithPhone[0]["Note"];
                tempDataTable.Rows.Add(rowFromTempDataTable);
                this.GridViewTypeEmailNote.DataSource = tempDataTable;
                this.GridViewTypeEmailNote.DataBind(); 
            }
            else
            {
                rowFromTempDataTable["Phone"] = "No Number";
                rowFromTempDataTable["Type"] = "No Type";
                rowFromTempDataTable["Note"] = "No Note";
                tempDataTable.Rows.Add(rowFromTempDataTable);
                this.GridViewTypeEmailNote.DataSource = tempDataTable;
                this.GridViewTypeEmailNote.DataBind(); 
            }

        }
    }
}