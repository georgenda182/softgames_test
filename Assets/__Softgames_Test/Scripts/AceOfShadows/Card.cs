using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Card : PooledObject
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _movementDuration = 0.75f;
    [SerializeField] private Vector3 _preparationOffset = new Vector3(0.25f, 0, 0);

    [SerializeField] private int _number;

    public int Number => _number;

    public void Configure(Sprite sprite, int number, float3 initialPosition)
    {
        _number = number;
        _spriteRenderer.sprite = sprite;
        transform.position = initialPosition;
    }

    private void OnDisable()
    {
        _spriteRenderer.sortingOrder = 0;
    }

    public void PrepareToBeMoved(TweenCallback onMovementFinished = null)
    {
        float3 preparationPosition = transform.position + _preparationOffset;
        transform.DOMove(preparationPosition, _movementDuration)
            .onComplete = onMovementFinished;
    }

    public void MoveToPosition(float3 position, TweenCallback onMovementFinished = null)
    {
        SetDepth(5000);
        transform.DOMove(position, _movementDuration)
            .onComplete = onMovementFinished;
    }

    public void SetDepth(int depth)
    {
        _spriteRenderer.sortingOrder = depth;
    }
}
