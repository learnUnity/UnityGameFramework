using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : Singletion<EventManager>
{
    public enum EventType
    {
        ET_Null
    }


    public delegate void EventHandler(params object[] args);

    private Dictionary<EventType, Dictionary<EventHandler, object[]>> _Events = new Dictionary<EventType, Dictionary<EventHandler, object[]>>();

    // 发送事件
    public void notify(EventType id, params object[] args)
    {
        if (!_Events.ContainsKey(id))
            return;

        foreach (KeyValuePair<EventHandler, object[]> handlerInfo in _Events[id])
        {
            object[] tempArgs = new object[handlerInfo.Value.Length + args.Length];
            handlerInfo.Value.CopyTo(tempArgs, 0);
            args.CopyTo(tempArgs, handlerInfo.Value.Length);

            handlerInfo.Key(tempArgs);
        }
    }

    // 注册事件
    public bool register(EventType id, EventHandler handler, params object[] args)
    {
        if (id <= EventType.ET_Null || handler == null)
            return false;

        Dictionary<EventHandler, object[]> handlerInfo = null;
        if (_Events.ContainsKey(id))
        {
            handlerInfo = _Events[id];
        }
        else
        {
            handlerInfo = new Dictionary<EventHandler, object[]>();
            _Events.Add(id, handlerInfo);
        }

        if (handlerInfo.ContainsKey(handler))
        {
            Debug.LogError("Register event:[" + id.ToString() + "] repeated!");
            return false;
        }

        handlerInfo.Add(handler, args);

        return true;
    }

    // 注销事件
    public bool unregister(EventType id, EventHandler handler)
    {
        if (!_Events.ContainsKey(id))
            return false;

        Dictionary<EventHandler, object[]> handlerInfo = _Events[id];
        if (!handlerInfo.ContainsKey(handler))
            return false;

        handlerInfo.Remove(handler);

        if (handlerInfo.Count == 0)
            _Events.Remove(id);

        return true;
    }
}
