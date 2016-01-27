
#region Version Info
/* ======================================================================== 
* 【本类功能概述】 
* 
* 功能： 本地处理数据
* 文件名：DataLocal 
* 作者：Kaven 
* 时间：2016/1/19 16:56:25 
* 
* ======================================================================== 
*/
#endregion

using UnityEngine;
using System.Collections;
using cn.bmob.io;
using System.Collections.Generic;
using cn.bmob.api;
using cn.bmob.tools;
using cn.bmob.exception;
using cn.bmob.http;
using cn.bmob.response;

public class DataLocal : IDataHandler
{

    public void WriteInfo(string tableName, BmobTable info)
    {
        
    }

    public void WriteInfo(string tableName, List<BmobTable> infoList)
    {
        
    }

    public void QueryInfo<T, type>(string tableName, string key, type value, DataDelegate<T> call) where T : BmobTable
    {
        List<T> list = new List<T>();
        UserInfo info = new UserInfo();
        info.score = 25;
        list.Add(info as T);

        call(list);
    }

    public void UpdateInfo(string tableName, BmobTable info)
    {
        
    }

    public void DeleteInfo<type>(string tableName, string key, type value)
    {
        
    }
}

