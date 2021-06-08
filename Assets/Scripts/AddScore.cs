using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    public int coins = 0;
    public Text coinsText;

    void Start()
    {
        //coinsText = GameObject.FindGameObjectsWithTag("CoinText")[0].GetComponent<Text>();
        coinsText.text = "0";
      
    }

/*    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Sword"))
        {

            coins++;
            coinsText.text = ""+coins;
        }
    }*/
}
