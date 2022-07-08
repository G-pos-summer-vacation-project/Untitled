using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInfo
{
    string eventName;
    float eventProbability;
    int placeNum;

    public EventInfo(string _eventName, float _eventProbability, int _placeNum)
    {
        eventName = _eventName;
        eventProbability = _eventProbability;
        placeNum = _placeNum;
    }

    public bool isOccured()
    {
        var rand = new System.Random();
        return rand.NextDouble() <= eventProbability;
    }
}