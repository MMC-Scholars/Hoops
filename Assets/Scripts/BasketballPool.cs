using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballPool : MonoBehaviour
{
    public List<GameObject> pool;
    public int size = 5;
    public GameObject basketball;
    private int next = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            GameObject obj = (GameObject)Instantiate(basketball);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject getObject()
    {
        return pool[next++ % size];
    }
}
