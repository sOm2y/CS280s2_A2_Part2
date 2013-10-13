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
    
    public partial class Form2 : Form
    {

        string test;
        Form1 form1;
        public Form2(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
            string binpath = Path.GetDirectoryName(Application.ExecutablePath);

           DirectoryInfo d = Directory.GetParent(binpath).Parent.Parent.Parent;
            textBox1.Text =d.FullName+@"\CreditFile.txt";
            textBox2.Text = d.FullName + @"\DebitFile.txt";
            textBox3.Text = d.FullName + @"\ErrorFile.txt";
            test = d.FullName + @"\CreditFile.txt";
            
        }

      

        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
           
             DialogResult result =  openFileDialog.ShowDialog();
             if (result == DialogResult.OK) // Test result.
             {
                 textBox1.Text = openFileDialog.FileName;
             }
            
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                textBox1.Text = openFileDialog2.FileName;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (!test.Equals(textBox1.Text))
                {//if path change, we can now load it.
                    form1.fileOpened = false;
                }
                form1.credit = textBox1.Text;
                form1.debit = textBox2.Text;

                form1.error = textBox3.Text;


                this.Hide();
            }
            catch (Exception info) {
                MessageBox.Show( info.Message, "Warning", MessageBoxButtons.OK);
            }
         
        }
       
    }
   
}
