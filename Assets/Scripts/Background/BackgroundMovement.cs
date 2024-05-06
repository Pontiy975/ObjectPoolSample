using UnityEngine;

namespace Background
{
    public class BackgroundMovement : MonoBehaviour
    {
        [SerializeField] private float limitHeight = 12.3f;
        [SerializeField] private float speed;

        private Transform _transform;

        private void Start()
        {
            _transform = transform;
        }

        private void Update()
        {
            _transform.Translate(0f, -speed * Time.deltaTime, 0f);

            if (_transform.position.y <= -limitHeight)
                _transform.position = new Vector2(0f, limitHeight);
        }
    }
}