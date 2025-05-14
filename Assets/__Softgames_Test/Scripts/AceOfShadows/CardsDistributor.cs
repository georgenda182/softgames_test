using UnityEngine;

public class CardsDistributor : MonoBehaviour
{
    private int _totalMovements;

    private CardsStack _originCardsStack;
    private CardsStack _destinationCardsStack;

    private Card _currentMovedCard;
    private int _totalMovedCards;

    public void Configure(CardsStack originStack, CardsStack destinationStack)
    {
        _totalMovements = originStack.AmountOfCards;

        _originCardsStack = originStack;
        _destinationCardsStack = destinationStack;
    }

    public void StartDistribution()
    {
        StartNextMovement();
    }

    private void StartNextMovement()
    {
        _currentMovedCard = _originCardsStack.RemoveFromTop();

        _currentMovedCard.PrepareToBeMoved(onMovementFinished: MoveOriginTopToDestination);
    }

    private void MoveOriginTopToDestination()
    {
        _currentMovedCard.MoveToPosition(_destinationCardsStack.Position,
                                         onMovementFinished: PrepareNextMovementTurn);
    }

    private void PrepareNextMovementTurn()
    {
        _destinationCardsStack.Put(_currentMovedCard);
        _totalMovedCards++;

        if (_totalMovedCards < _totalMovements)
        {
            StartNextMovement();
        }
    }
}
