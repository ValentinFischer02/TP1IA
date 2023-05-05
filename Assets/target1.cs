using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target1 : MonoBehaviour

{
    public LogicScript logic;
    public GameObject target;
    public AudioSource source;
    public AudioClip Clip;
    private float xrange=8;
    private float yrange=4;
    private float randx;
    private float randy;
    Vector3 myVector;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.addScore();
        source.PlayOneShot(Clip);
        randx = Random.Range(-xrange, xrange);
        randy = Random.Range(-yrange, yrange);
        myVector = new Vector3(randx, randy, 0);
        Instantiate(target, myVector, transform.rotation);
        Destroy(gameObject);
    }
}
