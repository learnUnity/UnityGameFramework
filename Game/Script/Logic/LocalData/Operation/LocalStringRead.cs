
#region Version Info
/* ======================================================================== 
* 【本类功能概述】 
* 
* 功能：CSV数据处理
* 文件名：DataCSV 
* 作者：Kaven 
* 时间：2016/1/21 23:35:42 
* 
* ======================================================================== 
*/
#endregion

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LocalStringRead : CSVDataBase
{

    public LocalStringRead(string fileName)
        : base(fileName) { }


    public override object Init(string[] rowList)
    {
        Dictionary<int, LocalString> dic = new Dictionary<int, LocalString>();

        LocalString localString = null;

        foreach (var i in rowList)
	    {
            string [] lie = i.Split(',');
            localString = new LocalString();
            localString.id = PareInt(lie[0]);
            localString.chinese = lie[2];
            localString.english = lie[3];
            localString.korean = lie[4];
            localString.japanese = lie[5];
            dic.Add(localString.id, localString);
	    }
        return dic;
    }
}

