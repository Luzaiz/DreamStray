using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class PlayerSeven : PlayerMgr
{
    public PlayableDirector playableDirector;
    public GameObject fade;

    // Start is called before the first frame update
    void Start()
    {
        PlayTimeline();
    }
    void PlayTimeline()
    {
        animator.SetBool("IsAnim",true);
        StartCoroutine(WaitForTimelineFinish());
    }

    IEnumerator WaitForTimelineFinish()
    {
        float timelineDuration = (float)playableDirector.duration;
        playableDirector.Play();
        yield return new WaitForSeconds(timelineDuration);
        fade.SetActive(true);
        fade.GetComponentInChildren<FadeInOut>().StartFadeOut();
        yield return new WaitForSeconds(2f);
        animator.SetBool("IsAnim",false);
        SceneManager.LoadScene("HomeEnd");
    }
}
