  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TweenScript :MonoBehaviour
{
    // Start is called before the first frame update   
    
    public GameObject Panel;
    public CanvasGroup canvas;
    public float xvalue;
    public float yvalue;
    
    public void MovetweenFun()
    {
       
       
         // canvas = GameObject.FindObjectOfType<Canvas>().GetComponent<CanvasGroup>();
        canvas.blocksRaycasts = false;
      iTween.MoveBy(Panel, iTween.Hash("x", xvalue,
        "y", yvalue, 
      //  "easeType", "easeOutBounce", 
        "oncomplete", "tweencompleteFun",
        "oncompletetarget", gameObject));
    }
    public void FadeIn()
    {
        iTween.ValueTo(Panel.gameObject, iTween.Hash(
            "from", 0f, "to", 1f,
            "time", 3f, "easetype", "linear",
            "onupdate", "setAlpha"));
    }
    public void setAlpha(float newAlpha)
    {
       
    }
        public void FadetweenFun()
    {
       // canvas = GameObject.FindObjectOfType<Canvas>().GetComponent<CanvasGroup>();
        canvas.blocksRaycasts = false;
        iTween.FadeTo(Panel, iTween.Hash("alpha", 0, "time", 1.0f, "easetype", "easeInOutQuad",
            "oncomplete", "tweencompleteFun",
          "oncompletetarget", gameObject));
        
    }

    public void tweencompleteFun()
    {
       canvas.blocksRaycasts = true;
    }


}
