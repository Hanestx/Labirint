using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Labirint
{
    public abstract class PlayerBase : MonoBehaviour
    {
        #region Fields

        public float Speed = 1.0f;
        public abstract void Move(float x, float y, float z);
        public abstract void Jump();
        public int Health { get;  private set; } = 3;

        #endregion


        #region MyMethods

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
        }

        #endregion
    }
}
