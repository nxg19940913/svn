using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace json操作
{
    class nxg
    {
        public int id;
        public string name;
        public int damage;

        public override string ToString()
        {
            return string.Format("Id: {0}, Damage: {1}, Name: {2}", id, damage, name);
        }
    }
}
