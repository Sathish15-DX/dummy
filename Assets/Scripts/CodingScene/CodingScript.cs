using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodingScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private InputField codetxt;
    [SerializeField]
    private Text debugtxt;
    string[] shapes = { "Cube", "Sphere", "Capsule", "Cylinder" };
    string[] Axis = { "x", "y", "z"};
    GameObject visibleshape;
    string textcont;
    string shape;
    [SerializeField]
    GameObject[] ShapeGobj;
    [SerializeField]
    private GameObject instpanel;
    string[] words1 =new string[] { };
    string[] words2 =new string[] { };
    string[] words3 =new string[] { };
    void Start()
    {
        print("this ");
      //  codetxt.ActivateInputField();

        for (int i = 0; i < ShapeGobj.Length; i++)
        {

            ShapeGobj[i].SetActive(false);
        }
    }

    public void myfunction()
    {
        for (int i = 0; i < ShapeGobj.Length; i++)
        {
            ShapeGobj[i].SetActive(false);
        }
        
        textcont = codetxt.text;
        print("textcont" + textcont);
        string[] lines = textcont.Split('\n');
     
        if (lines.Length>0)
        {
           words1 = lines[0].Split(' ');
           
        }
        else
        {
            words1 = new string[] { };
        }
        if (lines.Length > 1)
        {
           words2 = lines[1].Split(' ');
        }
        else
        {
            words2 = new string[] { };
        }
        if (lines.Length > 2)
        {
           words3 = lines[2].Split(' ');
        }
        else
        {
            words3 = new string[] { };
        }


        if (words1.Length > 1)
        {
            if (words1[0] == "Insert")
            {
                debugtxt.text = "";
                for (int i = 0; i < shapes.Length; i++)
                {
                    if (string.Equals(words1[1], shapes[i] + ';'.ToString()))
                    {
                        visibleshape = ShapeGobj[i];
                        ShapeGobj[i].SetActive(true);
                        debugtxt.text = "";
                        break;
                    }
                    else
                    {
                        debugtxt.text = "the code is invalid keywords";
                    }
                }

            }
            else
            {
                debugtxt.text = "the code is invalid operations";
            }
        }
        else
        {
            debugtxt.text = "Syntax error";
        }
       
        if (words2.Length > 1)
        {
            //print(words2[0]);
            if (words2[0] == "Rotate")
            {
                debugtxt.text = "";
                for (int i = 0; i < Axis.Length; i++)
                {
                    if (string.Equals(words2[1], Axis[i] + ';'.ToString()))
                    {
                        
                        RotateObj(Axis[i] + ';'.ToString());
                        debugtxt.text = "";
                        break;
                    }
                    else
                    {
                        debugtxt.text = "the code is invalid keywords";
                    }
                }

            }
            else
            {
                debugtxt.text = "the code is invalid operations";
            }
        }
        else
        {
            iTween.Stop();
        }

    }
    private void RotateObj(string axis)
    {
        print(axis);
        if (axis == "x;")
        {
            iTween.RotateBy(visibleshape, iTween.Hash(
                       "x", 1.0f,
                       "time", 3f,
                       "easetype", "linear",
                       "looptype", iTween.LoopType.loop
                   ));
        }
       else if (axis == "y;")
        {
            iTween.RotateBy(visibleshape, iTween.Hash(
                       "y", 1.0f,
                       "time", 3f,
                       "easetype", "linear",
                       "looptype", iTween.LoopType.loop
                   ));
        }
        else if (axis == "z;")
        {
            iTween.RotateBy(visibleshape, iTween.Hash(
                       "z", 1.0f,
                       "time", 3f,
                       "easetype", "linear",
                       "looptype", iTween.LoopType.loop
                   ));
        }

    }
   
    public void SringEmptyFun()
    {
        debugtxt.text = "";
       
    }
   
}
