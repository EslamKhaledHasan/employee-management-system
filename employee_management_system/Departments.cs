using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace employee_management_system
{
    public partial class Departments : Form
    {
        functions Con;
             
        public Departments()
        {
            InitializeComponent();
            Con = new functions();
            ShowDepartments();
        }
        private void ShowDepartments()
        {
            string Query = "Select * from DepartmentTb1";
            DepList.DataSource = Con.GetData(Query);
        }
        int key = 0;

        private TextBox GetDepNameTb()
        {
            return DepNameTb;
        }

       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    String Query = "insert into DepartmentTb1 values('{0}')";
                    Query = string.Format(Query, DepNameTb.Text);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department added");
                    DepNameTb.Text = "";

                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
       
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    String Query = "Update DepartmentTb1 set DepName = '{0}' Where DepId = {1}";
                    Query = string.Format(Query, DepNameTb.Text,key);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Ubdated");
                    DepNameTb.Text = "";

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DepNameTb.Text = DepList.SelectedRows[0].Cells[0].Value.ToString();
            if (DepNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DepList.SelectedRows[0].Cells[0].Value.ToString());
            }

        }
    }
}
