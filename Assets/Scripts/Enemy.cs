using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;

    public Transform _target;

    private void Update()
    {
        Vector3 targetPosition = _target.position;
        targetPosition.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
