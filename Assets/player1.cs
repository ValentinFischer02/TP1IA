using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    private float rotZ;
    public SpriteRenderer sprite;
    public float rotationSpeed;
    public Rigidbody2D Rigidbody;
    public float Speed;
    private int flag1=0;
    public bool PlayerAlive = true;
    public LogicScript logic;
    public AudioSource Source;
    public AudioClip Clip;
    private bool Clockwise;


    void Start()
    {
        sprite.color = new Color(0, 1, 0);
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
        Physics2D.autoSimulation = true;
        Clockwise = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag1 == 0)
        {
            if(Clockwise == true){rotZ += -Time.deltaTime * rotationSpeed;}
            else{rotZ += +Time.deltaTime * rotationSpeed;}
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
        
        if (Input.GetKeyDown(KeyCode.Space)&&flag1==0&&PlayerAlive==true)
        { Rigidbody.velocity = transform.up * Speed;
            sprite.color = new Color(1, 0, 0);
            flag1 = 1;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody.velocity = Vector3.zero;
        sprite.color = new Color(0, 1, 0);
        flag1 = 0;
        if(Clockwise == true){Clockwise = false;}
        else{Clockwise = true;}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        Rigidbody.velocity = Vector3.zero;
        flag1 = 1;
        Physics2D.autoSimulation = false;
        Source.PlayOneShot(Clip);
        PlayerAlive = false;

    }
}

