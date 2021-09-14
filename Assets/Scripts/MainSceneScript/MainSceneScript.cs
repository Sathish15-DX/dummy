using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneScript : MonoBehaviour
{
   [SerializeField]
    private GameObject welcomepage;
    [SerializeField]
    private GameObject quitpanel;
    private static bool enteronce;
    int click = 0;
    
    private void OnEnable()
    {
        GameObject.Find("chatbot").GetComponent<ChatbotController>().chatboxclosefun();

        if (enteronce)
        {
            welcomepage.SetActive(false);
        }
        else
        {
            welcomepage.SetActive(true);
        }
    }
    private void Start()
    {
        quitpanel.SetActive(false);
    }
      void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           quitpanel.SetActive(true);
        }
    }
    public void ApplicationQuitYes()
    {
        Application.Quit();
    }
    public void ApplicationQuitNo()
    {
        quitpanel.SetActive(false);
    }


    public void btnclick(bool enter)
    {
        enteronce = enter;
        StartCoroutine(welcomefalse());
       
      
    }
    IEnumerator welcomefalse()
    {
        yield return new WaitForSeconds(1f);
        welcomepage.SetActive(false);
    }
        public void btnSceneLoad(string name)
    {
       
        StartCoroutine(LoadYourAsyncScene(name));
    }
    IEnumerator LoadYourAsyncScene(string name)
    {
   

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
