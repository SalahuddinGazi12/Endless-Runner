using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randcolor : MonoBehaviour
{
    public static randcolor instance = null;
    public Color[] playerColor;
    public GameObject player;
    public int randomColor;

    public Material material;

    public int colorIndex;

    public string playerTag;

    public bool colorChange = false;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTag = "player1";
        colorIndex = 0;
        material.color = playerColor[colorIndex];
    }

    // Update is called once per frame
    void Update()
    {
        

        Debug.Log(colorIndex);
        if (player != null)
        {
            player.tag = playerTag;
        }

    }

    public void PlayercolorChange()
    {

        if (player != null)
        {
            randomColor = Random.Range(0, 5);
           material.color = playerColor[randomColor];
        }

    }

    public void color0()
    {
        colorChange = true;
        colorIndex = 0;
        material.color = playerColor[colorIndex];
        playerTag = "player1";

    }
    public void color1()
    {
        colorChange = true;
        colorIndex = 1;
        material.color = playerColor[colorIndex];
        playerTag = "player2";
    }

    public void color2()
    {
        colorChange = true;
        colorIndex = 2;
        material.color = playerColor[colorIndex];
        playerTag = "player3";
    }

    public void color3()
    {
        colorChange = true;
        colorIndex = 3;
        material.color = playerColor[colorIndex];
        playerTag = "player4";
    }

    public void color4()
    {
        colorChange = true;
        colorIndex = 4;
        material.color = playerColor[colorIndex];
        playerTag = "player5";
    }


}
