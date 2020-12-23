using System;
using UnityEngine;
using UnityEngine.UI;

namespace Labirint
{
    public sealed class DisplayBonuses
    {
        private Text _bonusLable;
        
        public DisplayBonuses(GameObject bonus)
        {
            _bonusLable = bonus.GetComponent<Text>();
            _bonusLable.text = String.Empty;
        }

        public void Display(int value)
        {
            _bonusLable.text = $"Вы набрали {value}";
        }
        // public void Display(string bonusType)
        // {
        //     _text.text = $"Вы набрали {Points._pointCount} очков \n{bonusType}";
        //
        //     if (Points._pointCount >= _winPoint) 
        //         _text.text = $"Вы набрали {Points._pointCount} очков \n{bonusType} \nСледующий уровень открыт";
        // }

    }
}