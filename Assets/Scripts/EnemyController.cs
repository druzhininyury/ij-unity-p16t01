using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    
    private void Update()
    {
        transform.position += _speed * Time.deltaTime * transform.forward;
    }
}
