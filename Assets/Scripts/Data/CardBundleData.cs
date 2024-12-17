using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New CardBundleData", menuName = "Card Bundle Data", order = 1)]
    public class CardBundleData : ScriptableObject
    {
        [SerializeField] private CardData[] _cardData;

        public CardData[] CardData => _cardData;
    }
}
