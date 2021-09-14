using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        iTween.RotateBy(gameObject, iTween.Hash(
                    "z", 1.0f,
                    "time", 3f,
                    "easetype", "linear",
                    "looptype", iTween.LoopType.loop
                ));
    }

   
}
