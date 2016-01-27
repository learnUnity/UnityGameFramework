
#region Version Info
/* ======================================================================== 
* 【本类功能概述】 
* 
* 功能：数据表类
* 文件名：BmobGameObject 
* 作者：Kaven 
* 时间：2016/1/18 23:56:33 
* 
* ======================================================================== 
*/
#endregion

using UnityEngine;
using System.Collections;
using cn.bmob.io;
using System;

public class BmobGameObject : BmobTable
{

    //score、playerName、cheatMode是后台数据表对应的字段名称
    public BmobInt score { get; set; }
    public String playerName { get; set; }
    public BmobBoolean cheatMode { get; set; }
    public BmobBoolean ss { get; set; }
    public BmobBoolean a { get; set; }

    //读字段值
    public override void readFields(BmobInput input)
    {
        base.readFields(input);

//         this.score = input.getInt("score");
//         this.cheatMode = input.getBoolean("cheatMode");
//         this.playerName = input.getString("playerName");
        this.ss = input.getBoolean("ss");
        this.a = input.getBoolean("a");
    }

    //写字段值
    public override void write(BmobOutput output, Boolean all)
    {
        base.write(output, all);

        output.Put("score", this.score);
        output.Put("cheatMode", this.cheatMode);
        output.Put("playerName", this.playerName);
        output.Put("ss", this.ss);
        output.Put("a", this.a);
    }
}

