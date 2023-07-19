using UnityEngine;

namespace Assets.Scripts.ObjectPool
{
    [System.Serializable]
    public class CollectableItem
    {
        [Range(0f, 1f)]
        public float rate;
        public GameObject prefab;
    }
}
