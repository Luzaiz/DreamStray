using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;
using UnityEngine.SceneManagement;

public class HomeSignal : MonoBehaviour
{
    public PlayableDirector playableDirector;
    private PlayerMove playerCtr;
    public CinemachineVirtualCamera toWindowCam;
    public CinemachineVirtualCamera toSleepCam;
    public GameObject fade;

    private float timelineDuration;
    void Start()
    {
        playerCtr = GameObject.Find("DreamCat").GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayTimeline();
        }
    }
    void PlayTimeline()
    {
        playerCtr.inputAllowed = false;
        playerCtr.animator.SetBool("IsAnim",true);
        /*播放“喵”音乐*/
        StartCoroutine(WaitForTimelineFinish());
    }

    IEnumerator WaitForTimelineFinish()
    {
        //StartCoroutine(BlendToCamera(switchToCam, 2.0f));
        timelineDuration = (float)playableDirector.duration;
        playableDirector.Play();
        toSleepCam.Priority = 25;
        yield return new WaitForSeconds(timelineDuration);
        fade.SetActive(true);
        fade.GetComponentInChildren<FadeInOut>().StartFadeOut();
        yield return new WaitForSeconds(2f);
        playerCtr.animator.SetBool("IsAnim",false);
        SceneManager.LoadScene("Day1");
    }
    //报错
    /*IEnumerator BlendToCamera(CinemachineVirtualCamera targetCamera, float blendDuration)  
    {
        CinemachineBlend blend = targetCamera.CreateBlend(blendDuration, new CinemachineBlendDefinition(  
            1f, // blend weight  
            0f  // start offset  
        ));
        targetCamera.Priority = int.MaxValue;
        yield return new WaitForSeconds(blendDuration);
    }  */

    public void PlayMiaoPanel()
    {
        UIManager.Instance.OpenPanel(UIConst.MiaoPanel);
        Invoke("CloseMiaoPanel", 2f);
    }
    void CloseMiaoPanel()
    {
        UIManager.Instance.ClosePanel(UIConst.MiaoPanel);
    }
}
