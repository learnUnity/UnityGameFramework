using UnityEngine;
using System.Collections;
using System;
public class SingletionException : Exception
{
    public string error;

    public SingletionException(string message) 
    {
        this.error = message;
    }
	
}
