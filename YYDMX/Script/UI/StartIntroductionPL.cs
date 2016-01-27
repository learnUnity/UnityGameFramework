using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartIntroductionPL : MonoBehaviour {

    public GameObject introductionIM1;
    public GameObject introductionIM2;
    public GameObject introductionIM3;
    public GameObject btnStartGame;
    public GameObject btnStartGameFull;

    public HitCharEffect introductionEffect3;
    public HitCharEffect introductionEffect4;
    public void Awake() 
    {
        SoundManager.Instance.PlayMusicAS("BGM/Startpart1");
        
        if (introductionEffect3 != null)
            introductionEffect3.PlayComplete += introductionEffect_PlayComplete;
    }

    void introductionEffect_PlayComplete()
    {
        introductionEffect4.PlayTextAnim();
    }

    public void OnPlay1Sound() 
    {
        introductionIM1.SetActive(true);
        GameObject.Find("Introduction2").GetComponent<CCTweenPosition>().enabled = true;
        SoundManager.Instance.PlayMusicAS("BGM/Startpart2");
    }

    public void OnPlay2Sound()
    {
        introductionIM2.SetActive(true);
        GameObject.Find("Introduction3").GetComponent<CCTweenPosition>().enabled = true;
        SoundManager.Instance.PlayMusicAS("BGM/Startpart3");
    }

    public void OnPlay3Sound()
    {
        introductionIM3.SetActive(true);
        btnStartGame.SetActive(false);
        btnStartGameFull.SetActive(true);
    }


    public void StartGame() 
    {
        SceneManager.LoadScene("Main");
        Debug.Log("开始游戏");
    }

}
