using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS280s2_A2_Part2
{
    public partial class Form3 : Form
    {


        private string[] p;
        Form1 form1;
        public bool freeError = false;
        public Form3(string[] p, Form1 form1)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.p = p;
            this.form1 = form1;
            textBox1.Text = p[0];
            textBox2.Text = p[1];
            textBox3.Text = p[2];
            textBox4.Text = p[3];

           

        }



      
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                p[0] = textBox1.Text;
                p[1] = textBox2.Text;
                p[2] = textBox3.Text;
                p[3] = textBox4.Text;
                double Num;
                if (p.Length < 4)
                {

                    throw new Exception("ERROR - HAVING LESS THAN FOUR FIELDS.");
                }
                else if (p[3].Trim().Length <= 1 || p[2].Trim().Length <= 1 ||
                    p[1].Trim().Length <= 1 || p[0].Trim().Length <= 1)
                {

                    throw new Exception("ERROR - FIELDS MAY NULL.");

                }

                /* Client Number
                 * Invalid check digit 
                 */
                else if (!isLuhn(p[0].Trim()))
                {

                    throw new Exception("ERROR - INVALID CHECK DIGITS.");

                }

                /* Transaction Type
                 * Invalid type code (anything but ‘Cr’ or ‘Dr’)
                 */
                else if (p[1].Trim() != "Cr" && p[1].Trim() != "Dr")
                {

                    throw new Exception("ERROR - INVALID TRANSACTION TYPE CODE.");

                }

                /* Transaction Date Missing 
                 * Invalid 
                 * Out of range (before 1 January 2011 or after 31 December 2012)
                 */
                else if (!checkTimeBefore(p[2].Trim()) || !checkTimeAfter(p[2].Trim()))
                {

                    throw new Exception("ERROR - DATATIME OUT OF RANGE.");

                }

                /* Transaction Amount
                 * check non-numeric, Zero,>=5000
                 * Negative, Missing
                 */
                else if (!double.TryParse(p[3].Trim(), out Num))
                {

                    throw new Exception("ERROR - TRANSACTION AMOUNT NON-NUMERIC.");

                }
                else if (Convert.ToDouble(p[3].Trim()) <= 0 || Convert.ToDouble(p[3].Trim()) >= 5000)
                {

                    throw new Exception("ERROR - TRANSACTION AMOUNT OUT OF RANGE.");

                }

                MessageBox.Show("All Fields With Non-ERROR", "Successful", MessageBoxButtons.OK);
                freeError = true;
            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message, "Warning", MessageBoxButtons.OK);


            }
        }
        private bool isLuhn(string number)
        {
            int checksum = 0;
            int[] DELTAS = new int[] { 0, 1, 2, 3, 4, -4, -3, -2, -1, 0 };

            char[] chars = number.ToCharArray();
            foreach (char c in chars)
            {
                //Console.WriteLine(c);
            }

            for (int i = chars.Length - 1; i > -1; i--)
            {
                int j = ((int)chars[i]) - 48;
                checksum += j;

                if (((i + 1) % 2) == 0)
                {
                    checksum += DELTAS[j];
                }
            }
            //   Console.WriteLine(checksum);
            return ((checksum % 10) == 0);
        }

        private bool checkTimeBefore(string tempDate)
        {
            int dt = 0;
            try
            {
                DateTimeFormatInfo ukDtfi = new CultureInfo("en-GB", false).DateTimeFormat;
                DateTime checkDate = new DateTime(2011, 1, 1, 0, 0, 0);
                DateTime curDate = Convert.ToDateTime(tempDate, ukDtfi);
                dt = DateTime.Compare(curDate, checkDate);
            }
            catch (Exception e)
            {
                return false;
            }
            return (dt > 0);
        }
        private bool checkTimeAfter(string tempDate)
        {
            int dt = 0;
            try
            {
                DateTimeFormatInfo ukDtfi = new CultureInfo("en-GB", false).DateTimeFormat;
                DateTime checkDate = new DateTime(2012, 12, 31, 12, 0, 0);
                DateTime curDate = Convert.ToDateTime(tempDate, ukDtfi);
                dt = DateTime.Compare(curDate, checkDate);
            }
            catch (Exception e)
            {
                return false;
            }
            return (dt < 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (p[0].Equals(textBox1.Text) && p[1].Equals(textBox2.Text) && p[2].Equals(textBox3.Text) && p[3].Equals(textBox4.Text))
            {

                form1.freeError = freeError;
                p[0] = textBox1.Text;
                p[1] = textBox2.Text;
                p[2] = textBox3.Text;
                p[3] = textBox4.Text;
                form1.myCollection = new List<string>();
                foreach (string s in p)
                {
                    form1.myCollection.Add(s);
                }
                this.Hide();

            }
            else {
                MessageBox.Show("Please Revalidate your data", "Warning", MessageBoxButtons.OK);
                freeError = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
