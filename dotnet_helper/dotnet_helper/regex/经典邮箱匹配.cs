using System;
using System.Text.RegularExpressions;

public class 经典邮箱匹配
{
    public void Main()
    {
//声明这个要被匹配的字符串
        string content = "23794大富科世纪东方了djfkasdl@qq.com9548dhf28340385@163.comsdfjsd  2349@sina.com305983*&*&*2";

//声明匹配规则对象，并设定匹配规则
        Regex regex = new Regex(@"[a-zA-Z0-9]+@[a-zA-z0-9]+\.com"); //构造方法里面的参数就是匹配规则。

//声明匹配结果集对象
        MatchCollection matchs;

//调用匹配多个出多个结果的方法进行匹配，将返回的匹配结果集对象赋值给matchs
        matchs = regex.Matches(content);

//输出所有匹配结果
        foreach (Match match in matchs)
        {
            Console.WriteLine(match);
        }
        
//        djfkasdl@qq.com
//        9548dhf28340385@163.com
//        2349@sina.com

        Console.ReadKey();
    }
    
}