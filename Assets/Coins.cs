using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public Text coinCount;

    public float coins;

    private void Update()
    {
        coinCount.text = coins.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        coinCount.GetComponent<Coins>().coins++;
        Destroy(gameObject);
    }
}
