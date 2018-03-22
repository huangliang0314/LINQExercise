using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEntity
{
    [Serializable]
    public class Racer:IComparable<Racer>,IFormattable
    {
        #region " 构造函数"

        public Racer(string firstName,string lastName,string country,int starts,int wins):this(firstName,lastName,country,starts,wins,null,null)
        {

        }

        public Racer(string firstName, string lastName, string country, int starts, int wins,IEnumerable<int> years,IEnumerable<string> cars)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.country = country;
            this.starts = starts;
            this.wins = wins;
            this.years = new List<int>(years);
            this.cars = new List<string>(cars);
        }

        #endregion

        #region "  Variable"
        /// <summary>
        /// 
        /// </summary>
        private string firstName;
        /// <summary>
        /// 
        /// </summary>
        private string lastName;
        /// <summary>
        /// 获胜次数
        /// </summary>
        private int wins;
        private string country;
        /// <summary>
        /// 开始年份
        /// </summary>
        private int starts;
        private IEnumerable<string> cars;
        private IEnumerable<int> years;


        #endregion

        #region "  Property"
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        /// <summary>
        /// 获胜次数
        /// </summary>
        public int Wins { get => wins; set => wins = value; }
        public string Country { get
            { return country; } set => country = value; }
        /// <summary>
        /// 开始年份
        /// </summary>
        public int Starts { get => starts; set => starts = value; }
        public IEnumerable<string> Cars { get => cars; set => cars = value; }
        public IEnumerable<int> Years { get => years; set => years = value; }

        #endregion


        #region "  函数"
        public override string ToString()
        {
            return string.Format("{0}  {1}", firstName, lastName);
        }

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case null:
                case "N":
                    return ToString();
                    break;
                case "F":
                    return firstName;
                    break;
                case "L":
                    return lastName;
                    break;
                case "C":
                    return country;
                    break;
                case "S":
                    return starts.ToString();
                    break;
                case "W":
                    return wins.ToString();
                    break;
                case "A":
                    return string.Format("{0} {1}, {2}; starts:{3}, wins:{4}",firstName,lastName,country,starts,wins);
                    break;
                default:
                    return "";
            }
        }

        public int CompareTo(Racer other)
        {
            if (other == null) return -1;
            return string.Compare(this.lastName, other.lastName);
        }
        #endregion
    }
}
