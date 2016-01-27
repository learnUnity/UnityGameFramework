using UnityEngine;
using System.Collections;

public abstract class Singletion<T> where T : class,new()
{

    private static T _instance = null;

    public static T Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new T();
            }

            return _instance;
        }
    }

    protected Singletion()
    {
        if (null != _instance)
        {
            throw new SingletionException("This " + (typeof(T)).ToString() + "Singletion not is null");
        }
        else
        {
            SingletionInit();
        }
    }

    protected virtual void SingletionInit() 
    {
        
    }

}
