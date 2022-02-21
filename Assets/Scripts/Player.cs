using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Animator myAnimator = null;
    public CharacterController2D controller = null;
    Rigidbody2D myRigidbody;

    float horizontal = 0f;

    public float moveSpeed = 30f;
    public bool jump = false;
    public int healthPoints = 3;
    int maxHealth = 3;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Health();

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            myAnimator.SetBool("Jump", true);
        }

        myAnimator.SetFloat("Speed", Mathf.Abs(horizontal));

    }

    public void OnLanding()
    {
        myAnimator.SetBool("Jump", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontal * moveSpeed * Time.fixedDeltaTime, false, jump);

        jump = false;
    }

    public void DamageL()
    {
        myRigidbody.AddForce(new Vector2(-10f, 10f), ForceMode2D.Impulse);
        myAnimator.SetTrigger("Hit");
    }
    public void DamageR()
    {
        myRigidbody.AddForce(new Vector2(10f, 10f), ForceMode2D.Impulse);
        myAnimator.SetTrigger("Hit");
    }

    public void Health()
    {
        if (healthPoints <= 0)
        {
            myAnimator.SetBool("isDead", true);
            FindObjectOfType<GameManager>().GameOver();
        }

        if (healthPoints > maxHealth)
        {
            healthPoints = maxHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < healthPoints)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MainCamera")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
