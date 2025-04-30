using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class EnemyAttacked : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private Color _colorMaterialWhite = Color.white;
    private Color _colorMaterialStandart;

    private void OnDisable()
    {
        _meshRenderer.material.color = _colorMaterialStandart;
    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _colorMaterialStandart = _meshRenderer.material.color;
    }

    public void ChangeColorWhite()
    {
        _meshRenderer.material.color = _colorMaterialWhite;
    }

    public void ChangeColorStandart()
    {
        _meshRenderer.material.color = _colorMaterialStandart;
    }
}
