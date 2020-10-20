using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballPool : ABaseEntity
{
    public int size = 5;
    public GameObject basketball;
    private List<GameObject> pool;
    private int next = 0;

    public override void BaseStart()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < size; i++)
        {
            GameObject obj = (GameObject)Instantiate(basketball);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject getObject()
    {
        next++;
        return pool[next %= size];
    }
}
