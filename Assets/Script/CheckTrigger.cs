using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Coin ??
        if (other.gameObject.tag == "Coin")
        {
            GameManager.Instance.AddScore();
            Destroy(other.gameObject, 0.02f);
        }

        // Walls
        if (other.gameObject.tag == "Wall")
        {
            GameManager.Instance.GameOver();
        }
    }
}
