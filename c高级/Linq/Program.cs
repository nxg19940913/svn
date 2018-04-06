using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化武林高手
            var masterList = new List<MartialArtsMaster>()
            {
                new MartialArtsMaster() {Id = 1, Name = "黄蓉", Age = 18, Menpai = "丐帮", Kongfu = "打狗棒法", Level = 9},
                new MartialArtsMaster() {Id = 2, Name = "洪七公", Age = 70, Menpai = "丐帮", Kongfu = "打狗棒法", Level = 10},
                new MartialArtsMaster() {Id = 3, Name = "郭靖", Age = 22, Menpai = "丐帮", Kongfu = "降龙十八掌", Level = 10},
                new MartialArtsMaster() {Id = 4, Name = "任我行", Age = 50, Menpai = "明教", Kongfu = "葵花宝典", Level = 1},
                new MartialArtsMaster() {Id = 5, Name = "东方不败", Age = 35, Menpai = "明教", Kongfu = "葵花宝典", Level = 10},
                new MartialArtsMaster() {Id = 6, Name = "林平之", Age = 23, Menpai = "华山", Kongfu = "葵花宝典", Level = 7},
                new MartialArtsMaster() {Id = 7, Name = "岳不群", Age = 50, Menpai = "华山", Kongfu = "葵花宝典", Level = 8},
                new MartialArtsMaster() {Id = 8, Name = "令狐冲", Age = 23, Menpai = "华山", Kongfu = "独孤九剑", Level = 10},
                new MartialArtsMaster() {Id = 9, Name = "梅超风", Age = 23, Menpai = "桃花岛", Kongfu = "九阴真经", Level = 8},
                new MartialArtsMaster() {Id = 10, Name = "黄药师", Age = 23, Menpai = "梅花岛", Kongfu = "弹指神通", Level = 10},
                new MartialArtsMaster() {Id = 11, Name = "风清扬", Age = 23, Menpai = "华山", Kongfu = "独孤九剑", Level = 10}
            };
            //初始化武学
            var kongfuList = new List<Kongfu>()
            {
                new Kongfu() {Id = 1, Name = "打狗棒法", Power = 90},
                new Kongfu() {Id = 2, Name = "降龙十八掌", Power = 95},
                new Kongfu() {Id = 3, Name = "葵花宝典", Power = 100},
                new Kongfu() {Id = 4, Name = "独孤九剑", Power = 100},
                new Kongfu() {Id = 5, Name = "九阴真经", Power = 100},
                new Kongfu() {Id = 6, Name = "弹指神通", Power = 100}
            };
            //使用Linq做查询(表达式写法)
            //var res = from m in masterList //from后面设置查询的集合  m表示集合中的一个元素
            //          where m.Level > 8 //where后面是查询的条件
            //          select m.Name;//表示把m的集合返回

            //扩展方法的写法
            // var res =  masterList.Where(Test1);

            //使用lambda表达式
            //var res = masterList.Where(m => m.Level>8);//这里m就表示MartialArtsMaster

            //多条件查询
            //var res = from m in masterList //from后面设置查询的集合  m表示集合中的一个元素
            //         where m.Level > 8 && m.Menpai == "丐帮" //通过&&添加并列的条件 || 就是满足一个条件即可
            //         select m.Name;

            //多条件 扩展方法的写法
            // var res = masterList.Where(m => m.Level > 8 && m.Menpai == "丐帮");

            //联合查询
            //var res = from m in masterList
            //          from k in kongfuList
            //          where m.Kongfu == k.Name && k.Power>90 //限制条件 去笛卡尔积
            //          select new {id=m.Id, master = m.Name, kongfu = k.Name }; //创建一个新的对象返回

            //联合查询的扩展方法            这里表示这俩集合进行联合查询    输出的结果
            //var res = masterList.SelectMany(m => kongfuList, (m, k) => new { master = m, kongfu = k }).
            //    //过滤的条件
            //     Where(x => x.master.Kongfu == x.kongfu.Name && x.kongfu.Power > 90);

            //对查询结果进行排序
            //var res = from m in masterList
            //          where m.Level > 8 && m.Menpai == "丐帮"
            //          // orderby m.Id //按照id 排序 默认是从小到大排序的
            //          //orderby m.Id descending //改成倒序
            //          orderby m.Id,m.Age//多个字段进行排序 如果id 相同 会根据age进行排序
            //          select m;

            //扩展方法排序                                      根据年龄排序          多字段排序  这里表示在前一个字段相同的情况下 再进行排序
            //var res = masterList.Where(m => m.Level > 8 && m.Menpai == "丐帮").OrderBy(m => m.Age).ThenBy(m => m.Id);

            //join on 集合联合  join 后面是 和哪个集合进行连接 on后面是 连接条件
            //var res = from m in masterList
            //          join k in kongfuList on m.Kongfu equals k.Name
            //          where k.Power > 90
            //          select new { master = m, kongfu = k };

            //联合查询 对结果进行分组
            //var res = from k in kongfuList
            //          join m in masterList on k.Name equals m.Kongfu
            //          into groups //into 分组 groups 组的名称 可以自定 哪个集合写在前面就表示以哪个集合进行分组
            //          orderby  groups.Count() descending
            //          select new { kong = k,count = groups.Count()};

            //按照自身字段分组 group
            //var res = from m in masterList
            //          group m by m.Menpai into g //根据 m里面的 门派进行分组
            //          select new { count = g.Count(),g.Key };//g.key 表示是按照哪个属性进行分的组

            //foreach (var temp in res)
            //{
            //    Console.WriteLine(temp);
            //}
            //量词操作符 返回一个bool 只要有一个满足条件的 就返回true
          bool res =  masterList.Any(m => m.Menpai == "丐帮");
            //all表示 这里面的条件都满足才返回true
          bool res1 =  masterList.All(m => m.Menpai == "丐帮");


        }

        //过滤方法
        private static bool Test1(MartialArtsMaster master) {
            if (master.Level > 8)
            {
                return true;
            }
            else {
                return false;
            }
            
        }
    }
}
