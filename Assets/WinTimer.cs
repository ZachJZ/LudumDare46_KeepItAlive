using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTimer : MonoBehaviour
{

    public float TimeToWin;
    public float MaxTimeToWin = 120f;

    private PlayerController myPlayer;
    private PlayerHealth myHealth;

    public float displayPerc;

    public Slider mySlider;

    // Start is called before the first frame update
    void Start()
    {

        myHealth = FindObjectOfType<PlayerHealth>();
        TimeToWin = 0f;

        print("Im here");
    }

    // Update is called once per frame
    void Update()
    {
        TimeToWin += Time.deltaTime; 

        if (TimeToWin >= MaxTimeToWin)
        {
            Win();
        }

        displayPerc = TimeToWin / MaxTimeToWin;

        mySlider.value = displayPerc;
    }

    void Win()
    {
        myHealth.WinGame();
    }
}
