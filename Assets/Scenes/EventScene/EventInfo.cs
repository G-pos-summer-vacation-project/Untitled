using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInfo
{
    public string corpus;
    public string image;
    public string function;
    public int[] path = new int[3];
    public string name;

    public EventInfo(string _corpus, string _image, string _function, int _path1, int _path2 = 0, int _path3 = 0)
    {
        corpus = _corpus;
        image = _image;
        path[0] = _path1;
        path[1] = _path2;
        path[2] = _path3;
        function = _function;
    }

    public EventInfo(string _corpus, string _image, string _function, string _name, int _path1, int _path2 = 0, int _path3 = 0)
    {
        corpus = _corpus;
        image = _image;
        path[0] = _path1;
        path[1] = _path2;
        path[2] = _path3;
        function = _function;
        name = _name;
    }
}