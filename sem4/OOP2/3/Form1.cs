using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static _2.Account;

namespace _2
{
    public partial class Form1 : Form
    {
        public Form1() 
        {
            InitializeComponent();

            try
            {
                using (FileStream fs = new FileStream("AccountData.xml", FileMode.OpenOrCreate))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Account>));
                    List<Account> data = (List<Account>)xml.Deserialize(fs);
                    this.DB = data;
                }
            } catch { };

            this.label10.Text = "Размер: " + DB.Count;

        }

        public List<Account> DB = new List<Account>();

        private User createUser() 
        {
            User user = new User();

            user.FullName = this.textBox2.Text;
            user.FlagInternet = this.checkBox1.Checked;
            user.FlagFriends = this.checkBox2.Checked;
            user.FlagOther = this.checkBox3.Checked;
            user.BirthDate = this.monthCalendar1.TodayDate;

            return user;
        }

        private Account createAccount(User owner) 
        {
            Account acc = new Account();

            acc.Number = Convert.ToInt32(this.textBox1.Text);
            acc.Balance = Convert.ToInt32(this.numericUpDown1.Value);
            acc.Type = this.comboBox1.SelectedIndex == 1 ? InvestType.debet : InvestType.credit;
            acc.Date = this.dateTimePicker1.Value;
            acc.EnableSms = this.checkBox1.Checked;
            acc.Owner = owner;

            return acc;
        }

        private void UpdateFields(User user, Account acc) 
        {
            this.textBox1.Text = Convert.ToString(acc.Number);
            this.comboBox1.SelectedIndex = acc.Type == InvestType.debet ? 1 : 0;
            this.numericUpDown1.Value = Convert.ToInt32(acc.Balance);
            this.dateTimePicker1.Value = acc.Date;

            if (acc.EnableSms)
            {
                this.radioButton1.Checked = true;
            }
            else 
            { 
                this.radioButton2.Checked = true;
            }

            this.textBox2.Text = user.FullName;
            this.checkBox1.Checked = user.FlagInternet;
            this.checkBox2.Checked = user.FlagFriends;
            this.checkBox3.Checked = user.FlagOther;
            this.monthCalendar1.TodayDate = user.BirthDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = createUser();
            Account acc = createAccount(user);
            
            acc.Serialize(this);

            this.label10.Text = "Размер: " + DB.Count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Account account = Account.Deserialize();
            User user = account.Owner;

            UpdateFields(user, account);
        }

        private bool validateInput(TextBox textBox) 
        {
            return !String.IsNullOrEmpty(textBox.Text);
        }

        private void validateTextBox(object sender) 
        {
            var target = (TextBox)sender;

            if (validateInput(target))
            {
                target.BackColor = Color.White;
            }
            else
            {
                target.BackColor = Color.LightPink;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validateTextBox(sender);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            validateTextBox(sender);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SearchMenu searchMenu = new SearchMenu(this.DB);
            searchMenu.Show(this);
        }

        private void toolStripTextBox5_Click(object sender, EventArgs e)
        {
            var sortedAccounts = DB.OrderBy(account => account.Type).ToList();


            Result res = new Result(sortedAccounts);
            res.Show();
        }

        private void toolStripTextBox6_Click(object sender, EventArgs e)
        {
            var sortedAccounts = DB.OrderBy(account => account.Date).ToList();


            Result res = new Result(sortedAccounts);
            res.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        //private void textBox3_TextChanged(object sender, EventArgs e)
        //{
        //    PassportValidate passportValidate = new PassportValidate(this.textBox3.Text);
        //    var validationContext = new ValidationContext(passportValidate);
        //    var validationResults = new List<ValidationResult>();
        //    if (!Validator.TryValidateObject(passportValidate, validationContext, validationResults, true))
        //    {
        //        textBox3.BackColor = Color.Red;
        //    }
        //    else
        //    {
        //        textBox3.BackColor = Color.White;
        //    }
        //}


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1_Click(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripTextBox5_Click(sender, e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.comboBox1.Text = "";
            this.numericUpDown1.Value = 0;
            this.dateTimePicker1.Text = "";

            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;

            this.textBox2.Text = "";

            this.checkBox1.Checked = false;
            this.checkBox2.Checked = false;
            this.checkBox3.Checked = false;

            this.monthCalendar1.SetDate(DateTime.Today);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (toolStrip1.Visible)
            {
                toolStrip1.Visible = false;
            }
            else
            {
                toolStrip1.Visible = true;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.DB.Clear();
        }
    }
}
