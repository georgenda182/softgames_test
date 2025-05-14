using UnityEngine;

// Builder pattern
public class CardsBuilder : MonoBehaviour
{
    [SerializeField] private Card _cardPrefab;
    [SerializeField] private Sprite[] _cardSprites;

    private ObjectPool _cardsPool;

    // This vars are used for building a new card
    private int _builtCardNumber;

    private void Awake()
    {
        _cardsPool =  new ObjectPool(_cardPrefab);
    }

    public CardsBuilder WithNumber(int number)
    {
        _builtCardNumber = number;
        return this;
    }

    public Card Build()
    {
        Card builtCard = _cardsPool.GetObject<Card>();
        Sprite builtCardSprite = _cardSprites[_builtCardNumber - 1];
        builtCard.Configure(builtCardSprite);
        return builtCard;
    }
}
