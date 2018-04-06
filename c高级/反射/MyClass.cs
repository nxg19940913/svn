using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 反射
{
    class MyClass
    {
        private int id;
        private int age;
        public int num;
         public string Name { get; set; }
        public string Name1{ get; set; }
        public string Name2 { get; set; }
        public void Test1() {
            Console.WriteLine("t1");
        }
        private void Test2() {
        }
    }
}
