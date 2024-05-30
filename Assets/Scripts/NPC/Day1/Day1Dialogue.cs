using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*普通或可以直接触发接触trigger的对话代码*/
public class Day1Dialogue : NpcDialogue
{
    public override void AfterEndDialog() 
    {
        if (NextLevelTrigger)
        {
            NextLevelTrigger.SetActive(true);
            player.canNext = true;
        }
        base.AfterEndDialog();
    }
}
