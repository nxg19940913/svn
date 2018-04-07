using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xml操作
{
    /// <summary>
    /// 技能类
    /// </summary>
    class nxg
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lang { get; set; }
        public int Dameage { get; set; }
        public override string ToString()
        {
            return string.Format("id:{0},name:{1},lang:{2},damage:{3}", Id, Name, Lang, Dameage);
        }
    }
}
