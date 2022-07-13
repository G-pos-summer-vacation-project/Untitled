using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generic_garbage_script : MonoBehaviour
{
    float x;
    float amount = 1.5f;
    bool iscenter = true;
    bool InCenter = false;
    public int gar_sequence;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    public void isCenterEmpty(bool m)
    {
        iscenter = m;
    }
    public void sendToMiddle()
    {
        if (iscenter)
        {
            transform.position = new Vector2(0, 0);
            InCenter = true;
        }
    }
    public void destroy_self()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = new Vector2(0, 0);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        x = gameObject.transform.position.x;
        if (x < -1)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            sendToMiddle();
        }
        else if(!InCenter)
        {
            rb.AddForce(Vector2.left*amount, ForceMode2D.Force);
        }
        
    }
}
