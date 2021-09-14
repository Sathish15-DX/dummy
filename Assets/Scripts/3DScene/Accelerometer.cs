using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    private Rigidbody rigid;
    float speed = 70.0f;
    float dirx;
    float diry;
    private bool AccVar=false, gyrovar=false;
   
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
       
    }
    public void AccselectionFun(bool set)
    {
        AccVar = set;
    }
   

    // Update is called once per frame
    void Update()
    {
        if (AccVar)
        {
            //Vector3 dir = Vector3.zero;
            //dir.x = Input.acceleration.x;
            //dir.z = Input.acceleration.z;
            //dir *= Time.deltaTime;
            //transform.Translate(dir * speed);

            Vector3 tilt = new Vector3(Input.acceleration.x, 0, 0);
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
            rigid.AddForce(tilt * speed);
        }

    }
   

}
