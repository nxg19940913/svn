using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 反射
{
    class Program
    {
        static void Main(string[] args)
        {
            #region type

            ////每一个类都对应一个type对象，这个type对象存储了这个类 有哪些方法 那些成员
            //MyClass my = new MyClass();
            //Type type = my.GetType();
            //Console.WriteLine(type.Name);//就是类名
            //Console.WriteLine(type.Namespace);//获取类的命名空间
            //Console.WriteLine(type.Assembly);//获取它的程序集
            //FieldInfo[] array = type.GetFields();//获取所有的字段 只能获取public的
            //foreach (var item in array)
            //{
            //    Console.WriteLine(item.Name);
            //}
            //PropertyInfo[] array2 = type.GetProperties();//获取所有的属性
            //foreach (var item in array2)
            //{
            //    Console.WriteLine(item.Name);
            //}
            //MethodInfo[] array3 = type.GetMethods();//获取所有的 方法
            //foreach (var item in array3)
            //{
            //    Console.WriteLine(item.Name);
            //}
            #endregion

            #region 程序集
            MyClass my = new MyClass();
            Assembly assembly = my.GetType().Assembly;//通过类的type对象获取它所在的程序集 
            Console.WriteLine(assembly.FullName);
            Type[] types = assembly.GetTypes();//获取程序集下面的所有 type
            foreach (var item in types)
            {
                Console.WriteLine(item);
            }
            #endregion
        }
    }
}
