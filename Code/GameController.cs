using UnityEngine;
using Random = UnityEngine.Random;


namespace Labirint
{
    public sealed class GameController : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] private GameObject _nextLevelDoor;
        private InteractiveObject[] _interactiveObjects;
        private PlayerBall _player;
        private bool _win;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _player = FindObjectOfType<PlayerBall>();
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();

            foreach (var o in _interactiveObjects)
            {
                if (o is Badbonus badBonus)
                {
                    badBonus.EventBadBonus += BadBonusOnEventBadBonus;
                }
            }
        }
        
        private void Update()
        {
            if (Points._pointCount >= Points._pointWinCount && !_win)
            {
                _nextLevelDoor.SetActive(true);
                _win = true;
            }

            foreach (var interactiveObject in _interactiveObjects)
            {
                if (interactiveObject == null)
                {
                    continue;
                }
                if (interactiveObject is IFly fly)
                {
                    fly.Fly();
                }
                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }
        }

        #endregion


        #region MyMethods
        
        private void BadBonusOnEventBadBonus()
        {
            _player.BadBonusOnEventBadBonus();
        }

        #endregion
    }
}