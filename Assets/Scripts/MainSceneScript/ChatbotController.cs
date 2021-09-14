using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChatbotController : MonoBehaviour
{
    // Start is called before the first frame update
    public UIFader uifade;
    [SerializeField]
    private GameObject Camera;
    public GameObject internetpanel;
    [SerializeField]
    private GameObject chatbox;
    [SerializeField]
    private GameObject chatbtn;
    Scene m_Scene;
    string sceneName;
    [SerializeField]
    private CanvasGroup chatbtngrup;
    private void Start()
    {
          chatbox.SetActive(false);
          Camera.SetActive(false);
        internetpanel.SetActive(false);
    }    
    private void Update()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
        if(sceneName== "ARscene")
        {
            chatbtn.SetActive(false);
        }
        else if(!chatbox.activeSelf)
        {
            chatbtn.SetActive(true);
        }
        

    }
    void Awake()
    {
        int numChatbotController = FindObjectsOfType<ChatbotController>().Length;
        if (numChatbotController != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    public void chatbtnclickfun()
    {
        Camera.SetActive(true);
         chatbox.SetActive(true);
        chatbtn.SetActive(false);
       
      //  iTween.ScaleTo(chatbox.gameObject, iTween.Hash("x", 1, "y", 1, "z", 1,"Time",0.3, "default", .1, "oncomplete", "tweencompleteFun1",
        //  "oncompletetarget", gameObject));
    }
    public void chatboxclosefun()
    {
        print("chatboxclosefun fun");
        chatbtn.SetActive(true);
        chatbox.SetActive(false);
        Camera.SetActive(false);
        //iTween.ScaleTo(chatbox.gameObject, iTween.Hash("x", 0, "y", 0, "z", 0, "Time", 0.3, "default", .1, "oncomplete", "tweencompleteFun2",
        //   "oncompletetarget", gameObject));

    }
    public void chatfadeIn()
    {
        StartCoroutine(uifade.FadeCanvasGroup(chatbtngrup, chatbtngrup.alpha, 0, .01f));
    }
    public void chatfadeout()
    {
        StartCoroutine(uifade.FadeCanvasGroup(chatbtngrup, chatbtngrup.alpha, 1, .01f));
    }

    public void internetpanelfalseFun()     
    {
        internetpanel.SetActive(false);

    }
    public void internetpaneltrueFun()
    {
        internetpanel.SetActive(true);
        chatboxclosefun();
    }
    void tweencompleteFun2()
    {
        chatbox.SetActive(false);
       
    }
    public void textchange()
    {
        print("enter the text");
    }


}
