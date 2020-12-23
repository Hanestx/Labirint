using UnityEngine;
using UnityEngine.UI;

namespace Labirint
{
    public sealed class Reference
    {
        private PlayerBall _playerBall;
        private Camera _mainCamera;
        private Camera _miniMapCamera;
        private GameObject _miniMapCameraView;
        private GameObject _level;
        private GameObject _bonusView;
        private GameObject _bonusObject;
        private GameObject _bonusBad;
        private GameObject _bonusGood;
        private GameObject _endGame;
        private Canvas _canvas;
        private Button _restartButton;

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }

        public Camera MiniMapCamera
        {
            get
            {
                if (_miniMapCamera == null)
                {
                    var gameObject = Resources.Load<GameObject>("MiniMap/MiniMapCamera");
                    var _miniMapCamer = Object.Instantiate(gameObject);
                    _miniMapCamera = _miniMapCamer.GetComponent<Camera>();
                }

                return _miniMapCamera;
            }
        }
        
        public GameObject BonusObject
        {
            get
            {
                if (_bonusObject == null)
                {
                    var gameObject = Resources.Load<GameObject>("Bonuses");
                    _bonusObject = Object.Instantiate(gameObject);
                }

                return _bonusObject;
            }
        }


        public GameObject Level 
        {
            get
            {
                if (_level == null)
                {
                    var gameObject = Resources.Load<GameObject>("Plane");
                    _level = Object.Instantiate(gameObject);
                }

                return _level;
            }
        }
            
        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }
                
                return _restartButton;
            }
        }
        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }

                return _canvas;
            }
        }
        
        public GameObject Bonus
        {
            get
            {
                if (_bonusView == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Bonus");
                    _bonusView = Object.Instantiate(gameObject, Canvas.transform);
                }
            
                return _bonusView;
            }
        }
        
        public GameObject MiniMapView
        {
            get
            {
                if (_miniMapCameraView == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/MiniMap");
                    _miniMapCameraView = Object.Instantiate(gameObject, Canvas.transform);
                }
            
                return _miniMapCameraView;
            }
        }

        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/EndGame");
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                }
            
                return _endGame;
            }
        }

        public PlayerBall PlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var gameObject = Resources.Load<PlayerBall>("Player");
                    _playerBall = Object.Instantiate(gameObject);
                }
                
                return _playerBall;
            }
        }

    }
}