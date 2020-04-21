using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{

    private bool iFrames;
    private float iTimer;
    [SerializeField]
    private float iLimit;
    private float flashTimer;
    [SerializeField]
    private float flashLimit;

    public int SummonHealth;

    private PlayerHealth lookGame;

    public GameObject candle1;
    public GameObject candle2;
    public GameObject candle3;
    public GameObject candle4;
    public GameObject candle5;
    public GameObject candle6;
    public GameObject candle7;
    public GameObject candle8;

    // Start is called before the first frame update
    void Start()
    {
        lookGame = FindObjectOfType<PlayerHealth>();
        SummonHealth = 8;

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
        Invincibility();
        
        updateCandles(SummonHealth);
        print(SummonHealth);
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<SkeletonBrain>())
        {
            iFrames = true;
            SummonHealth--;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<SkeletonBrain>())
            Destroy(col.gameObject);
    }
    void updateCandles(int candleNum)
    {
        if (candleNum == 8)
        {
            candle1.SetActive(true);
            candle2.SetActive(true);
            candle3.SetActive(true);
            candle4.SetActive(true);
            candle5.SetActive(true);
            candle6.SetActive(true);
            candle7.SetActive(true);
            candle8.SetActive(true);
        }
        else if (candleNum == 7)
        {
            candle1.SetActive(true);
            candle2.SetActive(true);
            candle3.SetActive(true);
            candle4.SetActive(true);
            candle5.SetActive(true);
            candle6.SetActive(true);
            candle7.SetActive(true);
            candle8.SetActive(false);
        }
        else if (candleNum == 6)
        {
            candle1.SetActive(true);
            candle2.SetActive(true);
            candle3.SetActive(true);
            candle4.SetActive(true);
            candle5.SetActive(true);
            candle6.SetActive(true);
            candle7.SetActive(false);
            candle8.SetActive(false);
        }
        else if (candleNum == 6)
        {
            candle1.SetActive(true);
            candle2.SetActive(true);
            candle3.SetActive(true);
            candle4.SetActive(true);
            candle5.SetActive(true);
            candle6.SetActive(true);
            candle7.SetActive(false);
            candle8.SetActive(false);
        }
        else if (candleNum == 5)
        {
            candle1.SetActive(true);
            candle2.SetActive(true);
            candle3.SetActive(true);
            candle4.SetActive(true);
            candle5.SetActive(true);
            candle6.SetActive(false);
            candle7.SetActive(false);
            candle8.SetActive(false);
        }
        else if (candleNum == 4)
        {
            candle1.SetActive(true);
            candle2.SetActive(true);
            candle3.SetActive(true);
            candle4.SetActive(true);
            candle5.SetActive(false);
            candle6.SetActive(false);
            candle7.SetActive(false);
            candle8.SetActive(false);
        }
        else if (candleNum == 3)
        {
            candle1.SetActive(true);
            candle2.SetActive(true);
            candle3.SetActive(true);
            candle4.SetActive(false);
            candle5.SetActive(false);
            candle6.SetActive(false);
            candle7.SetActive(false);
            candle8.SetActive(false);
        }
        else if (candleNum == 2)
        {
            candle1.SetActive(true);
            candle2.SetActive(true);
            candle3.SetActive(false);
            candle4.SetActive(false);
            candle5.SetActive(false);
            candle6.SetActive(false);
            candle7.SetActive(false);
            candle8.SetActive(false);
        }
        else if (candleNum == 1)
        {
            candle1.SetActive(true);
            candle2.SetActive(false);
            candle3.SetActive(false);
            candle4.SetActive(false);
            candle5.SetActive(false);
            candle6.SetActive(false);
            candle7.SetActive(false);
            candle8.SetActive(false);
        }
        else if (candleNum <= 0)
        {
            candle1.SetActive(false);
            candle2.SetActive(false);
            candle3.SetActive(false);
            candle4.SetActive(false);
            candle5.SetActive(false);
            candle6.SetActive(false);
            candle7.SetActive(false);
            candle8.SetActive(false);

            //lose  
            lookGame.LoseGame();
        }
    }
}
