using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgainTrigger : MonoBehaviour
{
    public Transform player;
    public Transform reStartPos;
    // Start is called before the first frame update
    void Start()
    {
        if (!reStartPos)
        {
            Debug.LogError("没有配置重新开始的位置");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //player = other.transform;
            StartCoroutine(PlayAgain());
        }
    }
    
    IEnumerator PlayAgain()
    {
        BasePanel fade = UIManager.Instance.OpenPanel(UIConst.FadePanel);
        FadeInOut _script = fade.gameObject.GetComponentInChildren<FadeInOut>();
        _script.StartFadeOut();
        yield return new WaitForSeconds(1f);
        player.GetComponent<CharacterController>().enabled = false;
        player.position = reStartPos.position;;
        player.GetComponent<CharacterController>().enabled = true;
        player.rotation = Quaternion.identity;
        yield return new WaitForSeconds(0.6f);
        _script.StartFadeIn();
        yield return new WaitForSeconds(1f);
        UIManager.Instance.ClosePanel(UIConst.FadePanel);
    }
    
}
