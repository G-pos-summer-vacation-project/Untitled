using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resolve_screensize : MonoBehaviour
{
    public GameObject square;
    void Awake()
    {
        GameObject square_left = square.transform.GetChild(1).gameObject;
        GameObject square_right = square.transform.GetChild(3).gameObject;

        var nowPos = square.transform.localPosition;
        var camera = GetComponent<Camera>();
        var size = camera.orthographicSize;
        Debug.Log(size);
        float scaleHeight = ((float)Screen.width / Screen.height) / ((float)9 / 16);

        var position = square_left.transform.localPosition;
        position.x = (position.x+nowPos.x) * scaleHeight - nowPos.x;
        square_left.transform.localPosition = position;

        position = square_right.transform.localPosition;
        position.x = (position.x + nowPos.x) * scaleHeight - nowPos.x;
        square_right.transform.localPosition = position;
    }
}
