using UnityEngine;

namespace PoolingSystem
{
    public class PoolManager : MonoBehaviour
    {
        #region Singleton
        private static PoolManager _instance;
        public static PoolManager Instance => _instance;

        private void Awake()
        {
            if (_instance == null) _instance = this;
            else Destroy(gameObject);
        }
        #endregion

        [SerializeField] private PoolController[] controllers;

        private void Start()
        {
            for (int i = 0; i < controllers.Length; i++)
            {
                controllers[i].Init();
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < controllers.Length; i++)
            {
                controllers[i].Clear();
            }
        }

        public T GetFromPool<T>(PoolType type) where T : PoolableObject
        {
            for (int i = 0; i < controllers.Length; i++)
            {
                if (controllers[i].Type == type)
                    return controllers[i].GetFromPool<T>();
            }

            return null;
        }

        public void ReturnToPool<T>(PoolType type, T item) where T : PoolableObject
        {
            for (int i = 0; i < controllers.Length; i++)
            {
                if (controllers[i].Type == type)
                {
                    controllers[i].ReturnToPool(item);
                    break;
                }
            }
        }
    }
}