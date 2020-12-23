using UnityEngine;
using static UnityEngine.Random;


namespace Labirint
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        
        [SerializeField] private bool _isAllowScaling;
        [SerializeField] private float ActiveDis;
        
        protected Color _color;
        private bool _isInteractable;
        

        protected bool IsInteractable
        {
            get { return _isInteractable; }
            private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }

        private void OnTriggerEnter(Collider other)
        { 
            if (!other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            IsInteractable = false;
        }
        
        protected abstract void Interaction();
        public abstract void Execute();
        
        private void Start()
        {
            IsInteractable = true;
            _color = ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "bot.png", _isAllowScaling);
        }

        private void OnDrawGizmosSelected()
        {
            Transform t = transform;

            //Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, t.localScale);
            //Gizmos.DrawWireCube(Vector3.zero, Vector3.one);

            var flat = new Vector3(ActiveDis, 0, ActiveDis);
            Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, flat);
            Gizmos.DrawWireSphere(Vector3.zero, 5);
        }


    }
        
    
}