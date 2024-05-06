using UnityEngine;

namespace Projectiles
{
    public class EnemyProjectile : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                Destroy(gameObject);
        }
    }
}