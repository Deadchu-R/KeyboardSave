using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;

public class AngryGameManager : MonoBehaviour
{
    bool win = false;
    bool lost = false;
    public GameObject[] birds;
    public List<Animator> animList;
    public GameObject[] turrets;
    public List<GameObject> enemyList;

    private void Start()
    {
        birds = GameObject.FindGameObjectsWithTag("bird");
        for (int i = 0; i < birds.Length; i++)
        {
            animList.Add(birds[i].GetComponent<Animator>());
        }
 

        turrets = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < turrets.Length; i++)
        {
            enemyList.Add(turrets[i].GetComponent<GameObject>());
        }
  
    }

    void Update()
    {
   
            if (birds.All(birds => birds.activeSelf == false)) // if all birds are not active set lost to true
            {
                lost = true;
            }
     
            if (turrets.All(turrets => turrets == null )) // if all birds are not active set lost to true
            {
                win = true;
            }
    
        if (birds[0].activeSelf == false)
        {
            animList[1].SetBool("isDead", true);
        }
        if (birds[1].activeSelf == false)
        {
            animList[2].SetBool("isDead", true);
        }

        if (win == true)
        {
            SceneManager.LoadScene("AngryWin");
        }
        if (lost == true)
        {
            SceneManager.LoadScene("AngryLose");
        }

    }

}

