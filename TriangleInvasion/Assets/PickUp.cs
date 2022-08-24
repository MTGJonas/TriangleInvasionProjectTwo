using UnityEngine;

public class PickUp : BaseMoveForward
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
         var player = GetComponent<Player>();

        if(player != null)
            player.PowerUpWeapon();
    }
}