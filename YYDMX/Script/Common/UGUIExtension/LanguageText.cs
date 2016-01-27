using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguageText : MonoBehaviour {

    public int textID;
    public bool isAwakeShow = true;

    public void Awake() 
    {
        if (textID != 0)
        {
            Text text = GetComponent<Text>();

            if (text != null && isAwakeShow) 
            {
                text.text = TemplateDataManager.Instance.GetLocalString(textID);
            }
        }
    }




}
