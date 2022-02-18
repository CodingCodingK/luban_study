using System;
using System.Collections.Generic;
using UnityEngine;
// using cfg;
using SimpleJSON;
using System.IO;
using Bright.Serialization;
using proto;
using proto.test;

// using cfg.Datas;
// using cfg.Equips;

public class Test : MonoBehaviour
{
    void Start()
    {
        
        // Tables table = new Tables(JsonLoader);
        // Weapon equip = table.TbWeapon.Get(1);
        // Debug.Log($"{equip.Name}    {equip.Color}    {equip.SPD}");
        // foreach (var skill in equip.Skill_Ref)
        // {
        //     Debug.Log($"{skill.SkillId}    {skill.SkillName}    {skill.SkillTime}");
        // }

        NetMsg msg = new NetMsg()
        {
            Cmd = CMD.ReqLogin,
            // ReqLogin = new ReqLogin()
            // {
            //     Acct = "testAcc",
            //     Psd = "testPsd",
            // },
            // Info = "test",
            // Ping = new proto.test.Ping()
            // {
            //     IsOver = true,
            // },
            RspLogin = new RspLogin()
            {
                Info = new List<LoginInfo>()
                {
                    new LoginInfo()
                    {
                        Lv = "1",
                        Exp = "10",
                        Money = "100",
                    }
                }
            }
        };
        
        var bf = new ByteBuf();
        msg.Serialize(bf);
        Debug.Log(bf.Bytes.Length);
        var bytes = bf.CopyData();
        Debug.Log(bytes.Length);
        
        var newBf = new ByteBuf(bytes);
        Debug.Log(newBf.Bytes.Length);
        var newMsg = new NetMsg();
        newMsg.Deserialize(newBf);
        Debug.Log(newMsg.ToString());
    }

    private JSONNode JsonLoader(string fileName)
    {
        return JSON.Parse(File.ReadAllText(Application.dataPath + "/../GenerateDatas/json/" + fileName + ".json"));
    }
    
    void Update()
    {
        
    }
}