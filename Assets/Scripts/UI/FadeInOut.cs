using System.Collections;  
using UnityEngine;  
using UnityEngine.UI;
  
public class FadeInOut : BasePanel  
{  
    public Image fadeImage; // 在Inspector中分配这个Image组件  
    public float fadeDurationTime = 1.0f; // 淡入淡出持续时间  
  
    private bool isFadingOut = false; // 是否正在淡出  
  
    // 开始淡出（黑屏）  
    public void StartFadeOut()  
    {  
        StartCoroutine(Fade(1f, () => isFadingOut = true));  
    }  
  
    // 开始淡入（显示内容）  
    public void StartFadeIn()  
    {  
        StartCoroutine(Fade(0f, () => isFadingOut = false));  
    }  
  
    // 淡入淡出协程  
    private IEnumerator Fade(float targetAlpha, System.Action onComplete)  
    {  
        float startAlpha = fadeImage.color.a;  
        float lerpT = 0f;  
  
        while (lerpT < 1f)  
        {  
            lerpT += Time.deltaTime / fadeDurationTime;  
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.Lerp(startAlpha, targetAlpha, lerpT));  
  
            yield return null;  
        }
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, targetAlpha);
        onComplete?.Invoke(); // 调用完成回调  
    }  
}