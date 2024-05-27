using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerOne : PlayerMgr
{
    private BasePanel fade;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(StartFadePanel());
    }

    // Update is called once per frame
    void Update()
    {
        if (inputAllowed)
        {
            mymove(true,true,true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    /*IEnumerator StartFadePanel()
    {
        fade = UIManager.Instance.OpenPanel(UIConst.FadePanel);
        fade.gameObject.GetComponentInChildren<FadeInOut>().fadeImage.color.a = 1f;
        fade.gameObject.GetComponentInChildren<FadeInOut>().StartFadeIn();
        yield return new WaitForSeconds(1f);
    }*/
}