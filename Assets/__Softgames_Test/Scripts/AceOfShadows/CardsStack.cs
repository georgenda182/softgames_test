using System.Collections.Generic;
using Unity.Mathematics;

public class CardsStack
{
    public delegate void CardsStackCallback();
    public event CardsStackCallback OnCardJustAdded;
    public event CardsStackCallback OnCardJustRemoved;

    private readonly int MAX_SHOWN_CARDS = 2;

    private List<Card> _shownCards;
    private List<int> _cardsNumbers;

    private CardsBuilder _cardsBuilder;

    private float3 _position;

    public int AmountOfCards => _cardsNumbers.Count;
    public float3 Position => _position;

    public CardsStack(CardsBuilder cardsBuilder, float3 position, int[] startingCardsNumbers = null)
    {
        _cardsBuilder = cardsBuilder;
        _position = position;
        _shownCards = new List<Card>();

        if (startingCardsNumbers == null)
        {
            _cardsNumbers = new List<int>();
            return;
        }
        
        _cardsNumbers = new List<int>();

        Card cardToAdd;
        for (int i = 0; i < startingCardsNumbers.Length; i++)
        {
            cardToAdd = _cardsBuilder
                            .WithNumber(startingCardsNumbers[i])
                            .WithPosition(_position)
                            .Build();
            Put(cardToAdd);
        }
    }

    public void Put(Card newCard)
    {
        _shownCards.Add(newCard);
        if (_shownCards.Count > MAX_SHOWN_CARDS)
        {
            Card cardToRecycle = _shownCards[0];
            cardToRecycle.Recycle();

            _shownCards.RemoveAt(0);
        }

        SetCardsDepths();

        _cardsNumbers.Add(newCard.Number);
        OnCardJustAdded?.Invoke();
    }

    public Card RemoveFromTop()
    {
        Card removedCard = _shownCards[^1];
        _shownCards.Remove(removedCard);

        if (_cardsNumbers.Count > MAX_SHOWN_CARDS)
        {
            int nextCardToBeDisplayed = _cardsNumbers[^(MAX_SHOWN_CARDS + 1)];
            _shownCards.Insert(0, _cardsBuilder
                                    .WithNumber(nextCardToBeDisplayed)
                                    .WithPosition(_position)
                                    .Build());
        }
        _cardsNumbers.RemoveAt(_cardsNumbers.Count - 1);

        SetCardsDepths();

        OnCardJustRemoved?.Invoke();

        return removedCard;
    }

    private void SetCardsDepths()
    {
        for (int i = 0; i < _shownCards.Count; i++)
        {
            _shownCards[i].SetDepth(i);
        }
    }
}
