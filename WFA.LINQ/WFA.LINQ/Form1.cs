using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqEntity;

namespace WFA.LINQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<Racer> racers = Formulal.GetChampions() as List<Racer>;
            ///选取来自巴西的所有世界冠军
            var res = from racer in racers
                      where racer.Country == "Brazil" 
                      orderby racer.Wins descending
                      select  racer.FirstName +" " +racer.LastName + "  "+ racer.Country ;
            this.listBox1.DataSource = Enumerable.ToList<string>(res);
            Racer race = new Racer("Jochen", "Rindt", "Austria", 60, 6, new int[] { 1970 }, new string[] { "Lotus" });
            
        }

    }
}
