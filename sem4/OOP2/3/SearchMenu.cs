using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public partial class SearchMenu : Form
    {
        public List<Account> DB;
        public SearchMenu(List<Account> DB)
        {
            InitializeComponent();
            this.DB = DB;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String number = this.textBox_number.Text;
            String name = this.textBox_name.Text;
            int type = this.comboBox_type.SelectedIndex;
            String balance = this.textBox_balance.Text;

            Regex numberRegex = new Regex("^" + (number), RegexOptions.IgnoreCase);
            Regex nameRegex = new Regex("^" + name, RegexOptions.IgnoreCase);
            Regex balanceRegex = new Regex("^" + balance, RegexOptions.IgnoreCase);

            var filteredAccounts = DB.Where(account =>
            (string.IsNullOrEmpty(number) || numberRegex.IsMatch(account.Number.ToString())) &&
            (string.IsNullOrEmpty(name) || nameRegex.IsMatch(account.Owner.FullName)) &&
            (type < 0 || account.Type == (type == 0 ? Account.InvestType.credit : Account.InvestType.debet)) &&
            (string.IsNullOrEmpty(balance) || decimal.TryParse(balance, out var balanceValue) && account.Balance == balanceValue)
            ).ToList();

            Result result = new Result(filteredAccounts);
            result.Show(this);
        }
    }
}
