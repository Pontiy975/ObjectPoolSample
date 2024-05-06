using Projectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Animator explosion;
        [SerializeField] private GameObject body;
        [SerializeField] private float attackCooldown;
        [SerializeField] private EnemyProjectile projectilePrefab;
        [SerializeField] private List<string> collisionTags;

        private Transform _transform;
        private bool _isDead;

        private float _attackTimer;

        private static readonly int _explosionHash = Animator.StringToHash("Explosion");

        private void Start()
        {
            _transform = transform;
            _attackTimer = attackCooldown;
        }

        private void Update()
        {
            UpdateAttackTimer();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collisionTags.Contains(collision.tag))
                Death();
        }

        private void Attack()
        {
            Instantiate(projectilePrefab, _transform.position, Quaternion.identity);
        }

        private void Death()
        {
            if (_isDead) return;
            _isDead = true;

            explosion.gameObject.SetActive(true);
            explosion.SetTrigger(_explosionHash);

            StartCoroutine(DeathRoutine());
        }

        private IEnumerator DeathRoutine()
        {
            yield return new WaitForSeconds(.25f);
            body.gameObject.SetActive(false);
            yield return new WaitForSeconds(.75f);
            Destroy(gameObject);
        }

        private void UpdateAttackTimer()
        {
            _attackTimer -= Time.deltaTime;

            if (_attackTimer <= 0f)
            {
                _attackTimer = attackCooldown;
                Attack();
            }
        }
    }
}