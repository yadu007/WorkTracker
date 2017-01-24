using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTest
{
    public class Information
    {


        private List<string> newList = new List<string>();
        private List<string> newList2 = new List<string>();
        public List<string> NewList
        {
            get { return newList; }
            set { newList = value; }
        }

        public List<string> NewList2
        {
            get { return newList2; }
            set { newList2 = value; }
        }
    }
}
