using System;
using UnityEngine;
using static UnityEngine.Time;
using Random = UnityEngine.Random;


namespace Labirint
{
    public sealed class Goodbonus : InteractiveObject, IFly, IRotation
    {
        #region Fields
        
        private int _point = 5;
        public event Action <int> OnPointChange = delegate(int i) {  };
        private int _curPoints;
        private float _lengthFlay;
        private float _speedRotation = 15.0f;
        private DisplayBonuses _displayBonuses;
        private PlayerBase _player;
        
        #endregion


        private void Start()
        {
            _lengthFlay = Random.Range(1.0f, 3.0f);
            _player = FindObjectOfType<PlayerBall>();
        }


        #region MyMethods
        
        protected override void Interaction()
        {
            OnPointChange.Invoke(_point);
            
            // int bonusType = Random.Range(0, 3);
            // switch (bonusType)
            // {
            //     case 0:
            //         TakePoint("Бонусов нет");
            //         break;
            //     case 1:
            //         TakePoint("Прирост скорости");
            //         _player.SetSpeed(2);
            //         break;
            //     case 2:
            //         TakePoint("Очки X2", 2);
            //         return;
            //     case 3:
            //         TakePoint("Дополнительная жизнь");
            //         _player.SetHealth(1);
            //         break;
            //     default:
            //         Debug.Log("///");
            //         break;
            // }
        }
        
        public override void Execute()
        {
            if(IsInteractable){return;}
            Fly();
            Rotation();
        }

        
        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
        }
        
        public void Rotation()
        {
            transform.Rotate(Vector3.up * (deltaTime * _speedRotation), Space.World);
        }

        #endregion
    }
}