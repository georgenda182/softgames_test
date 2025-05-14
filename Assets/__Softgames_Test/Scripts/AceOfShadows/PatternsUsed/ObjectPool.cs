using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

// ObjectPool pattern from this link (with some custom changes): https://thepowerups-learning.com/patrones-de-diseno-object-pool/
// I know Unity included this pattern natively, but I prefer this implementation as it's more flexible to use
public class ObjectPool
{
    private readonly PooledObject _prefab;
    private readonly HashSet<PooledObject> _instantiateObjects;
    private Queue<PooledObject> _recycledObjects;

    public ObjectPool(PooledObject prefab)
    {
        _prefab = prefab;
        _instantiateObjects = new HashSet<PooledObject>();
    }

    public void Init(int numberOfInitialObjects)
    {
        _recycledObjects = new Queue<PooledObject>(numberOfInitialObjects);

        for (var i = 0; i < numberOfInitialObjects; i++)
        {
            var instance = InstantiateNewInstance();
            instance.gameObject.SetActive(false);
            _recycledObjects.Enqueue(instance);
        }
    }

    private PooledObject InstantiateNewInstance()
    {
        var instance = Object.Instantiate(_prefab);
        instance.Configure(this);
        return instance;
    }

    public T GetObject<T>()
    {
        var pooledObject = GetInstance();
        _instantiateObjects.Add(pooledObject);
        pooledObject.gameObject.SetActive(true);
        return pooledObject.GetComponent<T>();
    }

    private PooledObject GetInstance()
    {
        if (_recycledObjects.Count > 0)
        {
            return _recycledObjects.Dequeue();
        }

        Debug.LogWarning($"Not enough recycled objets for {_prefab.name} consider increase the initial number of objets");
        var instance = InstantiateNewInstance();
        return instance;
    }

    public void RecycleGameObject(PooledObject pooledObjectToRecycle)
    {
        var wasInstantiated = _instantiateObjects.Remove(pooledObjectToRecycle);
        Assert.IsTrue(wasInstantiated, $"{pooledObjectToRecycle.name} was not instantiate on {_prefab.name} pool");

        pooledObjectToRecycle.gameObject.SetActive(false);
        _recycledObjects.Enqueue(pooledObjectToRecycle);
    }
}
