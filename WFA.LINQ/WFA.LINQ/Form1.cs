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
            ///找出赢得至少15场比赛的巴西和奥地利赛车手
            ///
             res = from racer in racers
                      where racer.Wins>=15 &&( racer.Country == "Brazil" || racer.Country == "Austria")
                      orderby racer.Wins descending
                      select racer.FirstName + " " + racer.LastName + "  " + racer.Country;
            this.listBox1.DataSource = Enumerable.ToList<string>(res);
            ///复合from子句
            res = from racer in racers
                  from car in racer.Cars
                  where car=="Ferrari"
                  orderby racer.Wins descending
                  select racer.FirstName + " " + racer.LastName + "  " + racer.Country;
            this.listBox1.DataSource = Enumerable.ToList<string>(res);


            //分组
           var res1 =( from racer in racers
                  group racer by racer.Country into g
                  select g).ToList();
            string res1111 = "";
           foreach(IGrouping<string,Racer> coun in res1)
            {
                res1111 +=Environment.NewLine+ coun.Key+":";
                int flag = 0;
                foreach (Racer r in coun.AsEnumerable<Racer>())
                {
                    if (flag == 0)
                    {
                        res1111 += string.Format( "{0:20}",r.FirstName);
                    }
                    else
                    {
                        res1111 += Environment.NewLine+ string.Format("{0:40}", r.FirstName);
                    }
                    flag++;
                }
            }
            this.richTextBox1.Text = res1111;

            //组链接
            var racer11 = Formulal.GetChampionships()
                .SelectMany(r => new List<RacerInfo>() {
                    new RacerInfo()
                    {
                        Year=r.Year,
                        Position=1,
                        FirstName=r.First.Substring(0,r.First.IndexOf(" ")),
                        LastName=r.First.Substring(r.First.IndexOf(" ")+1),
                    },
                    new RacerInfo()
                    {
                        Year=r.Year,
                        Position=2,
                        FirstName=r.Second.Substring(0,r.Second.IndexOf(" ")),
                        LastName=r.Second.Substring(r.Second.IndexOf(" ")+1),
                    },
                    new RacerInfo()
                    {
                        Year=r.Year,
                        Position=3,
                        FirstName=r.Third.Substring(0,r.Third.IndexOf(" ")),
                        LastName=r.Third.Substring(r.Third.IndexOf(" ")+1),
                    }
                });

        }

    }
}
