using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Card : PooledObject
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void Configure(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
}
