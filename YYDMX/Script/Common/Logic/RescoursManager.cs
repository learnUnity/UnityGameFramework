using UnityEngine;
using System.Collections;

public class ResourceManager : Singletion<ResourceManager> 
{
    
    public T3 LoadTexture<T3>(string fileName) where T3: UnityEngine.Object
    {
        return Resources.Load<T3>("Texture/" + fileName); ;
    }

    public T3 Load<T3>(string fileName) where T3 : UnityEngine.Object
    {
        return Resources.Load<T3>(fileName);
    }

    public AudioClip LoadClip(string fileName) 
    {
        return Resources.Load<AudioClip>(@"Sound/" + fileName);
    }

}
