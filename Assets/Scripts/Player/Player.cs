using Projectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerProjectile projectilePrefab;
        [SerializeField] private Animator explosion;
        [SerializeField] private GameObject body;
        [SerializeField] private List<string> collisionTags;

        private Transform _transform;
        private Camera _camera;
        private bool _isDead;

        private Vector2 _targetPosition;
        private (float, float) _screenRestrictions;

        private static readonly int _explosionHash = Animator.StringToHash("Explosion");

        private void Start()
        {
            _transform = transform;
            _camera = Camera.main;

            _screenRestrictions = (ScreenSize.BottomLeft.x, ScreenSize.TopRight.x);
        }

        void Update()
        {
            if (_isDead) return;

            Movement();
            Attack();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collisionTags.Contains(collision.tag))
                Death();
        }

        private void Movement()
        {
            _targetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _targetPosition.x = Mathf.Clamp(_targetPosition.x, _screenRestrictions.Item1, _screenRestrictions.Item2);

            _transform.position = new Vector2(_targetPosition.x, _transform.position.y);
        }

        private void Attack()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
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
    }
}