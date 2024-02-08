using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Charater;
    public Inventory item;

    private void Start()
    {
        item = GameObject.Find("Inventory").GetComponent<Inventory>();
        if(item.inventoryItems.Count != 0)
        {
            for(int i = 0; i < item.inventoryItems.Count; i++)
            {
                float RandomX = UnityEngine.Random.Range(-10, 10);
                float RandomY = UnityEngine.Random.Range(-10, 10);

                Vector2 RandomPos = new Vector2(RandomX, RandomY);

                GameObject a = item.inventoryItems[i].data.MainMovecharater;

                GameObject charater = Instantiate(a, RandomPos,a.transform.rotation) as GameObject;
                charater.transform.SetParent(Charater.transform, false);
            }
        }
    }
}
