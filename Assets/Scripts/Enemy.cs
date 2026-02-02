using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;
    
    public Transform target { get; set; }

    private void Update()
    {
        Vector3 targetPosition = target.position;
        targetPosition.y = transform.position.y;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.position += _speed * Time.deltaTime * moveDirection;
    }
}
