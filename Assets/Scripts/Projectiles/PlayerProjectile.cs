using UnityEngine;

namespace Projectiles
{
    public class PlayerProjectile : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
                Destroy(gameObject);
        }
    }
}