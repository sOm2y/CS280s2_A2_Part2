using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS280s2_A2_Part2
{
    public partial class Form1 : Form
    {
        public bool freeError = false;
        public List<string> myCollection;
        public bool fileOpened = false;

        public string credit;
        public string debit;
        public string error;
        public object dataSave;
        string sdFileName;

        public Form1()
        {

            InitializeComponent();

        }


        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            DialogResult result = f2.ShowDialog();


            if (credit != null && !fileOpened)
            {

                openFile(credit);

                openFile(debit);
                
                openFile(error);
                fileOpened = true;
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                sdFileName = saveFileDialog.FileName;
                Console.WriteLine(sdFileName.ToString());
                saveToFile();
            }

        }
        private void saveToFile()
        {
            if (Transaction.SelectedTab == Transaction.TabPages["tabPage1"])
            {
                StreamWriter sw = new StreamWriter(sdFileName, false);
                try
                {

                    string temp = "";
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        temp = "";
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            temp += (dataGridView1[j, i]).Value;
                            if (j != dataGridView1.ColumnCount - 1)
                                temp += ",";
                        }
                        sw.WriteLine(temp);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    sw.Close();
                    
                }
            }
            else if (Transaction.SelectedTab == Transaction.TabPages["tabPage2"])
            {
                StreamWriter sw = new StreamWriter(sdFileName, false);
                try
                {

                    string temp = "";
                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        temp = "";
                        for (int j = 0; j < dataGridView2.ColumnCount; j++)
                        {
                            temp += (dataGridView2[j, i]).Value;
                            if (j != dataGridView2.ColumnCount - 1)
                                temp += ",";
                        }
                        sw.WriteLine(temp);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    sw.Close();
                    
                }
            }
            else if (Transaction.SelectedTab == Transaction.TabPages["tabPage3"])
            {
                StreamWriter sw = new StreamWriter(sdFileName, false);
                try
                {

                    string temp = "";
                    for (int i = 0; i < dataGridView3.RowCount; i++)
                    {
                        temp = "";
                        for (int j = 0; j < dataGridView3.ColumnCount; j++)
                        {
                            temp += (dataGridView3[j, i]).Value;
                            if (j != dataGridView3.ColumnCount - 1)
                                temp += ",";
                        }
                        sw.WriteLine(temp);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    sw.Close();
                    
                }
            }           
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Transaction.SelectedTab == Transaction.TabPages["tabPage1"])
            {
                sdFileName = error;
                saveToFile();
            }
            if (Transaction.SelectedTab == Transaction.TabPages["tabPage2"])
            {
                sdFileName = credit;
                saveToFile();
            }
            if (Transaction.SelectedTab == Transaction.TabPages["tabPage3"])
            {
                sdFileName = debit;
;
                saveToFile();
            }
            Transaction.TabPages["tabPage1"].Text = "Error Transaction";
            Transaction.TabPages["tabPage2"].Text = "Credit Transaction";
            Transaction.TabPages["tabPage3"].Text = "Debit Transaction";
            saveToolStripMenuItem.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openFile(string path)
        {
            
            StreamReader sr = new StreamReader(path);

           
            string temp;
            try
            {

                while (true)
                {
                    temp = sr.ReadLine();

                    if (temp == null)
                        break;
                    string[] s = temp.Trim().Split(',');
                    if (s[0].Length <= 1)
                        continue;

                    if (path.Contains("ErrorFile.txt"))
                    {
                        createColumnsInEr();
                        if (s.Length < 4)
                        {
                            List<string> tempError = new List<string>();
                            tempError = s.ToList();
                            tempError.Add(" Missing");
                            s = tempError.ToArray();
                            Console.WriteLine(s.Length);

                        }
                            for (int i = 0; i < s.Length; i++)
                            {
                                if (s[i].Trim().Length < 1)
                                {
                                    s[i] = " Missing";
                                }

                            }
                        
                       
                        dataGridView1.Rows.Add(s);
                    }
                    else if (path.Contains("CreditFile.txt"))
                    {
                        createColumnsInCr();

                        dataGridView2.Rows.Add(s);
                        

                    }
                    else if (path.Contains("DebitFile.txt"))
                    {
                        createColumnsInDr();
                        dataGridView3.Rows.Add(s);


                    }

                }
              
                saveAsToolStripMenuItem.Visible = true;
                saveToolStripMenuItem.Visible = true;
                Transaction.Visible = true;
                
                sr.Close();
            }

            catch (Exception e)
            {
                dataGridView1.Visible = false;
               
                MessageBox.Show(e.Message);
            }
        }


        public void createColumnsInEr()
        {
            dataGridView1.Visible = true;
            
            dataGridView1.ColumnCount = 4;
            dataGridView1.ColumnHeadersVisible = true;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Set the column header names.
            dataGridView1.Columns[0].Name = "Client Number";
            dataGridView1.Columns[1].Name = "Transaction Type";
            dataGridView1.Columns[2].Name = "Transaction Date";
            dataGridView1.Columns[3].Name = "Transaction Amount";


            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }
        private void createColumnsInCr()
        {
         
            dataGridView2.Visible = true;
            
            dataGridView2.ColumnCount = 4;
            dataGridView2.ColumnHeadersVisible = true;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Set the column header names.
            dataGridView2.Columns[0].Name = "Client Number";
            dataGridView2.Columns[1].Name = "Transaction Type";
            dataGridView2.Columns[2].Name = "Transaction Date";
            dataGridView2.Columns[3].Name = "Transaction Amount";


            dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void createColumnsInDr()
        {
            dataGridView3.Visible = true;
           
            dataGridView3.ColumnCount = 4;
            dataGridView3.ColumnHeadersVisible = true;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView3.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Set the column header names.
            dataGridView3.Columns[0].Name = "Client Number";
            dataGridView3.Columns[1].Name = "Transaction Type";
            dataGridView3.Columns[2].Name = "Transaction Date";
            dataGridView3.Columns[3].Name = "Transaction Amount";


            dataGridView3.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void correct_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Enabled = true;
            try
            {
                myCollection = new List<string>();
                for (int i = 0; i < 4; i++)
                {
                    myCollection.Add(dataGridView1.SelectedRows[0].Cells[i].Value.ToString());
                    

                }
                int indexSelectedRow = dataGridView1.SelectedRows[0].Index;
                Form3 form3 = new Form3(myCollection.ToArray(), this);

                form3.ShowDialog();

                if (freeError)
                {
                    foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                    {
                        dataGridView1.Rows.RemoveAt(item.Index);
                    }
                    if (myCollection.ToArray()[1].Trim() == "Cr")
                    {
                        dataGridView2.Rows.Add(myCollection.ToArray());
                        Transaction.TabPages["tabPage2"].Text = Transaction.TabPages["tabPage2"].Text + "*";
                    }
                    else if (myCollection.ToArray()[1].Trim() == "Dr")
                    {
                        dataGridView3.Rows.Add(myCollection.ToArray());
                        Transaction.TabPages["tabPage3"].Text =  Transaction.TabPages["tabPage3"].Text+"*";
                    }


                }
                else
                {

                    for (int i = 0; i < 4; i++)
                    {
                        dataGridView1.SelectedRows[0].Cells[i].Value = myCollection.ToArray()[i];
                        Console.WriteLine(dataGridView1.SelectedRows[0].Cells[i].Value.ToString());
                    }
                    Transaction.TabPages["tabPage1"].Text =  Transaction.TabPages["tabPage1"].Text+"*";
                }

            }
            catch (Exception error)
            {

                MessageBox.Show("Please Load File First \n" + error.Message, "Warning", MessageBoxButtons.OK);
            }
            saveToolStripMenuItem.Enabled = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




    }

}
