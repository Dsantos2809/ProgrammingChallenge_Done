using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetEntries : MonoBehaviour
{
    public GameObject scriptReader;
    public GameObject Row;
    public GameObject Column;


    void Start()
    {
        int counter = scriptReader.GetComponent<JsonReader>().count;
        for (int i = 0; i < counter; i++)
        {
            GameObject rowText = Instantiate(Row, transform);

            foreach (string name in scriptReader.GetComponent<JsonReader>().JsonString.ColumnHeaders)
            {
                GameObject columnText = Instantiate(Column, rowText.transform);
                string text = scriptReader.GetComponent<JsonReader>().GetDataDictionary(name, i);

                columnText.GetComponent<Text>().text = text;
            }
        }
       
    }

    void Update()
    {

    }
}
