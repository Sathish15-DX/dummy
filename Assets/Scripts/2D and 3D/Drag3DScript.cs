using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag3DScript : MonoBehaviour
{
    // Start is called before the first frame update
    float rotspeed = 200.0f;
    private void OnMouseDrag()
    {
        float rotx = Input.GetAxis("Mouse X") * rotspeed * Mathf.Deg2Rad;
        float roty = Input.GetAxis("Mouse Y") * rotspeed * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotx);
        transform.Rotate(Vector3.right, roty);
    }
}
