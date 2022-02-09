using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cfg;
using cfg.Datas;
using cfg.Constants;
using SimpleJSON;
using System.IO;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Tables table = new Tables(Loader);
        Equip equip = table.Weapon.Get(1);
        Debug.Log($"{equip.Name}    {equip.Color}    {equip.Quality}");
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