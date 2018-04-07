using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文件操作
{
    class Program
    {
        static void Main(string[] args)
        {
            // // FileInfo fileInfo = new FileInfo("TextFile1.txt");//表达方式有绝对路径和相对路径 
            //// FileInfo fileInfo = new FileInfo("G:\\svn\\c高级\\TextFile1.txt");//绝对路径得用双\\
            // FileInfo fileInfo = new FileInfo(@"G:\svn\c高级\TextFile2.txt");//获取使用@ 非转义
            // //判断文件是否存在 这里返回false 是因为 运行前会先编译 编译完程序会放到debug文件夹下面
            // //不在同一文件夹 所以会返回false 找不到文件
            // Console.WriteLine(fileInfo.Exists);//文件是否存在
            // Console.WriteLine(fileInfo.Name);//文件名加后缀
            // Console.WriteLine(fileInfo.Directory);//取得文件所在路径
            // Console.WriteLine(fileInfo.Length);//文件大小（字节）
            // Console.WriteLine(fileInfo.IsReadOnly);//是否是只读 这里是false 因为是可读可写

            // //方法
            // //fileInfo.Delete();//删除文件
            // //  fileInfo.CopyTo("tt.txt");//复制到当前目录下

            // FileInfo f = new FileInfo("nxg.txt");
            // //if (f.Exists == false)//如果文件不存在
            // //{
            // //    f.Create();//创建当前文件
            // //}
            // f.MoveTo("nxg1.txt");//剪切功能 这里相当于重命名
            //// Console.WriteLine("1");


            //文件夹操作
            //DirectoryInfo dirIndo = new DirectoryInfo(@"G:\svn\c高级\文件操作\bin\Debug");//查看dubug文件夹的信息
            //Console.WriteLine(dirIndo.Exists);//判断文件夹是否存在
            //Console.WriteLine(dirIndo.Name);
            //Console.WriteLine(dirIndo.Parent);//父目录
            //Console.WriteLine(dirIndo.Root);//根目录
            //Console.WriteLine(dirIndo.CreationTime);//创建时间

            //dirIndo.CreateSubdirectory("nxg");//创建文件夹

            //根据相对路径创建文件夹
            DirectoryInfo d1 = new DirectoryInfo("test");
            if (!d1.Exists)//如果文件夹不存在
            {
                d1.Create();//创建目录
               
            }
            
        }
    }
}
