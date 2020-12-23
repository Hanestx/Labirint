using System;
using UnityEngine;
using static UnityEngine.Time;
using Random = UnityEngine.Random;


namespace Labirint
{
    
    public sealed class Badbonus : InteractiveObject, IFly, IRotation
    {
        #region Fields
        
        private float _lengthFlay;
        private float _speedRotation = 15.0f;
        private PlayerBase _player;
        private DisplayBonuses _displayBonuses;
        public event Action EventBadBonus;
        public event Action<string, Color> OnCaughtPlayerChange = delegate(string str, Color color) {  };
        
        #endregion

        
        private void Start()
        {
            _lengthFlay = Random.Range(1.0f, 3.0f);
            _player = FindObjectOfType<PlayerBall>();
        }


        #region MyMethods
        
        protected override void Interaction()
        {
            OnCaughtPlayerChange.Invoke(gameObject.name, _color);
            OnEventBadBonus();
            // int bonusType = Random.Range(1, 3);
            // switch (bonusType)
            // {
            //     case 1:
            //         // BonusInfo("Замедление скорости");
            //         _player.SetSpeed(-2);
            //         break;
            //     case 2:
            //         // BonusInfo("Минус жизнь");
            //         _player.SetHealth(-1);
            //         return;
            //     default:
            //         Debug.Log("///");
            //         break;
            // }
        }
        
        public override void Execute()
        {
            if(IsInteractable){return;}
            Fly();
        }

        private void OnEventBadBonus()
        {
            EventBadBonus?.Invoke();
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