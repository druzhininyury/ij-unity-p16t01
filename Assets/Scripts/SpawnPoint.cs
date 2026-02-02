using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private float _directionAngle = 0.0f;
    [SerializeField] private Target _target;
    
    private readonly float _gizmoArrowSize = 3.0f;
    private readonly float _gizmoArrowSideSize = 0.2f;
    private readonly float _gizmoArrowSideAngle = 150.0f;

    public float DirectionAngle => _directionAngle;

    public Vector3 Direction => Quaternion.AngleAxis(_directionAngle, Vector3.up) * Vector3.forward; 
    public Target Target => _target;

    private void OnDrawGizmosSelected()
    {
        Vector3 arrowUnitVector = Quaternion.Euler(0, _directionAngle, 0) * Vector3.forward;
        Vector3 arrowSideVector = arrowUnitVector * _gizmoArrowSize * _gizmoArrowSideSize;

        Vector3 start = transform.position;
        Vector3 end = start + arrowUnitVector * _gizmoArrowSize;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(start, end);
        Gizmos.DrawLine(end, end + Quaternion.AngleAxis(_gizmoArrowSideAngle, Vector3.up) * arrowSideVector);
        Gizmos.DrawLine(end, end + Quaternion.AngleAxis(-_gizmoArrowSideAngle, Vector3.up) * arrowSideVector);
    }
}
