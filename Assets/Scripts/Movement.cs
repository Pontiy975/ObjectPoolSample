using UnityEngine;

public class Movement : MonoBehaviour
{
    private enum MovementDirection 
    {
        Up = 1,
        Down = -1
    }

    [SerializeField] private MovementDirection direction = MovementDirection.Down;
    [SerializeField] private float speed;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _transform.Translate(0f, speed * (int)direction * Time.deltaTime, 0f);
    }
}
