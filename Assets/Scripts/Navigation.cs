using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    public GameObject patrolPoint1;
    public GameObject patrolPoint2;
    Component testScript;

    public float speed = 10f;
    float damage;

    bool movingRight = true;
    bool run = false;

    Animator myAnimator = null;

    int horizontal = 0;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(patrolPoint1 != null && patrolPoint2 != null)
        {
            run = true;
        }
        else
        {
            run = false;
            horizontal = 0;
        }

        if (run)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            horizontal = 1;
        }

        myAnimator.SetInteger("Speed", Mathf.Abs(horizontal));
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        damage = collision.gameObject.transform.position.x - transform.position.x;
        //Debug.Log("Hit");
        if (movingRight && collision.gameObject.tag == "GameController")
        {
            //Debug.Log("Turn 1");
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }
        else if(movingRight == false && collision.gameObject.tag == "GameController")
        {
            //Debug.Log("Turn 2");
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
        //Because I am unsure if I can simply get Player as a component through any other reasonable means and I'm running out of time
        if (collision.gameObject.tag == "Player" && damage <= 0)
        {
            FindObjectOfType<Player>().healthPoints --;
            FindObjectOfType<Player>().DamageL();
        } else if(collision.gameObject.tag == "Player" && damage >= 0)
        {
          FindObjectOfType<Player>().healthPoints --;
          FindObjectOfType<Player>().DamageR();
        }
    }

}
