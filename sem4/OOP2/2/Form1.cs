using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static _2.Account;

namespace _2
{
    public partial class Form1 : Form
    {
        public Form1() 
        {
            InitializeComponent();
            
        }

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
            
            acc.Serialize();
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
    }
}
