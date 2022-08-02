using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnPause : MonoBehaviour
{
    public GameObject GetPauseWindow()
    {
        return transform.GetChild(0).gameObject;
    }
}
