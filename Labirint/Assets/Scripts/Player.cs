using UnityEngine;
using UnityEngine.SceneManagement;


namespace Labirint
{
    public class Player : MonoBehaviour
    {
        #region Fields

        public int Speed { get;  private set; } = 3;
        public int Health { get;  private set; } = 3;
        private Rigidbody _rigidbody;

        #endregion
        
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }


        #region MyMethods

        protected void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            _rigidbody.AddForce(movement * Speed);
        }

        public void SetSpeed(int value)
        {
            Speed += value;
            
            if (Speed == 0)
                Speed = 1;
            if (Speed < 0) //Кнопки управления работают в противоположные стороны
                Debug.Log("Молодой человек вы пьяны.");
        }
        
        public void SetHealth(int value)
        {
            Health += value;
            
            if (Health <= 0)
            {
                Debug.Log("Ты проиграл");
                SceneManager.LoadScene(0);
            }
        }

        #endregion
    }
}
