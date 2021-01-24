using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
public class MaterialPropertyController : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] protected float _RampAmount;
    [SerializeField] [Range(0, 1)] protected float _DissolveAmount;
    [SerializeField] protected Color _DissolveEdgeColor;

    private MeshRenderer _MeshRenderer;
    private MaterialPropertyBlock _MaterialPropertyBlock;

    // Start is called before the first frame update
    void Start()
    {
        _MeshRenderer = this.GetComponent<MeshRenderer>();
        _MaterialPropertyBlock = new MaterialPropertyBlock();
    }

    // Update is called once per frame
    void Update()
    {
        _MeshRenderer.GetPropertyBlock(_MaterialPropertyBlock);

        _MaterialPropertyBlock.SetFloat("_RampAmount", _RampAmount);
        _MaterialPropertyBlock.SetFloat("_DissolveAmount", _DissolveAmount);
        _MaterialPropertyBlock.SetColor("_DissolveColor", _DissolveEdgeColor);

        _MeshRenderer.SetPropertyBlock(_MaterialPropertyBlock);
    }
}
