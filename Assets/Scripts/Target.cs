using System;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private List<Vector3> _routePoints;

    private readonly float _angleSpeed = 135.0f;
    private readonly float _moveSpeed = 3.0f;
    private readonly Vector3[] _gizmoRoutePointMarker = new[]
    {
        new Vector3(-0.5f, 0, 0),
        new Vector3(0.5f, 0, 0),
        new Vector3(0, 0, 0.5f),
        new Vector3(0, 0, -0.5f)
    };

    private int _currentRoutePointIndex = 0;

    private void OnDrawGizmosSelected()
    {
        if (_routePoints == null || _routePoints.Count == 0)
        {
            return;
        }

        foreach (Vector3 routePoint in _routePoints)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(
                _gizmoRoutePointMarker[0] + routePoint, 
                _gizmoRoutePointMarker[1] + routePoint);
            Gizmos.DrawLine(
                _gizmoRoutePointMarker[2] + routePoint,
                _gizmoRoutePointMarker[3] + routePoint);
        }
    }

    private void Awake()
    {
        MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
        Renderer renderer =  GetComponent<Renderer>();
        renderer.GetPropertyBlock(materialPropertyBlock);
        materialPropertyBlock.SetColor("_Color", _color);
        renderer.SetPropertyBlock(materialPropertyBlock);
    }
    
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, _angleSpeed * Time.deltaTime, 0) * transform.rotation;
        
        transform.position = Vector3.MoveTowards(
            transform.position, 
            _routePoints[_currentRoutePointIndex], 
            _moveSpeed * Time.deltaTime);

        if (transform.position == _routePoints[_currentRoutePointIndex])
        {
            _currentRoutePointIndex = (_currentRoutePointIndex + 1) % _routePoints.Count;
        }
    }
}
