using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class CSVDataBase
{
    private string m_strFileName;

    private string[] m_rowList;
    public string[] RowList
    {
        get { return m_rowList; }
    }

    public CSVDataBase(string fileName)
    {
        m_strFileName = fileName;
    }

    protected virtual string[] GetCSVData()
    {
        //读取csv二进制文件  
        TextAsset binAsset = Resources.Load("Data/" + m_strFileName, typeof(TextAsset)) as TextAsset;

        if (binAsset == null)
            return null;

        //读取每一行的内容  
        string[] lineArray = binAsset.text.Split('\r');

        //过滤最后出现空格行,防止手动操作失误
        int emtityRow = 0;
        for (int i = lineArray.Length - 1; i > 0; i--)
        {
            if (lineArray[i].Length <= 1)
            {
                emtityRow++;
            }
        }
        string[] temp = new string[lineArray.Length - 1 - emtityRow];

        //第一行不读取
        for (int i = 1; i < lineArray.Length - emtityRow; i++)
        {
            temp[i-1] = lineArray[i];
        }
        return temp;
    }


    public System.Object ReadData()
    {
        try
        {
            m_rowList = GetCSVData();
            return Init(m_rowList);
        }
        catch (UnityException e)
        {
            Debug.LogError("read file error :" + m_strFileName + "  " + e.Message);
        }

        return default(System.Object);
    }


    public abstract System.Object Init(string[] rowList);

    public virtual int PareInt(string str) 
    {
        if (string.IsNullOrEmpty(str)) 
        {
            return 0;
        }
        return int.Parse(str);
    }

    public virtual float PareFloat(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return 0;
        }
        return float.Parse(str);
    }

    public virtual double PareDouble(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return 0;
        }
        return double.Parse(str);
    }

}

