using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEntity
{
    [Serializable]
   public class Team
    {

        public Team(string name, params int[] years)
        {
            this.name = name;
            this.years =new List<int>(years);
        }

        #region "  Variable"
        /// <summary>
        /// 车队名字
        /// </summary>
        private string name;
        /// <summary>
        /// 获胜年份集合
        /// </summary>
        private IEnumerable<int> years;


        #endregion

        #region "  Property"
        /// <summary>
        /// 车队名字
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 获胜年份集合
        /// </summary>
        public IEnumerable<int> Years { get => years; set => years = value; }
        #endregion


    }
}
