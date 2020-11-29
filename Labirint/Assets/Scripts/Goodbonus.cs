using UnityEngine;
using static UnityEngine.Time;
using Debug = UnityEngine.Debug;


namespace Labirint
{
    public sealed class Goodbonus : InteractiveObject, IFly, IRotation
    {
        #region Fields
        
        private int _curPoints;
        private float _lengthFlay;
        private float _speedRotation = 15.0f;
        private DisplayBonuses _displayBonuses;
        private Player _player;
        
        #endregion
        
        
        private void Awake()
        {
            _lengthFlay = Random.Range(1.0f, 3.0f);
            _displayBonuses = new DisplayBonuses();
            _player = FindObjectOfType<PlayerBall>();
        }


        #region MyMethods
        
        protected override void Interaction()
        {
            int bonusType = Random.Range(0, 3);
            switch (bonusType)
            {
                case 0:
                    TakePoint("Бонусов нет");
                    break;
                case 1:
                    TakePoint("Прирост скорости");
                    _player.SetSpeed(2);
                    break;
                case 2:
                    TakePoint("Очки X2", 2);
                    return;
                case 3:
                    TakePoint("Дополнительная жизнь");
                    _player.SetHealth(1);
                    break;
                default:
                    Debug.Log("///");
                    break;
            }
        }
        
        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
        }
        
        public void Rotation()
        {
            transform.Rotate(Vector3.up * (deltaTime * _speedRotation), Space.World);
        }

        private void TakePoint(string bonus, int value = 1)
        {
            _curPoints = Points.PointsCount(5 * value);
            _displayBonuses.Display(bonus);
        }
        
        #endregion
    }
}