using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Labirint
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        #region Fields

        private ListExecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private DisplayWinGame _displayWinGame;
        private DisplayBonuses _displayBonuses;
        private CameraController _cameraController;
        private InputController _inputController;
        private PlayerBall _player;
        private LoadLevel _level;
        private Reference _reference;
        private int _countBonuses;


        #endregion


        #region UnityMethods

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();
            _reference = new Reference();
            
            _player = _reference.PlayerBall;
            
            _displayWinGame = new DisplayWinGame(_reference.EndGame);
            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayBonuses = new DisplayBonuses(_reference.Bonus);
            
            _cameraController = new CameraController(_reference.PlayerBall.transform, _reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);
            
            _inputController = new InputController(_reference.PlayerBall);
            _interactiveObject.AddExecuteObject(_inputController);

            _level = new LoadLevel(_reference.Level, _reference.BonusObject, _reference.MiniMapCamera);
            var bonusBad = FindObjectsOfType<Badbonus>();
            var bonusGood = FindObjectsOfType<Goodbonus>();

            foreach (var bonus in bonusBad)
            {
                _interactiveObject.AddExecuteObject(bonus);
            }            
            
            foreach (var bonus in bonusGood)
            {
                _interactiveObject.AddExecuteObject(bonus);
            }
            
            foreach (var o in _interactiveObject)
                
            {
                if (o is Badbonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange += CaughtPlayer;
                    badBonus.EventBadBonus += ChangeColorPlayer;
                }
                
                if (o is Goodbonus goodBonus)
                {
                    goodBonus.OnPointChange += AddBonus;
                }
            }
            
            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);
        }
        
        private void Update()
        {

            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }

        #endregion


        #region MyMethods
        
        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0); 
            Time.timeScale = 1.0f;
        }

        private void CaughtPlayer(string value, Color args)
        {
            if (_player.Health > 1)
            {
                _player.SetHealth(-1);
                Debug.Log(_player.Health);
            }
            else 
            {
                Debug.Log(_player.Health);
                Time.timeScale = 0.0f;
                _displayEndGame.GameOver();
                _reference.RestartButton.gameObject.SetActive(true);
            }
        }
        
        private void AddBonus(int value)
        {
            Debug.Log($"Очки +{value}");
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);

            if (_countBonuses >= 30)
            {
                _displayWinGame.GameWin();
                Time.timeScale = 0.0f;
                _reference.RestartButton.gameObject.SetActive(true);
            }
        }
        
        private void ChangeColorPlayer()
        {
            _player.BadBonusOnEventBadBonus();
        }
        
        public void Dispose()
        {
            foreach (var o in _interactiveObject)
            {
                if (o is Badbonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                }
            
                if (o is Goodbonus goodBonus)
                {
                    goodBonus.OnPointChange -= AddBonus;
                }
            }
        }


        #endregion
    }
}