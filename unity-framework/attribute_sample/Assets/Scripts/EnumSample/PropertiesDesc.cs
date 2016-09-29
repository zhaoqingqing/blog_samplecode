using System;

/// <summary>
/// Detail		:  可用于Field和enum
/// Author		:  Qing
/// CreateTime  :  #CreateTime#
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Enum)]
public class PropertiesDesc : System.Attribute
{
    public string Desc { get; private set; }

    public PropertiesDesc()
    {
        
    }
    public PropertiesDesc(string desc)
    {
        this.Desc = desc;
    }
}
