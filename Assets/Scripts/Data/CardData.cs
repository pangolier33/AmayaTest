using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class CardData
    {
        [SerializeField] private string _identifier;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _turn = 0;

        public string Identifier => _identifier;
        public Sprite Sprite => _sprite;
        public int Turn => _turn;
    }
}
