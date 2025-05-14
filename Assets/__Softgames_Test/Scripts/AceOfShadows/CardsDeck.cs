using System.Collections.Generic;

public class CardsDeck
{
    public delegate void CardsDeckCallback();

    public event CardsDeckCallback OnCardJustRemoved;
    public event CardsDeckCallback OnNewCardJustPut;

    private Queue<Card> _cards;

    public CardsDeck()
    {

    }

    public void Put(Card newCard)
    {
        _cards.Enqueue(newCard);
    }

    public void RemoveFromTop()
    {
        _cards.Dequeue();
    }
}
