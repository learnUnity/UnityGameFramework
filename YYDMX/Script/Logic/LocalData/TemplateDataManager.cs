using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TemplateDataManager : Singletion<TemplateDataManager>
{

    public LanguageType languageType = LanguageType.Chinese;

    protected override void SingletionInit() 
    {
        LocalStringRead localStringRead = new LocalStringRead("LocalString");
        localStringList = (Dictionary<int, LocalString>)localStringRead.ReadData();


    }
    private Dictionary<int, LocalString> localStringList = new Dictionary<int, LocalString>();
    public string GetLocalString(int id) 
    {
        if (localStringList.ContainsKey(id)) 
        {
            switch (languageType)
            {
                case LanguageType.Chinese:
                    return localStringList[id].chinese;
                case LanguageType.English:
                    return localStringList[id].english;
                default:
                    return "text not found";
            }
            
        }
        return "text not found";
    }
}

public enum LanguageType 
{
    Chinese,
    English
}