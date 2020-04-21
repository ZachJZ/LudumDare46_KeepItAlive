using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMagic : MonoBehaviour
{
    public float timer;
    public float maxTime;

    public GameObject LoadingBar;

    private SpellBooks thatBooks;

    bool Going;


    // Start is called before the first frame update
    void Start()
    {
        Going = false;
        thatBooks = FindObjectOfType<SpellBooks>().GetComponent<SpellBooks>();
        if (maxTime == 0)
        {
            maxTime = 5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartTimer();
    }

    void StartTimer()
    {
        if (Going)
        {
            timer += Time.deltaTime;

            LoadingBar.transform.localScale = new Vector3((timer / maxTime), LoadingBar.transform.localScale.y, LoadingBar.transform.localScale.z);

            if (timer >= maxTime)
            {
                thatBooks.addBooks(2);
                timer = 0;
                Going = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerController>())
        {
            print("PLayer is in magic");
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("pressed e");
                Going = true;
            }
        }
    }

}
