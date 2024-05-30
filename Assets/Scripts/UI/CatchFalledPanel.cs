using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFalledPanel : BasePanel
{
    public AnimationCurve showCurve;
    public AnimationCurve hideCurve;
    public float animSpeed;
    public GameObject panel;

    private void Awake()
    {
        panel = gameObject;
    }

    private void Start()
    {
        StartCoroutine(ShowPanel(panel));
    }

    IEnumerator ShowPanel(GameObject obj)
    {
        float timer = 0;
        while (timer <= 1)
        {
            obj.transform.localScale = Vector3.one * showCurve.Evaluate(timer);
            timer += Time.deltaTime * animSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(2);
        StartCoroutine(HidePanel(panel));
    }
    IEnumerator HidePanel(GameObject obj)
    {
        float timer = 0;
        while (timer <= 1)
        {
            obj.transform.localScale = Vector3.one * hideCurve.Evaluate(timer);
            timer += Time.deltaTime * animSpeed*5f;
            
            yield return null;
        }
        base.ClosePanel();
    }

}
