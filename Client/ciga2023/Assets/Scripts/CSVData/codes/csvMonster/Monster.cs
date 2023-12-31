
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using SimpleJSON;



namespace cfg.csvMonster
{

public sealed class Monster :  Bright.Config.BeanBase 
{
    public Monster(JSONNode _json) 
    {
        { if(!_json["id"].IsNumber) { throw new SerializationException(); }  Id = _json["id"]; }
        { if(!_json["name"].IsString) { throw new SerializationException(); }  Name = _json["name"]; }
        { if(!_json["monsterPrefab"].IsString) { throw new SerializationException(); }  MonsterPrefab = _json["monsterPrefab"]; }
        { if(!_json["script"].IsNumber) { throw new SerializationException(); }  Script = _json["script"]; }
        { if(!_json["score"].IsNumber) { throw new SerializationException(); }  Score = _json["score"]; }
        { if(!_json["lifetime"].IsNumber) { throw new SerializationException(); }  Lifetime = _json["lifetime"]; }
        { if(!_json["child"].IsNumber) { throw new SerializationException(); }  Child = _json["child"]; }
    }

    public Monster(int id, string name, string monsterPrefab, int script, int score, int lifetime, int child ) 
    {
        this.Id = id;
        this.Name = name;
        this.MonsterPrefab = monsterPrefab;
        this.Script = script;
        this.Score = score;
        this.Lifetime = lifetime;
        this.Child = child;
    }

    public static Monster DeserializeMonster(JSONNode _json)
    {
        return new csvMonster.Monster(_json);
    }

    /// <summary>
    /// 这是id
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// 名字
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// prefab
    /// </summary>
    public string MonsterPrefab { get; private set; }
    /// <summary>
    /// 类型
    /// </summary>
    public int Script { get; private set; }
    /// <summary>
    /// 分数
    /// </summary>
    public int Score { get; private set; }
    /// <summary>
    /// 消失时间(sec)
    /// </summary>
    public int Lifetime { get; private set; }
    /// <summary>
    /// 儿子
    /// </summary>
    public int Child { get; private set; }

    public const int __ID__ = 1471211200;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "Name:" + Name + ","
        + "MonsterPrefab:" + MonsterPrefab + ","
        + "Script:" + Script + ","
        + "Score:" + Score + ","
        + "Lifetime:" + Lifetime + ","
        + "Child:" + Child + ","
        + "}";
    }
    }
}
