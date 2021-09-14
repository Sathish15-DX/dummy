using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class AuthenticatiionScript : MonoBehaviour
{
    //--------------------------JsonPath---------------------------------
    string jsonurl = "C:/Users/Admin/Documents/GitHub/CodingKids/Auth.json";
    //-------------------------------------------------------------
    string jsonSavePath = null;
    string jsonstr = null;
    string jsonAsseturl = null;
    //----------------Creating Json Structure--------------------------------------
    [Serializable]
    public struct  Projects
    {
        public String ProjectName;
        public String Access;
        
    }
    Projects[] ProjectInfo;
    //--------------------------Start--------------------------------------------
    private void Start()
    {
        StartCoroutine(GetProjects());
    }
    //--------------------------RefreshFunctionality--------------------------------------------
    public void RefreshFun()
    {
        StartCoroutine(GetProjects());
    }
    //------------------------Request and recieve json Access key value--------------------------------------
    IEnumerator GetProjects()
    {
            UnityWebRequest request = UnityWebRequest.Get(jsonurl);
            UnityWebRequestAsyncOperation requestAsyncOperation = request.SendWebRequest();
            while (!requestAsyncOperation.isDone)
            {
                Debug.Log(requestAsyncOperation.progress * 100);
                yield return null;
            }
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log("Http or Network Error");
            }
            else
            {
                if (request.isDone)
                {
                    ProjectInfo = JsonHelper.FromJson<Projects>(request.downloadHandler.text);
                    jsonstr = request.downloadHandler.text;
                    print(Application.productName);
                    for (int i = 0; i < ProjectInfo.Length; i++)
                    {
                        if (Application.productName == ProjectInfo[i].ProjectName)
                        {
                            if (ProjectInfo[i].Access=="yes")
                            {
                                StartCoroutine(LoadYourAsyncScene());
                            }
                        }
                    }

                }

            }

     }
    //----------------------------------------SceneLoading When getting access-----------------
      IEnumerator LoadYourAsyncScene()
      {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainScene");

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
      }

}
