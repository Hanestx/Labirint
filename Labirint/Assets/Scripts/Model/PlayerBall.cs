using UnityEngine;
using Random = UnityEngine.Random;

namespace Labirint
{
    public sealed class PlayerBall : PlayerBase
    {
        private Rigidbody _rigidbody;
        private Material _material;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public override void Move(float x, float y, float z)
        {
            _rigidbody.AddForce(new Vector3(x, y, z) * Speed);
        }

        public override void Jump()
        {
            try
            {
                throw new MyException("Прыжок в разработке");
            }
            catch (MyException e)
            {
                Debug.Log($"{e.Message}");
            }
        }
        
        public void BadBonusOnEventBadBonus() //Метод который вызовется при встрече с BadBonus
        {
            Debug.Log("Смена цвета");
            _material = GetComponent<Renderer>().material;
            _material.color = new Color(Random.value, Random.value, Random.value, 1);
        }
    }
}
