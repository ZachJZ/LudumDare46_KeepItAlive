using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBooks : MonoBehaviour
{

    private int Books;
    private int maxBooks;

    private MagicAttack thatMagic;

    public GameObject book1;
    public GameObject book2;


    // Start is called before the first frame update
    void Start()
    {
        maxBooks = 2;
        Books = maxBooks;
        thatMagic = FindObjectOfType<MagicAttack>().GetComponent<MagicAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        checkBooks();
    }

    void checkBooks()
    {
        if (Books >= 2)
        {
            book1.SetActive(true);
            book2.SetActive(true);
        }
        else if (Books == 1)
        {
            book1.SetActive(true);
            book2.SetActive(false);
        }
        else if (Books <= 0)
        {
            book1.SetActive(false);
            book2.SetActive(false);
        }
    }

    public void addBooks(int add)
    {
        Books = Mathf.Clamp(Books += add, 0, 2);
    }

    void OnTriggerStay2D (Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerController>())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Books > 0 && thatMagic.getSpells() < 4)
                {
                    print("did it 1 time");
                    Books--;
                    thatMagic.AddSpell(4);
                }
                else
                {

                    //message to get more magic
                }
            }
        }
    }
}
