using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionaBulletPool : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    public static DirectionaBulletPool Instance { get; private set; }
    private Queue<GameObject> objects = new Queue<GameObject>();
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }

    public GameObject Get()
    {
        if (objects.Count == 0)
            AddObjects(1);
        return objects.Dequeue();
    }

    public void ReturnToPool(GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        objects.Enqueue(objectToReturn);
    }

    private void AddObjects(int count)
    {
        var newObject = GameObject.Instantiate(prefab);
        newObject.SetActive(true);
        objects.Enqueue(newObject);

        newObject.GetComponent<IGameObjectPooled>().Pool = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
