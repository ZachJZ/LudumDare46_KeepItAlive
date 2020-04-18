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
    //float vert;
    //float hori;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerActions();
        //PlayerAiming();

        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        aim.x = Input.GetAxis("Mouse X");
        //aim.y = Input.GetAxis("Mouse Y");
        aim.y = Input.GetAxis("Mouse Y");

        MouseMath();


        myAnim.SetFloat("Speed", movement.sqrMagnitude);


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

    void MouseMath()
    {

        Mouse.x = Mathf.Clamp(Mouse.x += aim.x, -1, 1);
        Mouse.y = Mathf.Clamp(Mouse.y += aim.y, -1, 1);

        myAnim.SetFloat("Vertical", Mouse.y);
        myAnim.SetFloat("Horizontal", Mouse.x);

    }

    //void PlayerAiming()
    //{

    //    //Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
    //    //Plane playerPlane = new Plane(Vector3.forward, transform.position);

    //    //https://www.youtube.com/watch?v=Geb_PnF1wOk
    //    Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
    //    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //    //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    //    print(dir);

    //    if (dir.x > 0 && dir.y > 0) //rights //top right //positives
    //    {
    //        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
    //        {
    //            //right
    //            hori = 1;
    //            myAnim.SetFloat("Horizontal", hori);
    //        }
    //        else
    //        {
    //            //up
    //            vert = 1;
    //            myAnim.SetFloat("Vertical", vert);
    //        }
    //    }
    //    else if (dir.x < 0 && dir.y > 0) //outs //top left
    //    {
    //        //print("top left");
    //        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
    //        {
    //            //left
    //            hori = -1;
    //                //Mathf.Clamp((Mathf.Abs(dir.x)), -1, 1);
    //            //print("went left");
    //            myAnim.SetFloat("Horizontal", hori);
    //        }
    //        else
    //        {
    //            //up
    //            vert = 1;
    //            //print("went top ");
    //            myAnim.SetFloat("Vertical", vert);
    //        }
    //    }
    //    else if (dir.x < 0 && dir.y < 0) //lefts //bottom left //negatives
    //    {
    //        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
    //        {
    //            //left
    //            hori = -1;
    //            myAnim.SetFloat("Horizontal", hori);
    //        }
    //        else
    //        {
    //            //down
    //            vert = -1;
    //            myAnim.SetFloat("Vertical", vert);
    //        }
    //    }
    //    else if (dir.x > 0 && dir.y < 0) //ins //bottom right
    //    {
    //        print("down right");
    //        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
    //        {
    //            //right
    //            hori = 1;
    //            print("went right");
    //            myAnim.SetFloat("Horizontal", hori);
    //        }
    //        else
    //        {
    //            //down
    //            vert = -1;
    //            print("went down");
    //            myAnim.SetFloat("Vertical", vert);
    //        }
    //    }


    //    //https://forum.unity.com/threads/rotate-to-direction-based-on-mouse-position.606943/
    //    //if (Mathf.Abs(vec.y) > Mathf.Abs(vec.x))
    //    //{
    //    //    // Vertical
    //    //    if (vec.y > 0) direction = Dir.Up;
    //    //    if (vec.y < 0) direction = Dir.Down;
    //    //}
    //    //else
    //    //{
    //    //    // Horizontal
    //    //    if (vec.x > 0) direction = Dir.Right;
    //    //    if (vec.x < 0) direction = Dir.Left;
    //    //}

    //    ////player points to where the mouse is
    //    //Plane playerPlane = new Plane(Vector3.up, transform.position);
    //    //Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);

    //    //float hitDist = 0.0f;

    //    //if (playerPlane.Raycast(ray, out hitDist))
    //    //{
    //    //    Vector3 targetpoint = ray.GetPoint(hitDist);
    //    //    Quaternion targetRotation = Quaternion.LookRotation(targetpoint - transform.position);
    //    //    targetRotation.x = 0;
    //    //    targetRotation.z = 0;
    //    //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
    //    //}
    //}


}
