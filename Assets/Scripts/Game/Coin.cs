using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerManager.numberOfCoins++;//increment coin
            PlayerPrefs.SetInt("NumberOfCoins",PlayerManager.numberOfCoins); //update the value under key:NumberOfCoins whenever coin collision triggered
            AudioManager.instance.Play("Coins");
            Destroy(gameObject);//destroy coin
        }
    }
}
