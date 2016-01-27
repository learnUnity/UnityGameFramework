
#region Version Info
/* ======================================================================== 
* 【本类功能概述】 
* 
* 功能：
* 文件名：BmobTest 
* 作者：Kaven 
* 时间：2016/1/20 23:20:08 
* 
* ======================================================================== 
*/
#endregion

#define Test

using UnityEngine;
using System.Collections;
using cn.bmob.io;
using System.Collections.Generic;
using cn.bmob.response;
using cn.bmob.exception;

public class BmobTest : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
        DataCSV csv = new DataCSV("Data/Test");
        print(csv["中文", 1]);
        print(csv["中文", 2]);
        print(csv["中文", 7]);
        print(csv["中文", 4]);
        print(csv["韩文", 1]);
        print(csv["英文", 2]);
        print(csv["韩文", 5]);
        print(csv["英文", 6]);
        print(csv["中文", 6]);

       
    }

    void Call(List<UserInfo> listInfo)
    {

        print("123");

        UserInfo info = listInfo[0] as UserInfo;

        print(info.score);

    }

    // Update is called once per frame
    void Update()
    {

#if Test

        if (Input.GetKeyDown(KeyCode.A))
        {
            var data = new UserInfo();
            List<BmobTable> list = new List<BmobTable>();
            data.score = 32;
            data.playerName = "bmob30";
            data.cheatMode = false;
            list.Add(data);
            data = new UserInfo();
            data.score = 33;
            data.playerName = "bmob31";
            data.cheatMode = false;
            list.Add(data);

            //dataControl.WriteInfo("Test", data, DataHandlerType.DT_Bmob);
            DataControl.Instance.WriteInfo("Test", list, DataHandlerType.DT_Bmob);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

            DataControl.Instance.QueryInfo<UserInfo, int>("Test", "score", 33, Call, DataHandlerType.DT_Bmob);
            DataControl.Instance.QueryInfo<UserInfo,int>("Test", "score", 25, Call, DataHandlerType.DT_Local);

        }
        //修改一行
        if (Input.GetKeyDown(KeyCode.U))
        {
            var info = new UserInfo();
            info.objectId = "6d99211890";
            info.score = 120;
            DataControl.Instance.UpdateInfo("Test", info, DataHandlerType.DT_Bmob);
        }
        //删除一行
        if (Input.GetKeyDown(KeyCode.D))
        {
            DataControl.Instance.DeleteInfo<string>("Test", "playerName", "bmob", DataHandlerType.DT_Bmob);
        }
#endif


    }
}

