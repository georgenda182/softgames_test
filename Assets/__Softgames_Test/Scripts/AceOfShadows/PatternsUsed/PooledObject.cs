using UnityEngine;

public abstract class PooledObject : MonoBehaviour
{
    private ObjectPool _objectPool;

    internal void Configure(ObjectPool objectPool)
    {
        _objectPool = objectPool;
    }

    public void Recycle()
    {
        _objectPool.RecycleGameObject(this);
    }
}
