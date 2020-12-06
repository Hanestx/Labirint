using UnityEngine;
using Random = UnityEngine.Random;

namespace Labirint
{
    public sealed class PlayerBall : Player
    {
        private Material _material;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Пример который вызовет Exception
                Jump();
        }

        private void FixedUpdate()
        {
            Move();
        }
        
        
        public void BadBonusOnEventBadBonus() //Метод который вызовется при встрече с BadBonus
        {
            Debug.Log("Смена цвета");
            _material = GetComponent<Renderer>().material;
            _material.color = new Color(Random.value, Random.value, Random.value, 1);
        }
    }
}
