using System.Collections.Generic;
using Data;
using Effects;
using Managers;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Core
{
    public class AddNewCard : MonoBehaviour
    {
        [SerializeField] private GameObject _cardPanel;
        [SerializeField] private GameObject _cardPrefab;
        [SerializeField] private TaskManager _taskManager;
        [SerializeField] private CardEffects _cardEffects;
    
        private List<CardData> _cards = new List<CardData>();
        private List<GameObject> _cardsObjects = new List<GameObject>();

        private CardBundleData _cardBundleData;
        private CardData _currentCard;
        private GameObject _card;

        public void StartSpawn(LevelData levelData)
        {
            DeleteOldCards();
        
            int count = levelData.LevelColumns * levelData.LevelRows;
            _cardBundleData = levelData.CardBundleData;
            List<int> uniqueNumbers = RandomNumberGenerator.GetUniqueRandomNumbersShuffle(0, levelData.CardBundleData.CardData.Length - 1, count);
        
            for (int i = 0; i < count; i++)
            {
                SpawnCard(uniqueNumbers[i]);
                _cardEffects.BounceAllCards(_cardsObjects);
            }
        
            _taskManager.TargetId(_cardsObjects, _cards);
        }
    
        private void SpawnCard(int randomNumber)
        {
            _card = Instantiate(_cardPrefab, _cardPanel.transform);
            _cardsObjects.Add(_card);
            _cards.Add(_cardBundleData.CardData[randomNumber]);
            SetSprite(_card, _cardBundleData.CardData[randomNumber]);
        }
    
        private void SetSprite(GameObject card, CardData cardData)
        {
            GameObject spriteObject = card.transform.GetChild(0).gameObject;
        
            if (cardData.Turn != 0)
                spriteObject.transform.transform.Rotate(0, 0, cardData.Turn);
        
            Image img = spriteObject.GetComponent<Image>();
            img.sprite = cardData.Sprite;
        }

        private void DeleteOldCards()
        {
            foreach (var cardObject in _cardsObjects)
            {
                Destroy(cardObject);
            }
            _cardsObjects.Clear();
            _cards.Clear();
        }
    }
}
