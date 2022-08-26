using UnityEngine;

public class PickUp : BaseMoveForward
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
         var player = collision.GetComponent<Player>();

        if (player != null)
        {
            player.PowerUpWeapon();
            gameObject.SetActive(false);
        }


    }
}