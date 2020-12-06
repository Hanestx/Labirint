using UnityEngine;


namespace Labirint
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        public bool IsInteractable { get; private set; } = true;
        protected abstract void Interaction();

        private void OnTriggerEnter(Collider other)
        { 
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            Destroy(gameObject);
        }
        
    }
}