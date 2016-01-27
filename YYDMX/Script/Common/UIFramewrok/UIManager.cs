using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 引用管理中心
/// </summary>
public class RefManager {
    private static RefManager instance;

    public static RefManager Instance
    {
        get 
        {
            if (instance == null) 
            {
                instance = new RefManager();
            }
            return RefManager.instance; 
        }
    }

    /// <summary>
    /// UI引用管理
    /// </summary>
    private Dictionary<UITypeEnum, Transform> uiRefDictionary = new Dictionary<UITypeEnum, Transform>();

    private Dictionary<UITypeEnum, string> uiPathDictionary = new Dictionary<UITypeEnum, string>();

    public RefManager() 
    {
        //注册UI


    }




    /// <summary>
    /// 添加UI引用
    /// </summary>
    public void AddTransform(UITypeEnum e, GameObject obj) 
    {
        if (!uiRefDictionary.ContainsKey(e))
        {
            uiRefDictionary.Add(e, obj.transform);
        }
    }

    /// <summary>
    /// 删除UI引用
    /// </summary>
    public void DeleTransform(UITypeEnum e)
    {
        if (uiRefDictionary.ContainsKey(e)) 
        {
            uiRefDictionary.Remove(e);
        }
    }



    /// <summary>
    /// 获取UI引用, 没找到返回null
    /// </summary>
    /// <returns></returns>
    public Transform GetTransform(UITypeEnum e) 
    {
        if (uiRefDictionary.ContainsKey(e))
        {
            return uiRefDictionary[e];
        }

        return null;
    }

    /// <summary>
    /// 发送UI事件
    /// </summary>
    public void SendUIEvent(UITypeEnum e, UIEventType type, UIModelBase model) 
    {
        switch (type)
        {
            case UIEventType.Show:
                GetTransform(e).SendMessage("ShowUI", model, SendMessageOptions.RequireReceiver);

                break;
            case UIEventType.Hide:
                GetTransform(e).SendMessage("HideUI", model, SendMessageOptions.RequireReceiver);

                break;
            case UIEventType.Refresh:
                GetTransform(e).SendMessage("RefreshUI", model, SendMessageOptions.RequireReceiver);
                break;
        }
    }

    /// <summary>
    /// UI事件发送类型
    /// </summary>
    public enum UIEventType 
    {
        Show,
        Hide,
        Refresh
    }

    public enum UILayer 
    {
        Middle,
        Top
    }


}
