using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class generic_card : MonoBehaviour, IDragHandler, IEndDragHandler
{
    int gar_seq;
    public void get_gar_seq(int n)
    {
        gar_seq = n;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mouseposition);
        transform.position = worldPos;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mouseposition);
        float X = worldPos.x, Y = worldPos.y;
        int chamber = gar_seq / 2 + 1;
        if (X > 2)
        {
            if (1 > Y && Y > -1)
            {
                if (chamber == 3)
                {
                    correct(gar_seq);
                }
                Destroy(gameObject);
            }
        }
        else if (X < -2)
        {
            if (1 > Y && Y > -1)
            {
                if (chamber == 1)
                {
                    correct(gar_seq);
                }
                Destroy(gameObject);
            }
        }
        else if (X < 1 && X > -1)
        {
            if (Y > 3.5)
            {
                if (chamber == 2)
                {
                    correct(gar_seq);
                }
                Destroy(gameObject);
            }
            else if (Y < -3.5)
            {
                if (chamber == 4)
                {
                    correct(gar_seq);
                }
                Destroy(gameObject);
            }
        }
        transform.position = new Vector2(0, 0);
    }
    void correct(int seq)
    {
        switch (seq)
        {
            case 0:
                MainData.earnedGold += 160;
                MainData.point += 1500;
                break;
            case 1:
                MainData.earnedGold += 150;
                MainData.point += 1400;
                break;
            case 2:
                MainData.earnedGold += 200;
                MainData.point += 2000;
                break;
            case 3:
                MainData.earnedGold += 170;
                MainData.point += 1600;
                break;
            case 4:
                MainData.earnedGold += 140;
                MainData.point += 1300;
                break;
            case 5:
                MainData.earnedGold += 140;
                MainData.point += 1200;
                break;
            case 6:
                MainData.earnedGold += 180;
                MainData.point += 1300;
                break;
            case 7:
                MainData.earnedGold += 140;
                MainData.point += 1800;
                break;
        }
    }
}
