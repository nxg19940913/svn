using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace json操作
{
    class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Age { get; set; }
        public List<nxg> NxgList { get; set; }
        public override string ToString()
        {
            return string.Format("Name: {0}, Level: {1}, Age: {2}, nxgList: {3}", Name, Level, Age, NxgList);
        }
    }
}
