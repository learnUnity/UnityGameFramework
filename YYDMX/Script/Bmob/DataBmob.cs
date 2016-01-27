
#region Version Info
/* ======================================================================== 
* 【本类功能概述】 
* 
* 功能： Bmob方式处理数据
* 文件名：DataBmob 
* 作者：Kaven 
* 时间：2016/1/19 16:55:02 
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

public class DataBmob : MonoBehaviour, IDataHandler
{

    private BmobUnity Bmob;

    void Start()
    {

        //注册调试打印对象
        BmobDebug.Register(print);

        //获取Bmob的服务组件
        Bmob = gameObject.GetComponent<BmobUnity>();
        if (Bmob == null)
        {
            Bmob = gameObject.AddComponent<BmobUnity>();
            Bmob.ApplicationId = CharDefine.ApplicationID;
            Bmob.RestKey = CharDefine.RestApiKey;
        }


    }

    public void WriteInfo(string tableName, BmobTable info)
    {
        //添加一行数据
        Bmob.Create(tableName, info, (resp, exception) =>
        {
            if (exception != null)
            {
                print("保存失败, 失败原因为： " + exception.Message);
                return;
            }

            print("保存成功, @" + resp.createdAt);
        });

    }

    public void WriteInfo(string tableName, List<BmobTable> infoList)
    {
        foreach (var info in infoList)
        {
            WriteInfo(tableName, info);
        }
    }

    public void QueryInfo<T, type>(string tableName, string key, type value, DataDelegate<T> call) where T : BmobTable
    {

        //创建一个BmobQuery查询对象
        BmobQuery query = new BmobQuery();
        query.WhereEqualTo(key, value);

        Bmob.Find<T>(tableName, query, (resp, exc) =>
            {
                call(resp.results);
            }           
            );
    }

    public void UpdateInfo(string tableName, BmobTable info)
    {

        //         BmobQuery query = new BmobQuery();
        //         query.WhereEqualTo("id", id);

        //         Bmob.Find<BmobTable>(tableName, query, (resp, exception) =>
        //         {

        Bmob.Update(tableName, info.objectId, info, (resp, exception) =>
          {
              if (exception != null)
              {
                  print("修改失败, 失败原因为： " + exception.Message);
                  return;
              }
          });

        //         }
        // 
        //         );


    }

    public void DeleteInfo<type>(string tableName, string key, type value) 
    {

        BmobQuery query = new BmobQuery();
        query.WhereEqualTo(key, value);

        Bmob.Find<BmobTable>(tableName, query, (resp, exception) =>
            {
                List<BmobTable> list = resp.results;
                foreach (var info in list)
                {
                    Bmob.Delete(tableName, info.objectId, (resp1, exception1) =>
                    {
                        if (exception1 != null)
                        {
                            print(exception1.Message);
                            return;
                        }

                    });
                }
            }//Find
            );



    }

}

