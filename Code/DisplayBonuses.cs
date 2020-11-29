using UnityEngine;
using UnityEngine.UI;

namespace Labirint
{
    public sealed class DisplayBonuses
    {
        private Text _text;
        private int _winPoint = 30;


        public DisplayBonuses()
        {
            _text = Object.FindObjectOfType<Text>();
        }
        
        public void Display(string bonusType)
        {
            _text.text = $"Вы набрали {Points._pointCount} очков \n{bonusType}";

            if (Points._pointCount >= _winPoint) 
                _text.text = $"Вы набрали {Points._pointCount} очков \n{bonusType} \nСледующий уровень открыт";
        }

    }
}