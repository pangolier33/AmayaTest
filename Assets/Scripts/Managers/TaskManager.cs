using System.Collections;
using System.Collections.Generic;
using Core;
using Data;
using Effects;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Managers
{
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private Text _taskText;
        [SerializeField] private FadeEffect _fadeEffect;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private CardEffects _cardEffects;
    
        private int _targetRandomNumber;
        private List<CardData> _spendCards = new List<CardData>();
    
        public void TargetId(List<GameObject> cards, List<CardData> cardsData)
        {
            _targetRandomNumber = GetRandomNumber(cardsData);
            CheckCard(cards);
            ChangeText(cardsData[_targetRandomNumber].Identifier);
            _fadeEffect.FadeIn(_taskText.gameObject);
        }

        private int GetRandomNumber(List<CardData> cards)
        {
            int RandomNumber = Random.Range(0, cards.Count);
            foreach (var spendCard in _spendCards)
            {
                if (spendCard == cards[RandomNumber])
                    GetRandomNumber(cards);
            }
            _spendCards.Add(cards[RandomNumber]);
            return RandomNumber;
        }
    
        private void ChangeText(string targetId)
        {
            _taskText.text = "Find " + targetId;
        }

        private void CheckCard(List<GameObject> cards)
        {
            foreach (GameObject card in cards)
            {
                Button button = card.GetComponent<Button>();
                int index = cards.IndexOf(card); 
                button.onClick.AddListener(() => CheckClick(index, card));
            }
        }
    
        private void CheckClick(int clickedIndex, GameObject card)
        {
            if (clickedIndex == _targetRandomNumber)
            {
                StartCoroutine(BounceAndChangeLevel(card));
            }
            else
            {
                _cardEffects.Shaking(card);
            }
        }
    
        private IEnumerator BounceAndChangeLevel(GameObject card)
        {
            _particleSystem.gameObject.transform.position = card.transform.position;
            _particleSystem.gameObject.SetActive(true);
            _cardEffects.BounceCard(card); 
            yield return new WaitForSeconds(1f);
            _particleSystem.gameObject.SetActive(false);
            EventManager.OnLevelChanged?.Invoke();
        }
    }
}
