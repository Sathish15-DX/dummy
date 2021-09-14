using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyGyro : MonoBehaviour
{
    private bool gyroEnabled, gyrovar=false;
    GameObject cameraContainer;
    private UnityEngine.Gyroscope gyro1;
    // Start is called before the first frame update
    void Start()
    {
        cameraContainer = new GameObject("cameracontainer");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
       
    }
    public void GyroselectionFun(bool set)
    {
        print("setsetset" + set);
        gyrovar = set;
    }
    private bool gyroEnabledFun()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro1 = Input.gyro;
            gyro1.enabled = true;
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        print("gyrovar" + gyrovar);
        print("gyroEnabledFun" + gyroEnabledFun());
        if (gyroEnabledFun() && gyrovar)
        {
            cameraContainer.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
            this.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
        }
    }
}
