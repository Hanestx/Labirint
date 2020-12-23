using System;
using UnityEngine;
using UnityEngine.UI;

namespace Labirint
{
    public class DisplayWinGame
    {
        private Text _finishGameLabel;

        public DisplayWinGame(GameObject winGame)
        {
            _finishGameLabel = winGame.GetComponent<Text>();
            _finishGameLabel.text = String.Empty;
        }
        
        public void GameWin()
        {
            _finishGameLabel.text = $"Вы выйграли. Вы собрали все очки.";
        }
    }
}