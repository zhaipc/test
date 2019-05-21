using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
     public class MD5Helper
    {
        public static string GetMD5(string txt)
        {
            //创建MD5对象
            MD5 mD5 = MD5.Create();//创建对象优先使用new 其次使用类.
            //将字符串转换为字节数组
            byte[] bs = Encoding.UTF8.GetBytes(txt);
            //加密操作
            byte[] bs2 = mD5.ComputeHash(bs);
            //将字节数组转换为字符串
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < bs2.Length; i++)
            {
                stringBuilder.Append(bs2[i].ToString("x2").ToLower());
            }
            return stringBuilder.ToString();
        }
    }
}
