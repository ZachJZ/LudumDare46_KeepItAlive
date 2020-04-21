using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerController myPlayer;
    public GameObject loseScreen;
    public GameObject winScreen;

    //HEALTH
    private int pHealth;
    private bool iFrames;
    private float iTimer;
    [SerializeField]
    private float iLimit;
    private float flashTimer;
    [SerializeField]
    private float flashLimit;

    int maxHealth;
    int curHealth;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;


    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<PlayerController>().gameObject.GetComponent<PlayerController>();
        //HEALTH
        pHealth = 5;
        maxHealth = 4;

        StartHealth();
        if (iLimit == 0)
        {
            iLimit = 2;
        }

        if (flashLimit == 0)
        {
            flashLimit = 0.2f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //HEALTH
        Invincibility();
        updateHealth();
        if (Input.GetKeyDown(KeyCode.H))
        {
            HurtHealth();
        }
    }

    //HEALTH
    void StartHealth()
    {
        curHealth = maxHealth;
    }
    public void HurtHealth()
    {
        if (!iFrames)
        {
            curHealth--;
            updateHealth();

            iFrames = true;
            //SOUND: Hurt
            if (curHealth <= 0)
            {
                print("You lost!");
                LoseGame();
            }
        }
    }
    public void HealHealth()
    {
        if (curHealth < maxHealth)
        {
            curHealth++;
            updateHealth();
            //myDJ.playPickUp();
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<SkeletonBrain>())
        {
            HurtHealth();
        }
    }
    public void Invincibility()
    {
        if (iFrames)
        {
            iTimer += Time.deltaTime;
            flashTimer += Time.deltaTime;

            if (flashTimer >= flashLimit)
            {
                if (GetComponent<SpriteRenderer>().enabled)
                {
                    GetComponent<SpriteRenderer>().enabled = false;
                    flashTimer = 0;
                }
                else if (!GetComponent<SpriteRenderer>().enabled)
                {
                    GetComponent<SpriteRenderer>().enabled = true;
                    flashTimer = 0;
                }
            }

            if (iTimer >= iLimit)
            {
                print("iTimer running");
                GetComponent<SpriteRenderer>().enabled = true;
                iFrames = false;
                iTimer = 0;
            }
        }
    }
    public void CreateHealthIcons(int numHealth)
    {
        ////Check to see if the list is empty
        //if (HCInst == null)
        //{
        //    //Creates a new list
        //    HCInst = new List<HealthCounter_Lab1>();
        //    HCInst.Add(healthCounter);
        //    //Sets the space between each new icon
        //    //Vector3 positionOffSet = new Vector3(-difference, 0f, 0f);
        //    //print("PosOff " + positionOffSet);


        //    ////
        //    //for (int i = 1; i < numHealth; ++i)
        //    //{

        //    //    //Sets the script to a usable variable
        //    //    HealthCounter_Lab1 newHealth;
        //    //    //Creates new healthCounter and sets position and rotation
        //    //    newHealth = Instantiate(healthCounter, healthCounter.transform.position, healthCounter.transform.rotation, FindObjectOfType<Canvas>().transform) as HealthCounter_Lab1;
        //    //    newHealth.GetComponent<RectTransform>().localScale = new Vector3(2, 2, 1);

        //    //    //Sets value of newPosition to where the first icon was created
        //    //    Vector3 newPosition = newHealth.transform.position;
        //    //    //Sets position based off of number of icons created
        //    //    //newPosition.x += (positionOffSet.x * i);
        //    //    //Places icon at appropriate position
        //    //    newHealth.transform.position = newPosition;
        //    //    //Makes sure each new icon is in a uniform scale
        //    //    newHealth.transform.localScale = new Vector3(1f, 1f, 1f);

        //    //    //Adds counter to list
        //    //    HCInst.Add(newHealth);
        //    //}
        //}
    }
    public void updateHealth()
    {
        if (curHealth >= 4)
        {
            heart4.SetActive(true);
            heart3.SetActive(true);
            heart2.SetActive(true);
            heart1.SetActive(true);
        }
        else if(curHealth == 3)
        {
            heart4.SetActive(false);
            heart3.SetActive(true);
            heart2.SetActive(true);
            heart1.SetActive(true);
        }
        else if(curHealth == 2)
        {
            heart4.SetActive(false);
            heart3.SetActive(false);
            heart2.SetActive(true);
            heart1.SetActive(true);
        }
        else if (curHealth == 1)
        {
            heart4.SetActive(false);
            heart3.SetActive(false);
            heart2.SetActive(false);
            heart1.SetActive(true);
        }
        else if (curHealth <= 0)
        {
            heart4.SetActive(false);
            heart3.SetActive(false);
            heart2.SetActive(false);
            heart1.SetActive(false);
        }





    }

    public void WinGame()
    {
        Cursor.visible = true;
        myPlayer.SetPlaying(false);
        StartCoroutine(ScaleTime(1.0f, 0.0f, 3.0f));
        myPlayer.pauseMenu.SetActive(true);
        winScreen.SetActive(true);

    }
    public void LoseGame()
    {
        Cursor.visible = true;
        myPlayer.SetPlaying(false);
        StartCoroutine(ScaleTime(1.0f, 0.0f, 3.0f));
        myPlayer.pauseMenu.SetActive(true);
        loseScreen.SetActive(true);
    }

    IEnumerator ScaleTime(float start, float end, float time)
    {
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        while (timer < time)
        {
            Time.timeScale = Mathf.Lerp(start, end, timer / time);
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }
        Time.timeScale = end;
    }


}
