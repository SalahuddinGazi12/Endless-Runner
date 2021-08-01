using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skybox : MonoBehaviour
{
    public static skybox instance;
    public Material[] skyboxchange;
    public int skyclr;

    private void Awake()
    {
        if (instance == null)
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
    public void changeskybox() { 
    
       skyclr = Random.Range(0, 5);
       RenderSettings.skybox = skyboxchange[skyclr];
    }
}
