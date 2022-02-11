using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Cfg;
using ProtoBuf;
using System.IO;
using System.Linq;
using Debug = UnityEngine.Debug;

public class Test2 : MonoBehaviour
{
    private List<DatasWeapon> WeaponList = new List<DatasWeapon>();
    Stopwatch sw = new Stopwatch();
    
    private void Awake()
    {
        var path = Application.dataPath + "/../GenerateDatas/proto2/" + "weapon.bytes";
        sw.Start();
        using (var fs = File.OpenRead(path))
        {
            var wp = Tester.ProtoDeSerialize<Weapon>(fs);
            WeaponList.AddRange(wp.DataLists);
        }
        sw.Stop();
    }

    void Start()
    {
        // Tables = table.Weapon.Get(1);
        // Debug.Log($"{equip.Name}    {equip.Color}    {equip.Quality}");
        
        foreach (var equip in WeaponList)
        {
            Debug.Log($"{equip.Name}    {equip.Color}    {equip.Quality}");
        }
        Debug.Log(sw.Elapsed.TotalMilliseconds + " ms");
    }

    // private JSONNode JsonLoader(string fileName)
    // {
    //     return JSON.Parse(File.ReadAllText(Application.dataPath + "/../GenerateDatas/json/" + fileName + ".json"));
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Tester
{
    public static byte[] ProtoSerialize<T>(T msg)
    {
        byte[] bytes = null;
        using (MemoryStream ms = new MemoryStream())
        {

            ProtoBuf.Serializer.Serialize(ms, msg);
            bytes = new byte[ms.Length];
            Buffer.BlockCopy(ms.GetBuffer(), 0, bytes, 0, (int)ms.Length);
        }

        return bytes;
    }

    public static T ProtoDeSerialize<T>(byte[] bytes)
    {
        T msg;
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            msg = ProtoBuf.Serializer.Deserialize<T>(ms);
        }

        return msg;
    }

    public static T ProtoDeSerialize<T>(FileStream ms)
    {
        T msg;
        msg = ProtoBuf.Serializer.Deserialize<T>(ms);
        return msg;
    }
}