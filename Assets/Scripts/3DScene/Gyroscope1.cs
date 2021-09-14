using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroscope1 : MonoBehaviour
{
    private bool gyroEnabled, gyrovar = false;
    private UnityEngine.Gyroscope gyro1;
    //public GameObject cameraContainer;
    private Quaternion rot;
    private Vector3 startEulerAngles;
    private Vector3 startGyroAttitudeToEuler;

    private void Start()
    {
       // cameraContainer = new GameObject("camera container");
        //cameraContainer.transform.position = transform.position;
        //transform.SetParent(cameraContainer.transform);
    }
    public void GyroselectionFun(bool set)
    {
        gyrovar = set;
    }
    private bool gyroEnabledFun()
    {
        if(SystemInfo.supportsGyroscope)
        {
            gyro1 = Input.gyro;
            gyro1.enabled = true;
           // cameraContainer.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
             rot = new Quaternion(0f, 0, 0, 0);
            return true;
        }
        return false;
    }
    private void Update()
    {
       if(gyroEnabledFun() && gyrovar)
        {
         transform.rotation = new Quaternion(0, Input.gyro.attitude.y,0, Input.gyro.attitude.w);
        }
    }

}
