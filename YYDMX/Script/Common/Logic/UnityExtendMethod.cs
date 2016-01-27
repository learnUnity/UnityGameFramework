using UnityEngine;
using System.Collections;

public static class UnityExtendMethod 
{

    private static Transform tempT = null;

    public static Transform FindChildInChild(this Transform t, string _name) 
    {
        for (int i = 0; i < t.childCount; i++)
        {
            tempT = t.GetChild(i);
            if (_name == tempT.name)
            {
                return tempT;
            }
            else 
            {
                if ((tempT = FindChildInChild(tempT, _name)) != null) 
                {
                    return tempT;
                }
            }
        }
        return null;
    }

    public static Transform FindParentInParent(this Transform t, string _name)
    {
        if (t.parent == null) 
        {
            return null;
        }

        Debug.Log(t.parent.name);

        if (t.parent.name == _name)
        {
            return t.parent;
        }
        else 
        {
            if ((tempT = FindParentInParent(t, _name)) != null)
            {
                return tempT;
            }
        }

        return null;
    }

    public static T FindParentInParent<T>(this Transform t) where T: Component
    {
        T tempT = null;

		if (t == null) {
			return null;
		}

        if (t.parent == null) 
        {
            return null;
        }

        tempT = t.GetComponent<T>();
        if (tempT != null)
        {
            return tempT;
        }
        else
        {
            //if ((tempT = FindParentInParent<T>(t.parent)) != null)
            //{
            //    Debug.Log("FindParentInParent:" + tempT);
            //    return tempT;
            //}

            return FindParentInParent<T>(t.parent);
        }
    }



}
