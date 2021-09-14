using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Syrus.Plugins.DFV2Client;
using TMPro;
using UnityEngine.UI;
using WCP;

public class DF2ClientAudioTester : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    public ChatbotController chatbot;

    public WChatPanel wcp;

    TextMeshProUGUI PlaceHolderText;

    public InputField content;

	public Text chatbotText;

	private DialogFlowV2Client client;

	public AudioClip testClip;

	public AudioSource audioPlayer;

	private string languageCode = "en-US";

	private bool isEnglish = true;

	public GameObject WaitingPanel;

    // Start is called before the first frame update
    void Start()
    {
		client = GetComponent<DialogFlowV2Client>();
		audioPlayer = GetComponent<AudioSource>();
        string sessionName = GetSessionName();
        client.ChatbotResponded += LogResponseText;
        client.DetectIntentError += LogError;
		WaitingPanel.SetActive(false);

    }
    private void Update()
    {
	    if (Input.GetKeyDown(KeyCode.F1))
	    {
		    byte[] audioBytes = WavUtility.FromAudioClip(testClip);
		    string audioString = Convert.ToBase64String (audioBytes);
		    SendAudio(audioString);
	    }
    }

    private void LogResponseText(DF2Response response)
	{
		WaitingPanel.SetActive(false);
      //  wcp.AddChatAndUpdate(false, response.queryResult.fulfillmentText, 0);
        byte[] audioBytes = Convert.FromBase64String(response.OutputAudio);
		AudioClip clip = WavUtility.ToAudioClip(audioBytes);
		audioPlayer.clip = clip;
		audioPlayer.Play();
        int val = UnityEngine.Random.Range(0, 4);
        print("vallllll" + val);
        if (val==0)
        {
            anim.SetTrigger("hitrigger");
        }
        else if (val == 1)
        {
            anim.SetTrigger("hellotrigger");
        }
        else
        {
            anim.SetTrigger("talktrigger");
        }
       
       
    }

	private void LogError(DF2ErrorResponse errorResponse)
	{
		WaitingPanel.SetActive(false);
		
	}

    
	//@hoatong
	public void SendAudio(string audioString)
	{
		WaitingPanel.SetActive(true);
		string sessionName = GetSessionName();
        client.DetectIntentFromAudio(audioString, sessionName);
	}
    public void SendText(string sendtext)
    {
     
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
            chatbot.internetpaneltrueFun();
        }
        else
        {
           // wcp.AddChatAndUpdate(true, sendtext, 1);
            WaitingPanel.SetActive(true);
            string sessionName = GetSessionName();
            client.DetectIntentFromText(sendtext, sessionName);

        }

    }

    public void SendText()
	{
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
            chatbot.internetpaneltrueFun();
        }
        else
        {
            string query = content.text;
          //  wcp.AddChatAndUpdate(true, content.text, 1);
            WaitingPanel.SetActive(true);
            string sessionName = GetSessionName();
            client.DetectIntentFromText(content.text, sessionName);
          
        }
       
	}


	public void SendEvent()
	{
        client.DetectIntentFromEvent(content.text,
			new Dictionary<string, object>(), GetSessionName());
	}

	public void Clear()
	{
        client.ClearSession(GetSessionName());
	}


    private string GetSessionName(string defaultFallback = "DefaultSession")
    {
        string sessionName = "";
        if (sessionName.Trim().Length == 0)
            sessionName = defaultFallback;
        return sessionName;
    }

    #region AUDIO RECORD

    AudioClip recordedAudioClip;

    //Keep this one as a global variable (outside the functions) too and use GetComponent during start to save resources
    //AudioSource audioSource;
    
    private float startRecordingTime;

    private bool isRecording = false;

   // public Text recordButtonText;
    
    public void OnButtonRecord()
    {
	    if (!isRecording)
	    {
		    StartRecord();
		    isRecording = true;
		   // recordButtonText.text = "Stop Record";
	    }
	    else
	    {
		    isRecording = false;
		   // recordButtonText.text = "Start Record";
		    AudioClip recorded =  StopRecord();
		    
		    byte[] audioBytes = WavUtility.FromAudioClip(recorded);
		    string audioString = Convert.ToBase64String (audioBytes);
		    SendAudio(audioString);
	    }
    }

    public AudioClip StopRecord()
    {
	   // WaitingRecord.SetActive(false);
	    //End the recording when the mouse comes back up, then play it
	    Microphone.End("");

	    //Trim the audioclip by the length of the recording
	    AudioClip recordingNew = AudioClip.Create(recordedAudioClip.name,
		    (int) ((Time.time - startRecordingTime) * recordedAudioClip.frequency), recordedAudioClip.channels,
		    recordedAudioClip.frequency, false);
	    float[] data = new float[(int) ((Time.time - startRecordingTime) * recordedAudioClip.frequency)];
	    recordedAudioClip.GetData(data, 0);
	    recordingNew.SetData(data, 0);
	    this.recordedAudioClip = recordingNew;

	    return recordedAudioClip;
	    //Play recording
	    //audioSource.clip = recordedAudioClip;
	    //audioSource.Play();
    }

    public void StartRecord()
    {
	 //   WaitingRecord.SetActive(true);
	    //Get the max frequency of a microphone, if it's less than 44100 record at the max frequency, else record at 44100
	    int minFreq;
	    int maxFreq;
	    int freq = 44100;
	    Microphone.GetDeviceCaps("", out minFreq, out maxFreq);
	    if (maxFreq < 44100)
		    freq = maxFreq;

	    //Start the recording, the length of 300 gives it a cap of 5 minutes
	    recordedAudioClip = Microphone.Start("", false, 300, 44100);
	    startRecordingTime = Time.time;
    }

    #endregion
}
