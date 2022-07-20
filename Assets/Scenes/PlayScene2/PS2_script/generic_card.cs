using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class generic_card : MonoBehaviour, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("drag");
        Vector2 mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mouseposition);
        transform.position = worldPos;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        float X = Input.mousePosition.x, Y = Input.mousePosition.y;
        Debug.Log("end");
        if (X > 2)
        {
            if (Y > 3.5)
            {
                Destroy(gameObject);
            }
            else if (Y < -3.5)
            {
                Destroy(gameObject);
            }
            //addforce.right
            //destroy
        }
        else if (X < -2)
        {
            if (Y > 3.5)
            {
                Destroy(gameObject);
            }
            else if (Y < -3.5)
            {
                Destroy(gameObject);
            }
        }
        transform.position = new Vector2(0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
