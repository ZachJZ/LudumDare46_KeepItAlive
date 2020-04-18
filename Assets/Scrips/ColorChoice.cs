using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorChoice : MonoBehaviour
{

    public Color myNecroColor;
    public Color myMagicColor;

    private bool magicActive;

    public string Label;
    public Text Title;
    public Image TitleButton;

    public Material Mat_Necromancer;
    public Material Mat_Magic;


    public Button myButton;
    public Slider sRed, sGreen, sBlue;

    public float red, green, blue;

    // Start is called before the first frame update
    void Start()
    {
        green = 1;

    }

    // Update is called once per frame
    void Update()
    {
        red = sRed.value;
        green = sGreen.value;
        blue = sBlue.value;

        if (magicActive)
        {
            Label = "Color of Magic";
            Title.text = Label;

            //TitleButton.material = Mat_Magic;
            myMagicColor = new Color(red, green, blue);
            myButton.GetComponent<Image>().color = myMagicColor;
        }
        else
        {
            Label = "Color of You";
            Title.text = Label;

            //TitleButton.material = Mat_Necromancer;
            myNecroColor = new Color(red, green, blue);
            myButton.GetComponent<Image>().color = myNecroColor;
        }
    }

    public void Toggle()
    {
        if (magicActive)
        {
            TitleButton.color = Mat_Necromancer.color;
            magicActive = false;

        }
        else
        {
            TitleButton.color = Mat_Magic.color;
            magicActive = true;
        }

    }

    public Color getMyNecroColor()
    {
        return myNecroColor;
    }

    public Color getMyMagicColor()
    {
        return myMagicColor;
    }

    public void SetColor()
    {
        if (magicActive)
        {
            Mat_Magic.color = myMagicColor;
            TitleButton.color = Mat_Magic.color;


        }
        if (!magicActive)
        {
            Mat_Necromancer.color = myNecroColor;
            TitleButton.color = Mat_Necromancer.color;

        }
    }
}
