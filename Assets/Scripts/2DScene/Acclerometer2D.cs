using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acclerometer2D : MonoBehaviour
{
    private Rigidbody rigid;
    float speed = 3.0f;
    float dirx;
    float diry;
    private bool Acc2DVar = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();

    }
    public void AccselectionFun(bool set)
    {
        Acc2DVar = set;
    }

    void Update()
    {
        if (Acc2DVar)
        {
            dirx = Input.acceleration.x;
            diry = Input.acceleration.y;
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -1.9f, 1.9f), Mathf.Clamp(transform.position.y, -4f, 1.9f));
        }

    }
    private void FixedUpdate()
    {
        if(Acc2DVar)
        {
            rigid.velocity = new Vector3(dirx, diry, 0f) * speed;
        }
    }
}
