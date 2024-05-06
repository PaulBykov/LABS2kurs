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

namespace _2
{
    public partial class Result : Form
    {
        public Result(List<Account> acc)
        {
            InitializeComponent();


            String ans = String.Empty;
            foreach(var account in acc)
            {
                ans += account.ToString() + "\n";
            }

            this.label1.Text = ans;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str = this.label1.Text;

            using (FileStream fs = new FileStream("LastSearch.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xml = new XmlSerializer(typeof(String));
                xml.Serialize(fs, str);
            }

        }
    }
}
