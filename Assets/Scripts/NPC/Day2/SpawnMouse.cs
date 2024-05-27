using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMouse : MonoBehaviour
{
    public Farmer farmer;
    public Transform spawnPosParent; //生成点父物体
    public GameObject mousePrefabs;
    private float timeVal = 5f;
    private float _timer;
    
    [SerializeField]private List<GameObject> enemyList = new List<GameObject>();

    void Start()
    {

    }
    
    void Update()
    {
        if (farmer.isStartGame)
        {
            _timer += Time.deltaTime;
            InstMice();
        }
        else
        {
            DestoryMice();
        }
    }

    private void InstMice()
    {
        if (_timer >= timeVal)
        {
            int randomIndex = -1;
            randomIndex = Random.Range(0, spawnPosParent.childCount); 
            GameObject obj = Instantiate(mousePrefabs, spawnPosParent.GetChild(randomIndex).position, Quaternion.identity);
            enemyList.Add(obj);
            _timer = 0;
        }
    }

    private void DestoryMice()
    {
        if (enemyList != null && enemyList.Count > 0)
        {
            //从后往前遍历列表，因为删除元素会改变索引
            for (int i = enemyList.Count - 1; i >= 0; i--)  
            {  
                Destroy(enemyList[i]);
                enemyList.RemoveAt(i);  //删除引用
            }  
            // enemyList.Clear();   
        }
        else
        {
            return;
        }
    }
    
    public void DeleteGameObject(GameObject go)  
    {    
        if (enemyList.Contains(go))  
        {  
            Destroy(go);
            enemyList.Remove(go);  
        }  
    }  
}