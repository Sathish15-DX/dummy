using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gyroscope2D : MonoBehaviour
{
    private bool gyrovar = false;
    [SerializeField]
    private Text myText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GyroselectionFun(bool set)
    {
        gyrovar = set;
    }
    // Update is called once per frame
    void Update()
    {
        print(gyrovar);
        if(gyrovar)
        {
            myText.gameObject.SetActive(true);
        }
        else
        {
            myText.gameObject.SetActive(false);
        }
    }
}
