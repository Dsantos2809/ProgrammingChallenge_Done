using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class JsonReader : MonoBehaviour
{

    public IDictionary<string, Datum> dict = new Dictionary<string, Datum>();
    string path;
    public Table JsonString;
    public int count = 0;

    public string GetDataDictionary(string name, int index)
    {
        string dataName = null;
        dataName = dict[name + index].data;
        return dataName;
    }

    public void Awake()
    {
        path = File.ReadAllText(Application.streamingAssetsPath + "/JsonChallenge.json");
        JsonString = JsonUtility.FromJson<Table>(path);
        CreateDictionary(path);
        foreach (KeyValuePair<string, Datum> kvp in dict)
        {
            Debug.Log("key: " + kvp.Key + " value:" + kvp.Value);
        }
        }

    private void CreateDictionary(string path)
    {
        var jo = JObject.Parse(path);
        foreach(JObject jObj in jo["Data"])
        {
            count++;
        }
        for(int i = 0; i < count; i++)
        {
            foreach (string name in JsonString.ColumnHeaders)
            {
                Datum data = new Datum();
                data.type = name;
                data.data = jo["Data"][i][name].Value<string>();
                dict.Add(name + i, data);
            }
        }  
    }

    public void Update()
    {

    }
}

[Serializable]
public class Table
{
    public string Title;
    public string[] ColumnHeaders;
}

[Serializable]
public class Datum
{
    public string type;
    public string data;
}