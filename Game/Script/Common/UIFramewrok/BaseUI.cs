using UnityEngine;
using System.Collections;

public class BaseUI : MonoBehaviour {

    private Transform control;

	public BaseUI()
	{
		control = this.transform;
	}

    public virtual void Awake() 
    {
        control = this.transform;
    }

    /// <summary>
    /// 刷新页面
    /// </summary>
    /// <param name="RefreshNum">刷新的编号</param>
    public virtual void RefreshUI(UIModelBase o) 
    {
        
    }

    /// <summary>
    /// 显示UI
    /// </summary>
    public virtual void ShowUI(UIModelBase o) 
    {
        control.gameObject.SetActive(true);
    }

    /// <summary>
    /// 关闭UI
    /// </summary>
    public virtual void HideUI(UIModelBase o)
    {
        control.gameObject.SetActive(false);
    }


}
