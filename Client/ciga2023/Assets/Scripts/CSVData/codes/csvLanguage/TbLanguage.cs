
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



namespace cfg.csvLanguage
{

public sealed class TbLanguage
{
    private readonly Dictionary<int, csvLanguage.Language> _dataMap;
    private readonly List<csvLanguage.Language> _dataList;
    
    public TbLanguage(JSONNode _json)
    {
        _dataMap = new Dictionary<int, csvLanguage.Language>();
        _dataList = new List<csvLanguage.Language>();
        
        foreach(JSONNode _row in _json.Children)
        {
            var _v = csvLanguage.Language.DeserializeLanguage(_row);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public Dictionary<int, csvLanguage.Language> DataMap => _dataMap;
    public List<csvLanguage.Language> DataList => _dataList;

    public csvLanguage.Language GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public csvLanguage.Language Get(int key) => _dataMap[key];
    public csvLanguage.Language this[int key] => _dataMap[key];

    public void Resolve(Dictionary<string, object> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
    
}

}