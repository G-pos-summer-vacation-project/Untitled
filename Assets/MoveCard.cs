using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCard : MonoBehaviour
{
    public RectTransform thiscard;
    bool isOver = false;
    // Start is called before the first frame update
    void Start()
    {
        thiscard.position = Vector2.zero;
    }

    private void mouseinput()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isOver = true;
        }
        else isOver = false;
    }
    // Update is called once per frame
    void Update()
    {
        mouseinput();
        if (isOver)
        {
            Vector2 mousepos = Input.mousePosition;
            thiscard.position = mousepos / 1000;

        }
        
    }
}
