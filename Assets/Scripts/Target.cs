using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Color _color;

    private readonly float _angleSpeed = 135;

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
    }
}
