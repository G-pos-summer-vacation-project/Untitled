using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizing : MonoBehaviour
{
    private void Awake()
    {
        var camera = GetComponent<Camera>();
        var size = camera.orthographicSize;
        float scaleHeight = ((float)Screen.width / Screen.height) / ((float)9 / 16);
        float scaleWidth = 1f / scaleHeight;

        if(scaleHeight > 1)
        {
            camera.orthographicSize = size / scaleHeight;
        }
    }
}
