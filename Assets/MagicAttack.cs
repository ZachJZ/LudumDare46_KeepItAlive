using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{

    int spells;
    int maxSpells;

    public Sprite Scope1;
    public Sprite Scope2;
    public Sprite Scope3;
    public Sprite Scope4;
    public Sprite Scope5;

    SpriteRenderer mySprite;


    public GameObject firePrefab;

    // Start is called before the first frame update
    void Start()
    {
        maxSpells = 4;
        spells = maxSpells;
        mySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
        {
            if (spells > 0)
            {
                //cast fire
                GameObject obj = (GameObject)Instantiate(firePrefab, gameObject.transform.position, gameObject.transform.rotation);
                spells--;
            }
            else
            {
                //display message to create more spells
            }
        }

        if (spells >= 4)
        {
            mySprite.sprite = Scope1;
        }
        else if (spells == 3)
        {
            mySprite.sprite = Scope2;
        }
        else if (spells == 2)
        {
            mySprite.sprite = Scope3;
        }
        else if (spells == 1)
        {
            mySprite.sprite = Scope4;
        }
        else if (spells <= 0)
        {
            mySprite.sprite = Scope5;
        }




    }
    public void AddSpell(int Add)
    {
        if (spells < maxSpells)
        {
            spells = Mathf.Clamp(spells + Add, 0, 4);
        }
    }
}
