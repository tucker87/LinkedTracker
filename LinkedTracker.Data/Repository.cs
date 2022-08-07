using System;
using System.Collections.Generic;
using System.Linq;
using LinkedTracker.Data.Models;

namespace LinkedTracker.Data;

public interface IRepository<TKey, TData>
{
    Dictionary<TKey, TData> Data { get; set; }
    bool Exists(TKey key);
    void Create(TKey key, TData data);
    TData Get(TKey key);
    TData GetOrCreate(TKey key, Func<TData> createFunc);
    void Update(TKey key, TData data);
}

public class Repository<TKey, TData>
{
    public Dictionary<TKey, TData> Data { get; set; } = new Dictionary<TKey, TData>();
    private int _nextIndex;

    public bool Exists(TKey key)
    {
        return Data.Any(i => key.Equals(i.Key));
    }

    public void Create(TKey key, TData data)
    {
        if(data is IIndexed indexed)
            indexed.Index = _nextIndex++;

        Data.Add(key, data);
    }

    public virtual TData Get(TKey key)
    {
        return Data.ContainsKey(key)
            ? Data[key]
            : default(TData);
    }

    public TData GetOrCreate(TKey key, Func<TData> createFunc)
    {
        var data = Get(key);
        if(data != null)
            return data;

        var newData = createFunc();
        Create(key, newData);
        return newData;            
    }

    public void Update(TKey key, TData data)
    {
        Data[key] = data;
    }
}