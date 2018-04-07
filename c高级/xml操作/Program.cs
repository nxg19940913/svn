using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace xml操作
{
    class Program
    {
        static void Main(string[] args)
        {
            List<nxg> nxgList = new List<nxg>();//创建技能信息集合，用来存储所有的技能信息
            //专门解析xml的类
            XmlDocument xml = new XmlDocument();
            //选择要加在解析的xml文档的名字
            // xml.Load("TextFile1.xml");
            xml.LoadXml(File.ReadAllText("TextFile1.xml"));//传递一个字符串（xml格式的字符串）
            //得到根节点 XmlNode代表一个节点
            XmlNode rooNode =  xml.FirstChild;//获取第一个节点 就是根节点

            //得到根节点下面的子节点集合
            XmlNodeList xmlNodeList = rooNode.ChildNodes;//获取当前节点下面的所有子节点

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                nxg n = new nxg();
                //字段节点的集合
                XmlNodeList fieldNodeList = xmlNode.ChildNodes;
                foreach (XmlNode fieldNode in fieldNodeList)//遍历每个字段
                {//通过name属性 可以得到节点的名字
                    if (fieldNode.Name == "id")
                    {
                      int id =int.Parse( fieldNode.InnerText);//获取节点内部的文本
                        n.Id = id;
                    }
                    else if(fieldNode.Name == "name")
                    {
                        string name = fieldNode.InnerText;
                        n.Name = name;
                        //获取一个节点的属性 这里获取的是一个集合 value 获取它的值
                       n.Lang = fieldNode.Attributes[0].Value;
                    }
                    else if (fieldNode.Name == "damage")
                    {
                        n.Dameage = int.Parse(fieldNode.InnerText);
                    }
                }
                //添加到集合中
                nxgList.Add(n);
            }
            foreach (var item in nxgList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
