using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum Swipe { None, Up, Down, Left, Right };
public class moveplayuer : MonoBehaviour
{
   // public static moveplayuer instance = null;



    public KeyCode movel;
    public KeyCode mover;
    public float horizvel = 0 ;
    public int laneline = 2;
    public string controllocked = "n";
   
    public bool player;
  
    public GameObject restartber;
    public GameObject manager;
    public bool gamePause;
 
public Text scoreText;

    private Vector3 screenPoint;
    private Vector3 offset;
   


    public GameObject road;


    public GameObject[] enemyPrefabs;

    public float spawnTime;

    public Material material;
    //public Text high_score_text;
    
   public Text yourScoreText;

    public bool isPlay;
    public GameObject scorepanel;
    public GameObject colorchangeway;
    public int colorrand;
    void Start()
    {
        InvokeRepeating("colorrchangeway", 5f, 10f);
        spawnTime = 2f;
        StartCoroutine(spawnEnemy());
    }
    private void FixedUpdate()
    {

    }




    void Update()
    {




        player = true;

        GetComponent<Rigidbody>().velocity = new Vector3(horizvel, gm.vertvel, 4);
        Debug.Log(gameObject.tag);

        scoreText.text = "" + gm.instance.scores;
        //high_score_text.text = "" + PlayerPrefs.GetInt("HighScore");
        yourScoreText.text = ""+ gm.instance.scores;

    }

    private void OnCollisionEnter(Collision other)
    {

        
        if(gameObject.tag=="player1" && other.gameObject.tag == "enmey1" || gameObject.tag == "player2" && other.gameObject.tag == "enemy2" || gameObject.tag == "player3" && other.gameObject.tag == "enemy3" || gameObject.tag == "player4" && other.gameObject.tag == "enemy4" || gameObject.tag == "player5" && other.gameObject.tag == "enemy5")
        {
            Destroy(other.gameObject);
            gm.instance.scores += 1;

        }
        else
        {
       
            ////if (gm.instance.scores > PlayerPrefs.GetInt("HighScore")){
            ////    PlayerPrefs.SetInt("HighScore", gm.instance.scores);
            //}
            Destroy(gameObject);
            scorepanel.SetActive(false);
            Time.timeScale = 0;
            restartber.SetActive(true);

        }
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "roadTrigger")
        {
            Instantiate(road, new Vector3(-0.1f, -2f, transform.position.z + 50f), Quaternion.identity);
        }
       
    }


    IEnumerator stopslide()
    {
        yield return new WaitForSeconds(.5f);
        horizvel = 0;
        controllocked = "n";
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, screenPoint.z));
    }

    void OnMouseDrag()
    {
        if (isPlay)
        {
            Vector3 mousePos = Input.mousePosition;
            float mouseXPos = mousePos.x;




            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, 0, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            transform.position = cursorPosition;
          
        }
    }


    IEnumerator spawnEnemy()
    {
        float randomXpos = Random.Range(-0.7f, 0.6f);
        int randomindex = Random.Range(0, 5);
       GameObject enemy =  Instantiate(enemyPrefabs[randomindex], new Vector3(randomXpos, 3.255f, transform.position.z + 5f), Quaternion.Euler(0, 90, 0));
        enemy.name = "Enemy";
        if (gm.instance.scores < 5)
        {
            spawnTime = 1.5f;

            
            RenderSettings.skybox = skybox.instance.skyboxchange[0];
        }

        if (gm.instance.scores > 5)
        {
           // randcolor.instance.colorChange = false;
            spawnTime = 1f;
            //material.color = randcolor.instance.playerColor[1];
            //randcolor.instance.playerTag = "player2";
           
           RenderSettings.skybox = skybox.instance.skyboxchange[1];
        } 
        if (10 < gm.instance.scores  && gm.instance.scores <= 20)
            {
            //material.color = randcolor.instance.playerColor[2];
            //randcolor.instance.playerTag = "player3";
            spawnTime = 0.9f;
            RenderSettings.skybox = skybox.instance.skyboxchange[2];

        }
            if (20 < gm.instance.scores   && gm.instance.scores <= 50)
            {
           //material.color = randcolor.instance.playerColor[3];
           // randcolor.instance.playerTag = "player4";
            spawnTime = 0.8f;
            RenderSettings.skybox = skybox.instance.skyboxchange[3];

        }
            if (50  < gm.instance.scores  && gm.instance.scores <= 100)
            {
            //material.color = randcolor.instance.playerColor[4];
            //randcolor.instance.playerTag = "player5";
            spawnTime = 0.7f;

            RenderSettings.skybox = skybox.instance.skyboxchange[4];
        }
        if (100 < gm.instance.scores && gm.instance.scores <= 1000)
        {
            //material.color = randcolor.instance.playerColor[0];
            //randcolor.instance.playerTag = "player1";
            spawnTime = 0.6f;
            RenderSettings.skybox = skybox.instance.skyboxchange[2];

        }
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(spawnEnemy());
    }

    public void playBtnClick()
    {
        isPlay = true;
    }
 public void colorrchangeway()
    {
        Instantiate(colorchangeway, new Vector3(-0.108f, 4.38f,transform.position.z+10f),Quaternion.Euler(0, 0, 0));
      
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "colorchangeway")
        {

            int colorFIndex = Random.Range(0, 5);

            if(colorFIndex == 0)
            {
                randcolor.instance.color0();
            }
            else if(colorFIndex == 1)
            {
                randcolor.instance.color1();
            }
            else if (colorFIndex == 2)
            {
                randcolor.instance.color2();

            }
            else if (colorFIndex == 3)
            {
                randcolor.instance.color3();
            }
            else if (colorFIndex == 4)
            {
                randcolor.instance.color4();

            }
            else
            {
                randcolor.instance.color1();
            }

           
            
        }


    }


}