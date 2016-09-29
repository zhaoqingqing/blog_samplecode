using System;
using System.Collections;
using System.Collections.Generic;
using Type = System.Type;

/// <summary>
/// Detail		:  Desc
/// Author		:  Qing
/// CreateTime  :  #CreateTime#
/// </summary>
public class PropertiesUtils
{

    private static Dictionary<Type, Dictionary<string, string>> CacheType2Dict = new Dictionary<Type, Dictionary<string, string>>();

    public static string GetDescByType(object obj)
    {
        var type = obj.GetType();
        if (CacheType2Dict.ContainsKey(type) == false)
        {
            Cache(type);
        }
        var fieldNameToDesc = CacheType2Dict[type];
        var fieldName = obj.ToString();
        var desc = fieldNameToDesc.ContainsKey(fieldName) ? fieldNameToDesc[fieldName] : string.Format(string.Format("Can not found such desc for field `{0}` in type `{1}`", fieldName, type.Name));
        return desc;
    }

    private static void Cache(Type type)
    {
        var dict = new Dictionary<string, string>();
        if (CacheType2Dict.ContainsKey(type) == false)
        {
            CacheType2Dict.Add(type, dict);
        }
        var fields = type.GetFields();
        var max = fields.Length;
        for (int idx = 0; idx < max; idx++)
        {
            var objs = fields[idx].GetCustomAttributes(typeof(PropertiesDesc), true);
            if (objs != null && objs.Length > 0)
            {
                dict.Add(fields[idx].Name, ((PropertiesDesc)objs[0]).Desc);
            }
        }
    }
}
