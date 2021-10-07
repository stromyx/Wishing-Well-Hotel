using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private Inventory inventory;
    [SerializeField] private UI_Inventory uI_Inventory;

    //public Item item;

    private void Start()
    {
        Instance = this;
        inventory = new Inventory();
        uI_Inventory.SetInventory(inventory);

    }

    public void GetItemToInventory()
    {
        inventory.AddItem(ItemWorld.Instance.GetItem());
        ItemWorld.Instance.DestroySelf();
        //Debug.Log(item.amount);
    }

    private void Update()
    {
        uI_Inventory.SetInventory(inventory);
    }

}
