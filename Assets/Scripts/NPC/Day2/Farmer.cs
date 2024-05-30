using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    public bool isStartGame=false;
    public GameObject day2Panel;
    private GameObject diaTrigger;
    private bool hasExecuted = false;
    // Start is called before the first frame update
    void Start()
    {
        diaTrigger = transform.Find("DiaTrigger").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasExecuted &&　!diaTrigger.activeSelf)
        {
            isStartGame = true;
            day2Panel.GetComponent<Day2Panel>().countLabel.gameObject.SetActive(true);
            hasExecuted = true;
        }
    }
}
