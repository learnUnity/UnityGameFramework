
#region Version Info
/* ======================================================================== 
* 【本类功能概述】 
* 
* 功能： 信息结构,Bmob字段
* 文件名：UserInfo 
* 作者：Kaven 
* 时间：2016/1/19 16:42:06 
* 
* ======================================================================== 
*/
#endregion

using UnityEngine;
using System.Collections;
using cn.bmob.io;


public class UserInfo : BmobTable
{

    public string playerName { get; set; }

    public BmobInt score { get; set; }

    public BmobBoolean cheatMode { get; set; }

    public override void readFields(BmobInput input)
    {
        base.readFields(input);
        //读取属性值

        this.playerName = input.getString("playerName");
        this.score = input.getInt("score");
        this.cheatMode = input.getBoolean("cheatMode");
    }

    public override void write(BmobOutput output, bool all)
    {
        base.write(output, all);
        //写到发送端

        output.Put("playerName", this.playerName);
        output.Put("score", this.score);
        output.Put("cheatMode", this.cheatMode);
    }



}

