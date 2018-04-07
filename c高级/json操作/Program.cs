using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace json操作
{
    class Program
    {
        static void Main(string[] args)
        {
            ////使用litjson进行解析json文件
            ////得到json文件 jsonData:代表一个数组或一个对象 这里代表一个数组
            //JsonData jsonData = JsonMapper.ToObject(File.ReadAllText("json技能信息.json"));
            //// 一般会把数据用于对象封装 添加进一个集合
            //foreach (JsonData item in jsonData)//item 这里代表一个对象
            //{
            //    JsonData idValue = item["id"];//通过字符串索引器可以取得键值对的值
            //    JsonData nameValue = item["name"];
            //    JsonData damageValue = item["damage"];
            //    int id = int.Parse(idValue.ToString());//tostring方法的字符串
            //    Console.WriteLine(nameValue); 

            //}

            //使用泛型去解析json
            //nxg[] nxgs = JsonMapper.ToObject<nxg[]>(File.ReadAllText("json技能信息.json"));
            // foreach (var item in nxgs)
            // {
            //     Console.WriteLine(item);
            // }
            // List<nxg> nxgList= JsonMapper.ToObject<List<nxg>>(File.ReadAllText("json技能信息.json"));
            // foreach (var item in nxgList)
            // {
            //     Console.WriteLine(item);
            // }

            //Player player = JsonMapper.ToObject<Player>(File.ReadAllText("主角信息.json"));
            // Console.WriteLine(player);
            // foreach (var item in player.NxgList)
            // {
            //     Console.WriteLine(item);
            // }

            //把json装换成一个字符串
            Player player = new Player();
            player.Name = "花千骨";
            player.Level = 100;
            player.Age = 20;
           string json = JsonMapper.ToJson(player);
            Console.WriteLine(json);

        }
    }
}
