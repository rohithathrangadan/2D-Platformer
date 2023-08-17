using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                //Debug.Log("Game Over");
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");//takes name parameter modified in AudioManager script component for the audioclip
                gameObject.SetActive(false);//disable player on gameOver
            }
            else
            {
                StartCoroutine(GetHurt());
            }

        }
    }
    IEnumerator GetHurt()
    {
        //disable collision for 3 secs
        Physics2D.IgnoreLayerCollision(6, 8);//Layer indices 6. Player 8. Enemy   
        GetComponent<Animator>().SetLayerWeight(1, 1); // get hurt base layer index 1, Weight 1

        yield return new WaitForSeconds(3);

        //enable collision
        GetComponent<Animator>().SetLayerWeight(1, 0); // get hurt base layer index 1, Weight 1
        Physics2D.IgnoreLayerCollision(6, 8, false);

    }
}
