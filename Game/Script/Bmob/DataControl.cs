
#region Version Info
/* ======================================================================== 
* 【本类功能概述】 
* 
* 功能：  数据控制层
* 文件名：DataControl 
* 作者：Kaven 
* 时间：2016/1/19 16:52:52 
* 
* ======================================================================== 
*/
#endregion

using UnityEngine;
using System.Collections;
using cn.bmob.io;
using System.Collections.Generic;
using cn.bmob.response;
using cn.bmob.http;

public enum DataHandlerType
{
    DT_Bmob,
    DT_Local
}

public class DataControl : Singletion<DataControl>
{

//   
// 
//     protected DataHandlerType m_dataHandlerType = DataHandlerType.DT_Bmob;
//     public DataHandlerType _dataHandlerType
//     {
//         get { return m_dataHandlerType; }
//         set { m_dataHandlerType = value; }
//     }

    private DataBmob m_dataBmob;
    private DataLocal m_dataLocal;

    public DataControl()
    {
        Init();
    }

    void Init()
    {
        m_dataBmob = GameObject.FindGameObjectWithTag(TagDefine.DataBmob).GetComponent<DataBmob>();
        m_dataLocal = new DataLocal();
    }


    public void WriteInfo(string tableName, BmobTable info, DataHandlerType handlerType)
    {

        if(handlerType == DataHandlerType.DT_Bmob)
        {
            m_dataBmob.WriteInfo(tableName, info);
        }
        else if (handlerType == DataHandlerType.DT_Local)
        {
            //result = m_dataLocal.WriteInfo(info);
        }

    }

    public void WriteInfo(string tableName, List<BmobTable> infoList, DataHandlerType handlerType)
    {

        if (handlerType == DataHandlerType.DT_Bmob)
        {
            m_dataBmob.WriteInfo(tableName, infoList);
        }
        else if (handlerType == DataHandlerType.DT_Local)
        {
            //result = m_dataLocal.WriteInfo(info);
        }


    }

    /// <summary>
    /// 查询 key（字段）=value（具体数值）的所有数据，call函数的第参数可以获得数据集合
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    /// <typeparam name="type">字段类型</typeparam>
    /// <param name="tableName">表名</param>
    /// <param name="key">字段名</param>
    /// <param name="value">数据</param>
    /// <param name="call">回调函数</param>
    /// <param name="handlerType">数据处理类型</param>
    public void QueryInfo<T, type>(string tableName, string key, type value, DataDelegate<T> call, DataHandlerType handlerType) where T : BmobTable
    {
        if (handlerType == DataHandlerType.DT_Bmob)
        {
            m_dataBmob.QueryInfo<T, type>(tableName, key, value, call);
        }
        else if (handlerType == DataHandlerType.DT_Local)
        {
            m_dataLocal.QueryInfo<T, type>(tableName, key, value, call);
        }

    }

    public void UpdateInfo(string tableName, BmobTable info, DataHandlerType handlerType)
    {
    
        if (handlerType == DataHandlerType.DT_Bmob)
        {
           m_dataBmob.UpdateInfo(tableName,info);
        }
        else if (handlerType == DataHandlerType.DT_Local)
        {
            //result = m_dataLocal.UpdateInfo(info);
        }

    }

    /// <summary>
    /// 删除 key（字段）=value（具体数值）的所有数据
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    /// <typeparam name="type">字段类型</typeparam>
    /// <param name="tableName">表名</param>
    /// <param name="key">字段名</param>
    /// <param name="value">数据</param>
    /// <param name="handlerType">数据处理类型</param>
    public void DeleteInfo<type>(string tableName, string key, type value, DataHandlerType handlerType)
    {

        if (handlerType == DataHandlerType.DT_Bmob)
        {
            m_dataBmob.DeleteInfo<type>(tableName,key,value);
        }
        else if (handlerType == DataHandlerType.DT_Local)
        {
            //result = m_dataLocal.DeleteInfo(info);
        }
    }


}

