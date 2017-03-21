using System;
using IniParser.Model;
using IniParser.Model.Formatting;
using IniParser.Parser;

public class EngineConfigs
{
    private readonly IniData _iniData;

    public EngineConfigs(string iniconfig)
    {
        var parser = new IniDataParser();
        _iniData = parser.Parse(iniconfig);
    }

    /// <summary>
    /// GetConfig from section
    /// </summary>
    /// <param name="section"></param>
    /// <param name="key"></param>
    /// <param name="throwError">whether or not throw error when get no config</param>
    /// <returns></returns>
    public string GetConfig(string section, string key, bool throwError = true)
    {
        var sectionData = _iniData[section];
        if (sectionData == null)
        {
            if (throwError)
                throw new Exception("Not found section from ini config: " + section);
            return null;
        }
        var value = sectionData[key];
        if (value == null)
        {
            if (throwError)
                throw new Exception(string.Format("Not found section:`{0}`, key:`{1}` config", section, key));
        }
        return value;
    }
}


public class IniParseDemo
{
    public void Main()
    {
        EngineConfigs engineConfigs = new EngineConfigs("xxx");
        //´Ë´¦·µ»Ø ../Product    
        var productRelPath = engineConfigs.GetConfig("Engine", "ProductRelPath");
    }
}