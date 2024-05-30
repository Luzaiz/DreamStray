using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class ChangeSceneTrigger : MonoBehaviour
{
    public string nextSceneName;
    public GameObject fade;

    private void Start()
    {
        if (nextSceneName == string.Empty)
        {
            Debug.LogError("没有配置下个场景的名字");
        }

        if (!fade)
        {
            Debug.LogError("没有配置fadepanel");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<PlayerMgr>().canNext)
            {
                //other.gameObject.GetComponent<PlayerMgr>().canNext = false;
                StartCoroutine(ToNextDay(nextSceneName));
            }
        }
    }

    IEnumerator ToNextDay(string nextSceneName)
    {
        fade.SetActive(true);
        fade.GetComponentInChildren<FadeInOut>().StartFadeOut();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextSceneName);
    }
}
