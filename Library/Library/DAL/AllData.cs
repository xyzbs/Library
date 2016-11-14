using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
   [AttributeUsage(AttributeTargets.Property,Inherited =true)]
    public class AllData : Attribute
    {
        public static  string strDsc;
        public static  bool judge;
        public  static int rand;
        public static bool judge2;
        public AllData(string sqlcom,bool judgement,int random)
        {
            strDsc = sqlcom;
            judge = judgement;
            rand = random;
        }      
        //获取操作字符串
        public  string sqlcom
        {
            get
            {
                return strDsc;
            }
            set
            {
                strDsc = value;
            }
        }
        //获取随机数
        public  int random
        {
            get
            {
                return rand;
            }
            set
            {
                rand = value;
            }
        }
        //获取bool值
        public  bool judgement
        {
            get
            {
                return judge;
            }
            set
            {
                judge = value;
            }
        }     
    }
}