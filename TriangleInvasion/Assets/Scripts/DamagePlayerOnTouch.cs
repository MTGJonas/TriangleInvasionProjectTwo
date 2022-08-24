using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOnTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        var player = col.collider.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage();
        }
    }
}