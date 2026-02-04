using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Target : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private List<Vector3> _routePoints;

    private readonly float _angleSpeed = 135.0f;
    private readonly float _moveSpeed = 3.0f;
    private readonly float _gizmosRoutePointMarkerRadius = 0.4f;

    private Renderer _renderer;
    private int _colorNameId = Shader.PropertyToID("_Color");
    private int _currentRoutePointIndex = 0;

    private void Awake()
    {
        MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
        _renderer =  GetComponent<Renderer>();
        _renderer.GetPropertyBlock(materialPropertyBlock);
        materialPropertyBlock.SetColor(_colorNameId, _color);
        _renderer.SetPropertyBlock(materialPropertyBlock);
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
            _currentRoutePointIndex = ++_currentRoutePointIndex % _routePoints.Count;
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        if (_routePoints == null || _routePoints.Count == 0)
        {
            return;
        }

        foreach (Vector3 routePoint in _routePoints)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(routePoint, _gizmosRoutePointMarkerRadius);
        }
    }
}
