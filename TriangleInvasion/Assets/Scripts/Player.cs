using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] Weapon _weapon;
    public void TakeDamage()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetButton("Jump"))
        {
            _weapon.TryFire();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var iTakeDamage = collision.collider.GetComponent<ITakeDamage>();
        if(iTakeDamage != null)
        {
            iTakeDamage.TakeDamage();
        }
    }
}