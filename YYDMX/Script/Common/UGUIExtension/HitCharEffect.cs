using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class HitCharEffect : MonoBehaviour
{
    //[SerializeField]
    protected string showText;
    [SerializeField]
    public int textID;

    protected Text text;
    private int index = 0;
    
    [SerializeField]
    protected float showCharTimer = 0.15f;
    [SerializeField]
    protected bool isPlay = true;

    private float showCharTime = 0;
    private bool isShowComplete;

    public event UnityAction PlayComplete;


    public void Awake()
    {
        if (text == null) 
        {
            text = GetComponent<Text>();
            
        }

        if (string.IsNullOrEmpty(showText)) 
        {
            showText = TemplateDataManager.Instance.GetLocalString(textID);
        }
    }

    public void FixedUpdate()
    {
        if (isPlay) 
        {
            showCharTime += Time.deltaTime;

            if (!isShowComplete)
            {
                if (showCharTime >= showCharTimer)
                {
                    index++;

                    if (index >= showText.Length)
                    {
                        isShowComplete = true;
                        if (PlayComplete != null) 
                        {
                            PlayComplete();
                        }
                        return;
                    }
                    text.text = showText.Substring(0, index);
                    showCharTime = 0;
                }
            }
        }
    }

    public void PlayTextAnim() 
    {
        isPlay = true;
    }

    public void StopTextAnim() 
    {
        isPlay = false;
    }
}
