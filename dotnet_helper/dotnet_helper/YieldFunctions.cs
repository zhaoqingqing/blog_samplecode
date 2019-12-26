using System;
using System.Collections.Generic;

/// <summary>
/// 作者：赵青青 (569032731@qq.com)
/// 时间：
/// 说明：
/// </summary>
class YieldFunctions
{
//foreach getNums()实际是主语法糖
//    public static IEnumerable<int> getNums()
//    {
//        yield return 1;
//    }
    public static void Main()
    {
        List<int> getNums = new List<int>();
        getNums.Add(1);
        foreach (int i in getNums)
        {
            Console.WriteLine(i);
        }
    }
}
