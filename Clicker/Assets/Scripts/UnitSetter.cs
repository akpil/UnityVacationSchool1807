using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitSetter{

    static readonly string[] units = { "", "K", "M", "B", "T", "a", "b", "c" };

    static public string GetUnitString(double value)
    {
        string target = value.ToString("N0");
        string[] splited = target.Split(',');
        if (splited.Length > 1)
        {
            char[] mod = splited[1].ToCharArray();
            return string.Format("{0}.{1}{2}{3}", splited[0], mod[0], mod[1], units[splited.Length - 1]);
        }
        else
        {
            return string.Format("{0}{1}", splited[0], units[splited.Length - 1]);
        }
    }
}

