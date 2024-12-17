using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New LevelData", menuName = "Level Data", order = 2)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private int _levelRows;
        [SerializeField] private int _levelColumns;
        [SerializeField] private CardBundleData _cardBundleData;
    
        public int LevelRows => _levelRows;
        public int LevelColumns => _levelColumns;

        public CardBundleData CardBundleData => _cardBundleData;
    }
}
