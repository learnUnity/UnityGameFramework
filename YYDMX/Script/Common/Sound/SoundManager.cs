using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//音乐，音效
public class SoundManager: Singletion<SoundManager>
{
    public float AudioVolume = 1f;

    private Dictionary<string, AudioClip> auidoDic = new Dictionary<string, AudioClip>();

    public void PlayMusicAS(string pathName) 
    {
        AudioClip clip = LoadAudioClip(pathName);
        AudioSource.PlayClipAtPoint(clip, Vector3.zero, AudioVolume);
    }


    public bool PlaySoundMusicEffect(string pathName)
    {

        return false;
    }


    public bool PlaySoundMusicLoop(string pathName) 
    {
        return false;
    }

    private AudioClip LoadAudioClip(string pathName) 
    {
        if (auidoDic.ContainsKey(pathName))
        {
            return auidoDic[pathName];
        }
        else 
        {
            AudioClip clip =  ResourceManager.Instance.LoadClip(pathName);

            if (clip == null) 
            {
                if (clip == null)
                {
                    Debug.LogError("audio not found " + pathName);
                    throw new UnityException("audio not found " + pathName);
                }
            }

            auidoDic.Add(pathName, clip);
            return clip;
        }
    }

}
