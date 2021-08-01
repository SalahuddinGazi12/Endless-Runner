using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gm : MonoBehaviour
{

    public static gm instance;
    public static float vertvel = 0;

    public static float timetotal = 0;
    public static float zVelAdj = 1;
    public float waittoload = 1;
    public static string lvlcompstatus = "";
   
    public GameObject restartber;
    public int scores;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }



    void Start()
    {

      


    }

    // Update is called once per frame
    void Update()
    {

    
    }


  

    public void RestartGame()
    {

        SceneManager.LoadScene("Game");
 
        Time.timeScale = 1;

    }

 
    
    
}

