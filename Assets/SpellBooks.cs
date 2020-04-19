using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBooks : MonoBehaviour
{

    private int Books;
    private int maxBooks;

    private MagicAttack thatMagic;

    // Start is called before the first frame update
    void Start()
    {
        Books = 2;
        thatMagic = FindObjectOfType<MagicAttack>().GetComponent<MagicAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D (Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerController>())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                thatMagic.AddSpell(4);

            }
        }
    }
}
