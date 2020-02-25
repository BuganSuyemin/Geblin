using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TileSave 
{
    public string tileName;
    public List<KeyValuePair<string, string>> properties = new List<KeyValuePair<string, string>>();

    public TileSave(string _tileName, List<KeyValuePair<string, string>> _properties)
    {
        tileName = _tileName;
        properties = _properties;
    }
}
