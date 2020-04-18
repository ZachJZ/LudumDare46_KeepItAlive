using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float pSpeed = 5f;

    public Rigidbody2D rb;
    public Animator myAnim;

    Vector2 movement;
    Vector2 aim;
    Vector2 Mouse;

    public GameObject myAim;
    //float vert;
    //float hori;

        //HEALTH
    private int pHealth;
    private bool iFrames;
    private float iTimer;
    [SerializeField]
    private float iLimit;
    private float flashTimer;
    [SerializeField]
    private float flashLimit;
    public HealthCounter_Lab1 healthCounter;
    private List<HealthCounter_Lab1> HCInst;
    //private float difference;
    //public GameObject Begin;
    //public GameObject Target;






    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.lockState = CursorLockMode.None;
            //HEALTH
        pHealth = 5;
        //difference = Begin.GetComponent<RectTransform>().position.x - Target.GetComponent<RectTransform>().position.x;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerActions();

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        aim.x = Input.GetAxis("Mouse X");
        aim.y = Input.GetAxis("Mouse Y");

        MouseMath();

        myAnim.SetFloat("Speed", movement.sqrMagnitude);

            //HEALTH
        Invincibility();
        AimTracking();
    }

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * pSpeed * Time.fixedDeltaTime);
    }

    void PlayerActions()
    {
        //has magic
            //fire
            //lightning
            //ice

        //has weapon
            //axe
            //sword
            //spear
         
    }
    void AimTracking()
    {
        //    //Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        //    //Plane playerPlane = new Plane(Vector3.forward, transform.position);

        //https://www.youtube.com/watch?v=Geb_PnF1wOk
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        myAim.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void MouseMath()
    {

        Mouse.x = Mathf.Clamp(Mouse.x += aim.x, -1, 1);
        Mouse.y = Mathf.Clamp(Mouse.y += aim.y, -1, 1);

        myAnim.SetFloat("Vertical", Mouse.y);
        myAnim.SetFloat("Horizontal", Mouse.x);

    }

        //HEALTH
    public void DamagePlayer()
    {
        if (!iFrames)
        {
            pHealth--;

            iFrames = true;
            //play hurt sound
            //myDJ.playPlayerHurt();
            updateHealth(pHealth);

            if (pHealth <= 1)
            {
                //lose game
                print("You lost!");
                LoseGame();
                //deactivate player
                //deactivate hud
                //lose screen
                //main menu OR restart
            }
        }
    }
    public void HealPlayer()
    {
        if (pHealth < 5)
        {
            pHealth++;
            updateHealth(pHealth);
            //myDJ.playPickUp();
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
        print("Creating " + numHealth + " health");
        //Check to see if the list is empty
        if (HCInst == null)
        {
            //Creates a new list
            HCInst = new List<HealthCounter_Lab1>();
            HCInst.Add(healthCounter);
            //Sets the space between each new icon
//Vector3 positionOffSet = new Vector3(-difference, 0f, 0f);
            //print("PosOff " + positionOffSet);


            //
            for (int i = 1; i < numHealth; ++i)
            {

                //Sets the script to a usable variable
                HealthCounter_Lab1 newHealth;
                //Creates new healthCounter and sets position and rotation
                newHealth = Instantiate(healthCounter, healthCounter.transform.position, healthCounter.transform.rotation, FindObjectOfType<Canvas>().transform) as HealthCounter_Lab1;
                newHealth.GetComponent<RectTransform>().localScale = new Vector3(2, 2, 1);

                //Sets value of newPosition to where the first icon was created
                Vector3 newPosition = newHealth.transform.position;
                //Sets position based off of number of icons created
//newPosition.x += (positionOffSet.x * i);
                //Places icon at appropriate position
                newHealth.transform.position = newPosition;
                //Makes sure each new icon is in a uniform scale
                newHealth.transform.localScale = new Vector3(1f, 1f, 1f);

                //Adds counter to list
                HCInst.Add(newHealth);
            }
        }
    }
    public void updateHealth(int numHealth)
    {
        print(numHealth + " is numHealth");
        //Runs through a number of times equal to the size of the list
        for (int i = 0; i < HCInst.Count; i++)
        {
            //print("did the update hearts thing");
            //Sets active each icon that is to be used
            bool bActivate = i < numHealth;
            HCInst[i].gameObject.SetActive(bActivate);
            print(i + " is heart, and " + bActivate + " is its state");
        }
    }
    public void LoseGame()
    {
        Cursor.visible = true;
        //freezeMenu(true);
        //LoseScreen.SetActive(true);
        //myDJ.playSadChord();
    }


}
