using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public Item item;

    public int itemTypeNumber;

    //public string itemName;
    private SpriteRenderer spriteRenderer;
    public static ItemWorld Instance { get; private set; }
    private void Start()
    {
        Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch (itemTypeNumber)
        {

            default:
            case 1:
                SetItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
                break;
            case 2:
                SetItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
                break;
            case 3:
                SetItem(new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
                break;
        }

    }

    private void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
