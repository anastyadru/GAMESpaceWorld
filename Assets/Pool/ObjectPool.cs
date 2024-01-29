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

        // Создаем и инициализируем объекты пула
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject Get()
    {
        // Ищем неактивный объект в пуле и возвращаем его
        foreach (GameObject obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // Если все объекты заняты, создаем новый объект и добавляем его в пул
        GameObject newObj = Instantiate(pooledObject);
        newObj.SetActive(true);
        pooledObjects.Add(newObj);
        return newObj;
    }

    public void Release(GameObject obj)
    {
        // Вызываем метод OnRelease() у объекта перед возвращением его в пул
        IPoolable poolableObject = obj.GetComponent<IPoolable>();
        if (poolableObject != null)
        {
            poolableObject.OnRelease();
        }
        obj.SetActive(false);
    }
}