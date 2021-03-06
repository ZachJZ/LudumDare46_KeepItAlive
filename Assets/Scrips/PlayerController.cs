﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool gaming;
    bool pausedGame;
    public GameObject pauseMenu;

    public float pSpeed = 5f;

    public Rigidbody2D rb;
    public Animator myAnim;

    Vector2 movement;
    Vector2 aim;
    Vector2 Mouse;

    public GameObject myAim;
    //float vert;
    //float hori;

    // Start is called before the first frame update
    void Start()
    {
        gaming = true;
        pausedGame = true;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerActions();
    }

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * pSpeed * Time.fixedDeltaTime);
    }

    void PlayerActions()
    {
        if (gaming)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            aim.x = Input.GetAxis("Mouse X");
            aim.y = Input.GetAxis("Mouse Y");

            MouseMath();

            myAnim.SetFloat("Speed", movement.sqrMagnitude);

            AimTracking();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pausedGame = !pausedGame;
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        if (pausedGame)
        {
            //unpause
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            pausedGame = true;
        }
        else
        {
            //pause 
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
            pausedGame = false;
        }
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

    public void SetPlaying(bool gameOver)
    {
        gaming = gameOver;
    }


}
