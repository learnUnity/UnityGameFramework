
#region Version Info
/* ======================================================================== 
* 【本类功能概述】 
* 
* 功能： 数据处理接口
* 文件名：IDataHandler 
* 作者：Kaven 
* 时间：2016/1/19 16:33:06 
* 
* ======================================================================== 
*/
#endregion

using UnityEngine;
using System.Collections;
using cn.bmob.http;
using cn.bmob.response;
using cn.bmob.io;
using System.Collections.Generic;



public delegate void DataDelegate<T>(List<T> infoList);

public interface IDataHandler
{


    //写入
    void WriteInfo(string tableName, BmobTable info);
    void WriteInfo(string tableName, List<BmobTable> infoList);


    void QueryInfo<T, type>(string tableName, string key, type value, DataDelegate<T> call) where T : BmobTable;

    //更新
    void UpdateInfo(string tableName, BmobTable info);

    //删除
    void DeleteInfo<type>(string tableName, string key, type value);




}


