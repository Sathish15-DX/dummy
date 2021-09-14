using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag2DScript : MonoBehaviour
{
    float rotspeed = 250.0f;
    private void OnMouseDrag()
    {
        float rotz = Input.GetAxis("Mouse X") * rotspeed * Mathf.Deg2Rad;
     //   float roty = Input.GetAxis("Mouse Y") * rotspeed * Mathf.Deg2Rad;

       // transform.Rotate(Vector3.up, -rotx);
        transform.Rotate(Vector3.up, rotz);
    }
}
