using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADO.NET_FinalTask
{
    public partial class Form1 : Form
    {
        private SqlConnection connection = new SqlConnection($"Persist Security Info=False;User ID={ServerConnection.login}; Password={ServerConnection.password};Initial Catalog=Northwind;Data Source={ServerConnection.name}");
        private SqlDataAdapter adapter;
        private DataSet dataset = new DataSet("Northwind");
        private DataTable table = new DataTable("Customers");

    


        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("select * from Customers", connection);
            dataset.Tables.Add(table);
            adapter.Fill(dataset.Tables["Customers"]);

            dataGridCustomers.DataSource = dataset.Tables["Customers"];
            SqlCommandBuilder commands = new SqlCommandBuilder(adapter);

            ((DataGridViewTextBoxColumn)dataGridCustomers.Columns[0]).MaxInputLength = 5;
            ToolTip tt_delete = new ToolTip();
            tt_delete.SetToolTip(buttonDelete, "Выделите строки для удаления");

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {


            foreach (DataGridViewRow item in dataGridCustomers.SelectedRows)
            {
                dataGridCustomers.Rows.RemoveAt(item.Index);
            }
            try
            {
                adapter.Update(dataset, "Customers");
            }
            catch (Exception ex)
            {
                dataset.Clear();
                adapter.Fill(dataset, "Customers");
                dataGridCustomers.DataSource = dataset.Tables["Customers"];
                MessageBox.Show($"Данный CustomerID имеет запись в таблице Orders. Выберите другую строку для удаления. \n Ошибка: {ex.Message}", "Невозможно удалить запись",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            this.dataGridCustomers.CellValidating += new
        DataGridViewCellValidatingEventHandler(dataGridViewCustomers_CellValidating);
            this.dataGridCustomers.CellEndEdit += new
            DataGridViewCellEventHandler(dataGridViewCustomers_CellEndEdit);

           

            try
            {
                dataset.EndInit();
                adapter.Update(dataset.Tables["Customers"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                            
            }
        }

        private void dataGridViewCustomers_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            {
                string headerText =
                    dataGridCustomers.Columns[e.ColumnIndex].HeaderText;

                if (!headerText.Equals("CompanyName") && !headerText.Equals("CustomerID")) 
                    return;

                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dataGridCustomers.Rows[e.RowIndex].ErrorText =
                        "Поля CompanyName и CustomerID обязательны к заполнению!";
                    e.Cancel = true;
                }
              
            }
        }

        private void dataGridViewCustomers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
            dataGridCustomers.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void NotDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Поддерживается только ввод букв");
            }
        }

        private void dataGridViewCustomers_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(NotDigit_KeyPress);
            if (dataGridCustomers.CurrentCell.ColumnIndex == 0)
            {
                TextBox digit = e.Control as TextBox;
                if (digit != null)
                    digit.KeyPress += new KeyPressEventHandler(NotDigit_KeyPress);
            }
        }
    }
}
