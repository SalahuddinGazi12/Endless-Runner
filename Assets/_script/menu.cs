using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
    public static menu instance;
    //public GameObject Menupanel;
    //public GameObject soundbutton;
    public GameObject playpanel;
    //public GameObject hapanel;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playbutton()
    {

        if (Time.timeScale == 1) 
        {
            
            SceneManager.LoadScene("Game");
        }
        else
        {
            Time.timeScale = 1;
            //Menupanel.SetActive(false);
            playpanel.SetActive(false);
            //hapanel.SetActive(false);
        }
  

    }

    public void settings()
    {
        
    }
}
