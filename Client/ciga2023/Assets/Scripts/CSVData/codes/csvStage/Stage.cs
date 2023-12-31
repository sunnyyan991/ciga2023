
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



namespace cfg.csvStage
{

public sealed class Stage :  Bright.Config.BeanBase 
{
    public Stage(JSONNode _json) 
    {
        { if(!_json["id"].IsNumber) { throw new SerializationException(); }  Id = _json["id"]; }
        { if(!_json["map"].IsString) { throw new SerializationException(); }  Map = _json["map"]; }
        { if(!_json["score"].IsNumber) { throw new SerializationException(); }  Score = _json["score"]; }
        { if(!_json["time"].IsNumber) { throw new SerializationException(); }  Time = _json["time"]; }
        { if(!_json["monsterSpawn"].IsNumber) { throw new SerializationException(); }  MonsterSpawn = _json["monsterSpawn"]; }
    }

    public Stage(int id, string map, int score, int time, int monsterSpawn ) 
    {
        this.Id = id;
        this.Map = map;
        this.Score = score;
        this.Time = time;
        this.MonsterSpawn = monsterSpawn;
    }

    public static Stage DeserializeStage(JSONNode _json)
    {
        return new csvStage.Stage(_json);
    }

    /// <summary>
    /// 这是id
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// 地图prefab
    /// </summary>
    public string Map { get; private set; }
    /// <summary>
    /// 分数
    /// </summary>
    public int Score { get; private set; }
    /// <summary>
    /// 时间(秒)
    /// </summary>
    public int Time { get; private set; }
    /// <summary>
    /// 怪物组id
    /// </summary>
    public int MonsterSpawn { get; private set; }

    public const int __ID__ = 747868680;
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
        + "Map:" + Map + ","
        + "Score:" + Score + ","
        + "Time:" + Time + ","
        + "MonsterSpawn:" + MonsterSpawn + ","
        + "}";
    }
    }
}
