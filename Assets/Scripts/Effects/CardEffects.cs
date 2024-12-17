using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Effects
{
    public class CardEffects : MonoBehaviour
    {
        public void BounceAllCards(List<GameObject> cardsObjects)
        {
            foreach (var cardObject in cardsObjects)
            {
                BounceCard(cardObject);
            }
        }
        public void BounceCard(GameObject card)
        {
            Sequence sequence = DOTween.Sequence();
            
            sequence.Append(card.transform.DOScale(1.2f, 0.5f));
            sequence.Append(card.transform.DOScale(1f, 0.5f));
        }

        public void Shaking(GameObject card)
        {
            card.transform.DOShakePosition(1.0f, strength: new Vector3(5, 0, 0), vibrato: 5, randomness: 1, snapping: false, fadeOut: true);
        }
    }
}
