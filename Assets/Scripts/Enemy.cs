using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    private Vector3 _moveDirection = Vector3.forward;
    
    public Vector3 MoveDirection
    {
        get => _moveDirection;
        set => _moveDirection = value.normalized;
    }

    private void Update()
    {
        transform.position += _speed * Time.deltaTime * _moveDirection;
    }
}
