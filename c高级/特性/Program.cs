#define IsTest //定义一个宏 表示该方法可以继续使用 必须定义在第一行 可以用于测试代码的 定义

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace 特性
{
    class Program
    {
        #region Obsolete 弃用方法

        //[Obsolete("这个方法过时了，使用Test2代替")]
        //static void Test()
        //{
        //    Console.WriteLine("这个方法被弃用");
        //}
        //[Obsolete("这个方法不让用了",true)]//如果添加true 表示 不让使用了
        //static void Test2()
        //{
        //    Console.WriteLine("这个方法被弃用");
        //}
        #endregion
        #region Contional 特性
         
            [Conditional("IsTest")] //该方法想要继续使用 就必须定义宏 该方法虽然不会被调用 但还是会编译
         static void Test1()
        {
            Console.WriteLine("t1");
        }
        static void Test2()
        {
            Console.WriteLine("t2");
        }
        #endregion
        #region  调用者信息特性

        //                        掉的方法                调用的 类名      调用的行数
        static void PrintOut(string str,[CallerFilePath] string fileName="",[CallerLineNumber] int lineNumber=0,
            [CallerMemberName]string methodName="") {
            Console.WriteLine(str);
            Console.WriteLine(fileName);
            Console.WriteLine(lineNumber);
            Console.WriteLine(methodName);
        }
        #endregion
        [DebuggerStepThrough]//加在方法前面 调试时 如果确定该方法没有错误是 使用这个 可以不进行调试
        static void DebugTest()
        {
            Console.WriteLine("de");
        }
        static void Main(string[] args)
        {
            #region Ovsolete特性 表示方法已弃用
            //Test();//会有提示 后面加 括号表示提示内容
            ////Test2(); 会报错
            #endregion
            #region contional  
            Test1();
            Test2();
            #endregion
            #region 调用者信息特性 可以获取这个方法 被谁调用的 在哪一行 被那个方法调用的
            //PrintOut("a");
                

            #endregion
        }
    }
}
