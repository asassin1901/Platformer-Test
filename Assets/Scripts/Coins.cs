using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public Text coinCount;

    public float coins;

    Animator coinAnim = null;

    private void Awake()
    {
        coinAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        coinCount.text = coins.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
        coinAnim.SetTrigger("Pick");
        coinCount.GetComponent<Coins>().coins++;

        Invoke("Kill", 0.5f);
        }
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}
