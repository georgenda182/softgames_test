using Unity.Mathematics;
using UnityEngine;

public class AceOfShadows_Installer : MonoBehaviour
{
    [Header("Origin stack")]
    [SerializeField] private float3 _originStackPosition;
    [SerializeField] private int _startingCardsInOrigin = 144;

    [Header("Destination stack")]
    [SerializeField] private float3 _destinationStackPosition;

    [Header("Scene refs")]
    [SerializeField] private CardsBuilder _cardsBuilder;
    [SerializeField] private CardsDistributor _cardsDistributor;
    [SerializeField] private UIVisualization _ui;

    private CardsStack _originCardsStack;
    private CardsStack _destinationCardsStack;

    private void Start()
    {
        int[] cardsInOrigin = new int[_startingCardsInOrigin];
        for (int i = 0; i < cardsInOrigin.Length; i++)
        {
            cardsInOrigin[i] = i + 1;
        }

        _originCardsStack = new CardsStack(_cardsBuilder, new float3(-4.75f, 0.53f, 0f), cardsInOrigin);
        _destinationCardsStack = new CardsStack(_cardsBuilder, new float3(4.75f, 0.53f, 0f));

        _ui.Configure(_originCardsStack, _destinationCardsStack);

        _cardsDistributor.Configure(_originCardsStack, _destinationCardsStack);
    }

    public void StartDistribution()
    {
        _cardsDistributor.StartDistribution();
    }
}
