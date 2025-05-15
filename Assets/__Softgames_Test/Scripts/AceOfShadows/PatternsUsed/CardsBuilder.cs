using Unity.Mathematics;
using UnityEngine;

// Builder pattern
public class CardsBuilder : MonoBehaviour
{
    [SerializeField] private Card _cardPrefab;
    [SerializeField] private Sprite[] _cardSprites;
    [SerializeField] private int _initialPooledCards = 5;

    private ObjectPool _cardsPool;

    // This vars are used for building a new card
    private int _builtCardNumber;
    private float3 _builtCardPosition;

    private void Awake()
    {
        _cardsPool = new ObjectPool(_cardPrefab);
        _cardsPool.Init(_initialPooledCards);
    }

    public CardsBuilder WithNumber(int number)
    {
        _builtCardNumber = number;
        return this;
    }

    public CardsBuilder WithPosition(float3 position)
    {
        _builtCardPosition = position;
        return this;
    }

    public Card Build()
    {
        Card builtCard = _cardsPool.GetObject<Card>();
        Sprite builtCardSprite = _cardSprites[_builtCardNumber - 1];
        builtCard.Configure(builtCardSprite, _builtCardNumber, _builtCardPosition);
        return builtCard;
    }
}
