using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;
using System.Web;

namespace Construction
{
    public partial class Form1 : Form
    {
        string serverConnection = "Provider=SQLOLEDB.1;" +
                                  "Integrated Security=SSPI;" +
                                  "Persist Security Info=False;" +
                                  "Initial Catalog=Construction Equipment;" +
                                  "Data Source=DESKTOP-HOME\\T8";
        OleDbConnection oleDBConnection;

        string codes = "";

        public Form1()
        {
            InitializeComponent();

            oleDBConnection = new OleDbConnection(serverConnection);
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(codes))
            {
                var r = MessageBox.Show("Do you want to save your codes?",
                                        "Save it and Make it Stay",
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName))
                        {
                            await streamWriter.WriteLineAsync(codes);
                        }
                    }
                }
                else if (r == DialogResult.Cancel) e.Cancel = true;
            }
        }

        void ExecuteQuery(string query)
        {
            OleDbCommand oleDBCommand = new OleDbCommand(query, oleDBConnection);
            oleDBConnection.Open();
            bool isSuccessful = oleDBCommand.ExecuteNonQuery() > 0 ? true : false;

            if (isSuccessful) MessageBox.Show("Record Applied.", "Commands Completed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Something Went Wrong!", "Serious E", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void ShowQuery(string query)
        {
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(query, serverConnection);
            DataSet data = new DataSet();
            oleDbDataAdapter.Fill(data);
            dataGridView1.DataSource = data.Tables[0];
        }

        string SpecifyTable()
        {
            string table = "";
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    table = "Customer";
                    break;
                case 1:
                    table = "Order";
                    break;
                case 2:
                    table = "Order Detail";
                    break;
                case 3:
                    table = "Stuff";
                    break;
                case 4:
                    table = "Instalment";
                    break;
                case 5:
                    table = "Instalment Detail";
                    break;
            }
            return table;
        }

        void AddLog(string query) => codes += query + "\r\n";

        string InsertionQueryGen(string textBoxName, string table, int countOfTableAttributes)
        {
            string s = $"insert into {table} values (";
            string[] att = new string[countOfTableAttributes];
            for (int i = 1; i <= countOfTableAttributes; i++)
            {
                TextBox textBox = Controls.Find(textBoxName + i, true)[0] as TextBox;
                att[i - 1] = $"N'{textBox.Text}'";
            }
            return s + string.Join(", ", att) + ')';
        }

        bool AnyTextBoxesEmptyError(string textBoxName, int maxCount)
        {
            for (int i = 1; i <= maxCount; i++)
            {
                TextBox textBox = Controls.Find(textBoxName + i, true)[0] as TextBox;
                if (string.IsNullOrEmpty(textBox.Text)) return true;
            }
            return false;
        }

        #region Buttons
        private void show_Click(object sender, EventArgs e)
        {
            ShowQuery($"select * from [{SpecifyTable()}]");
        }

        private void customerInsert_Click(object sender, EventArgs e)
        {
            if (AnyTextBoxesEmptyError("customerBox", 5))
            {
                MessageBox.Show("Can't Enter Empty Value!", "Serious E", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string s = InsertionQueryGen("customerBox", "customer", 5);
            AddLog(s);
            ExecuteQuery(s);
        }

        private void stuffInsert_Click(object sender, EventArgs e)
        {
            if (AnyTextBoxesEmptyError("stuffBox", 3))
            {
                MessageBox.Show("Can't Enter Empty Value!", "Serious E", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string s = InsertionQueryGen("stuffBox", "stuff", 3);
            AddLog(s);
            ExecuteQuery(s);
        }
        #endregion

        private void orderSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(orderBoxStuffSearch.Text))
            {
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter($"select name from stuff where [Name] like N'%{orderBoxStuffSearch.Text}%'", serverConnection);
                DataSet data = new DataSet();
                oleDbDataAdapter.Fill(data);
                orderListBoxStuffSearch.Items.Clear();
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    orderListBoxStuffSearch.Items.Add(data.Tables[0].Rows[i].ItemArray[0]);
                }
            }
        }
    }
}
