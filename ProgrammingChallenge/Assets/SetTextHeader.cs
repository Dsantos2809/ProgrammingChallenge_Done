using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextHeader : MonoBehaviour
{
    public GameObject scriptReader;
    public Text titlePrefab;
    public GameObject text;

    void Start()
    {
        titlePrefab.text = scriptReader.GetComponent<JsonReader>().JsonString.Title;
        string[] titles = scriptReader.GetComponent<JsonReader>().JsonString.ColumnHeaders;
         foreach(string title in titles)
        {
            GameObject container = Instantiate(text, transform);
            container.GetComponent<Text>().text = title;
        }
        
    }

    void Update()
    {
        
    }
}
