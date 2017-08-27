using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vuforia;

public class VirtualButtonManager : MonoBehaviour, IVirtualButtonEventHandler{
    public GameObject model;
    public GameObject video;
    public AudioClip clickAudio;
   
    public enum TriggerType
    {
        VR_TRIGGER,
        AR_TRIGGER
    }
    
    private VideoPlayerHelper mvideoPlayerHelper;
    private TransitionManager mTransitionManager;
    public TriggerType triggerType = TriggerType.AR_TRIGGER;
	// Use this for initialization
	void Start () {
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterEventHandler(this);
        }

        mTransitionManager = FindObjectOfType<TransitionManager>();
	}

    void OnEnable() {
        
		
    }

	// Update is called once per frame
	void Update () {
	
	}
   

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){

        Debug.Log("OnButtonPressed:" + vb.VirtualButtonName);
        VideoPlaybackBehaviour videopb = GetComponentInChildren<VideoPlaybackBehaviour>();
        
       
        switch (vb.VirtualButtonName)
        {
            case "btnModel":
                Debug.Log("Boton modelo pressed");
                model.gameObject.SetActive(true);
                video.gameObject.SetActive(false);
                if (videopb != null && videopb.CurrentState == VideoPlayerHelper.MediaState.PLAYING)
                {
                    videopb.VideoPlayer.Pause();
                }
                break;

            case "btnVideo":
                Debug.Log("Boton video pressed");
                video.gameObject.SetActive(true);
                model.gameObject.SetActive(false);
                break;

            case "btnVR":
                Debug.Log("Boton vr pressed");
                video.gameObject.SetActive(false);
                if (videopb != null && videopb.CurrentState == VideoPlayerHelper.MediaState.PLAYING)
                {
                    videopb.VideoPlayer.Pause();
                }
                model.gameObject.SetActive(false);
                
                break;

            case "btnVRElephant":
                Debug.Log("Boton vr elephant pressed");
                video.gameObject.SetActive(false);
                if (videopb != null && videopb.CurrentState == VideoPlayerHelper.MediaState.PLAYING)
                {
                    videopb.VideoPlayer.Pause();
                }
                bool goingBackToVR = (triggerType == TriggerType.VR_TRIGGER);
                mTransitionManager.Play(goingBackToVR);
                StartCoroutine(ResetAfter(0.3f * mTransitionManager.transitionDuration));
                break;

        }

  }
    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        Debug.Log("Pressed");
    }

    private IEnumerator ResetAfter(float seconds)
    {

        yield return new WaitForSeconds(seconds);

        
    }
   

    

}
