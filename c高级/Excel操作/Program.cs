using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel操作
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "装备信息.xls";
            string connecctoinString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";" + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            //创建连接到数据源的对象
            OleDbConnection connection = new OleDbConnection(connecctoinString);
            //打开连接
            connection.Open();
            string sql = "select * from [Sheet1$]";//这是一个查询命令 表示从 sheet1$查询 就是左下角
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql,connection);

            //用来存放数据（一般是用来存放表格的） 可以放很多张表格
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);//把查询结果填充到datatable中
            connection.Close();
            //取得数据
          DataTableCollection tableCollection =  dataSet.Tables;//获取当前集合中的所有表格
            DataTable dataTable = tableCollection[0];//因为只往 dataset中放了一张表格，座椅这里只取得索引为0的表格
            //取得表格中的数据
            //取得table中所有行 返回每一行的集合
            DataRowCollection rowColection = dataTable.Rows;
            //遍历取得每一行的datarow  默认取得的数据是没有第一行的
            foreach (DataRow item in rowColection)
            {
                //取得row中 前8列的数据 索引0-7
                for (int i = 0; i < 8; i++)
                {
                    Console.Write(item[i]+" ");
                }
                Console.WriteLine();
            }

        }
    }
}
