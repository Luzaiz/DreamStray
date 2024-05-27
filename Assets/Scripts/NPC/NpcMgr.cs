using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class NpcMgr : MonoBehaviour
{
    public Sprite npcImg;
    public string npcName;
    public string[] contentList;
    public CinemachineVirtualCameraBase switchToCam; 
    public PlayerMgr player;
    public GameObject tipsCanvas;
}
