using UnityEngine;

namespace Enemies
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float spawnCooldown;
        [SerializeField] private GameObject prefab;

        private float _timer;

        private void Start()
        {
            _timer = spawnCooldown;
        }

        private void Update()
        {
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0f)
            {
                _timer = spawnCooldown;
                Spawn();
            }
        }

        private void Spawn()
        {
            Instantiate(prefab, GetPoint(), Quaternion.identity);
        }

        private Vector2 GetPoint()
        {
            float x = Random.Range(ScreenSize.BottomLeft.x + 1f, ScreenSize.TopRight.x - 1f);
            return new Vector2(x, ScreenSize.TopRight.y);
        }
    }
}