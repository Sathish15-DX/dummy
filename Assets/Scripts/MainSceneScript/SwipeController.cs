using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public UIFader uifade;
    public CanvasGroup[] uiElements;
    public Button[] uibuttons;
    public static Vector3 panelLocation=new Vector3(0,0,0);
    public float percentThreshold = 0.2f;
    public float easing = 0.5f;
    public int totalPages = 1;
    public static int currentPage = 1;
    [SerializeField]
    GameObject[] pointArr;
    private CanvasGroup chatbot;
    public DF2ClientAudioTester sendobj;


    // Start is called before the first frame update
    void OnEnable()
    {
     //   chatbot = GameObject.Find("chatbtn").GetComponent<CanvasGroup>();
    }
        void Start()
    {
       
        // panelLocation = transform.position;
        transform.localPosition = panelLocation;
        pointfun();
    }
   
    public void OnDrag(PointerEventData data)
    {
        GameObject.Find("chatbot").GetComponent<ChatbotController>().chatboxclosefun();
        for (int i = 0; i < uiElements.Length; i++)
        {
          //  uibuttons[i].GetComponent<RectTransform>().localScale = new Vector3(0.9f, 0.9f, 0.9f);
            StartCoroutine(uifade.FadeCanvasGroup(uiElements[i], uiElements[i].alpha, 0, .01f));
            GameObject.Find("chatbot").GetComponent<ChatbotController>().chatfadeIn();

        }
        for (int i = 0; i < uibuttons.Length; i++)
        {
            uibuttons[i].GetComponent<RectTransform>().localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }

            float difference = data.pressPosition.x - data.position.x;
        transform.localPosition = panelLocation - new Vector3(difference, 0, 0);
    }
    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if (Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;

            if (percentage > 0 && currentPage < totalPages)
            {
                currentPage++;
                newLocation += new Vector3(-Screen.width, 0, 0);
            }
            else if (percentage < 0 && currentPage > 1)
            {
                currentPage--;
                newLocation += new Vector3(Screen.width, 0, 0);
            }
            print(currentPage);
            pointfun();
            StartCoroutine(SmoothMove(transform.localPosition, newLocation, easing));
            panelLocation = newLocation;
            print(currentPage);
          

        }
        else
        {
            StartCoroutine(SmoothMove(transform.localPosition, panelLocation, easing));
        }
    }
    private void pointfun()
    {
        for (int i = 0; i <= 3; i++)
        {
            if ((currentPage - 1) == i)
            {
                pointArr[currentPage - 1].transform.localScale = new Vector2(0.4f, 0.4f);
            }
            else
            {
                pointArr[i].transform.localScale = new Vector2(0.25f, 0.25f);
            }

        }
    }
    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
       
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.localPosition = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }

        for (int i = 0; i < uiElements.Length; i++)
        {
            StartCoroutine(uifade.FadeCanvasGroup(uiElements[i], uiElements[i].alpha, 1, .5f));
            GameObject.Find("chatbot").GetComponent<ChatbotController>().chatfadeout();
        }
         for (int i = 0; i < uibuttons.Length; i++)
        {
                uibuttons[i].GetComponent<RectTransform>().localScale = Vector3.Lerp(uibuttons[i].GetComponent<RectTransform>().localScale, uibuttons[i].GetComponent<RectTransform>().localScale=Vector3.one, Time.deltaTime * 100);
        }
       
        print(transform.localPosition);
        print(panelLocation);
        //if (currentPage == 1)
        //{
        //    sendobj.SendText("What is 2d");
        //}
        //else if (currentPage == 2)
        //{
        //    sendobj.SendText("what is 3d");
        //}
        //else if (currentPage == 3)
        //{
        //    sendobj.SendText("what is coding");
        //}
        //else if (currentPage == 3)
        //{
        //    sendobj.SendText("what is AR");
        //}

    }
    


}