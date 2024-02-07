using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private Data itemData;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = itemData.image;
        //gameObject.name = "Item object - " + itemData.name;
    }

    public void test()
    {
        Inventory.instance.AddItem(itemData);
    }
}
