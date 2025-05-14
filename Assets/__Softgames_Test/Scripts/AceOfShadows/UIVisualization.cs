using UnityEngine;

public class UIVisualization : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _originAmountText;
    [SerializeField] private TMPro.TextMeshProUGUI _destinationAmountText;

    [SerializeField] private GameObject _successMessage;

    private int _totalMovements;

    private int _originAmount;
    private int _destinationAmount;

    public void Configure(CardsStack originStack, CardsStack destinationStack)
    {
        _totalMovements = originStack.AmountOfCards;

        _originAmount = originStack.AmountOfCards;
        _destinationAmount = destinationStack.AmountOfCards;

        _originAmountText.text = _originAmount.ToString();
        _destinationAmountText.text = _destinationAmount.ToString();

        originStack.OnCardJustRemoved += DecrementOriginAmount;
        destinationStack.OnCardJustAdded += IncrementDestinationAmount;
    }

    private void DecrementOriginAmount()
    {
        _originAmount--;

        _originAmountText.text = _originAmount.ToString();
    }

    private void IncrementDestinationAmount()
    {
        _destinationAmount++;

        _destinationAmountText.text = _destinationAmount.ToString();

        TrySuccessDisplayement();
    }

    private void TrySuccessDisplayement()
    {
        if (_destinationAmount == _totalMovements)
        {
            _successMessage.SetActive(true);
        }
    }
}
