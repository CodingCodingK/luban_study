using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cfg;
using cfg.item;
using SimpleJSON;
using System.IO;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Tables table = new Tables(Loader);
        Item item = table.TbItem.Get(10010);
        Debug.Log($"{item.Name}    {item.Desc}");
    }

    private JSONNode Loader(string fileName)
    {
        return JSON.Parse(File.ReadAllText(Application.dataPath + "/../GenerateDatas/json/" + fileName + ".json"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
