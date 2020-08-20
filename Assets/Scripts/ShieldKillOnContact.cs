using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldKillOnContact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!GameManager.instance.player.shieldOn)
                collision.GetComponent<PlayerController>().GameOver();
        }
    }
}
