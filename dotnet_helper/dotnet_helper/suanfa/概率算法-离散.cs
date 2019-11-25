using System;
using System.Collections.Generic;

public class MoneyConfig
{
    public int id;
    public int per;
    public int money;
}

public class 概率算法_离散
{
    public void Init()
    {
        //构造区间
        //读取配置的数据，比如XX红包的为10%
        List<MoneyConfig> list = new List<MoneyConfig>();
        List<int> moneys = new List<int>();
        List<int> pers = new List<int>();
        for (int i = 0; i < list.Count; i++)
        {
            var config = list[i];
            var per = config.per;
            if (i > 0 && config.per > 0)
            {
                //累加在自已之前的概率值
                for (int j = 0; j < i; j++)
                {
                    per += list[j].per;
                }
            }
            
            pers.Add(per);
            moneys.Add(config.money);
        }

        var packet = getMoney(moneys, pers);
    }

    //per[] = {20, 80,100}
    //moneyStr[] = {1,2,3}
    //获取红包金额
    public double getMoney(List<int> moneyStr, List<int> per)
    {
        double packet = 0.01;
        //获取概率对应的数组下标
        int key = getProbability(per);
        //获取对应的红包值
        packet = moneyStr[key];
        return packet;
    }

    //获得概率对应的key
    public int getProbability(List<int> per)
    {
        int key = -1;
        if (per == null || per.Count == 0)
        {
            return key;
        }

        //100中随机生成一个数
        Random random = new Random();
        int num = random.Next(100);

        for (int i = 0; i < per.Count; i++)
        {
            var p = per[i];
            //获取落在该区间的对应key
            if (num < p)
            {
                key = i;
                break;
            }
        }

        return key;
    }
}