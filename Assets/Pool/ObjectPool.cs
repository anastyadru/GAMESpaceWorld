using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject pooledObject; // Префаб объекта пула
    public int poolSize = 10; // Размер пула

    private List<GameObject> pooledObjects;

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        
        for (int i = 0; i < poolSize; i++) // Создаем и инициализируем объекты пула
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject Get()
    {
        foreach (GameObject obj in pooledObjects) // Ищем неактивный объект в пуле и возвращаем его
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        
        GameObject newObj = Instantiate(pooledObject); // Если все объекты заняты, создаем новый объект и добавляем его в пул
        newObj.SetActive(true);
        pooledObjects.Add(newObj);
        return newObj;
    }

    public void Release(GameObject obj)
    {
        IPoolable poolableObject = obj.GetComponent<IPoolable>(); // Вызываем метод OnRelease() у объекта перед возвращением его в пул
        if (poolableObject != null)
        {
            poolableObject.OnRelease();
        }
        obj.SetActive(false);
    }
}