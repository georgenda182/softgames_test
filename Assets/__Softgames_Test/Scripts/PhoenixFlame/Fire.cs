using UnityEngine;

public class Fire : MonoBehaviour
{
    [HideInInspector] public float _gradientPosition;

    [SerializeField] private Gradient _animatedColor;

    private ParticleSystemRenderer _particleSystem;
    private Material _particleSystemMaterial;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystemRenderer>();
        _particleSystemMaterial = _particleSystem.material;
    }

    private void Update()
    {
        _particleSystemMaterial.color = _animatedColor.Evaluate(_gradientPosition);
    }
}
