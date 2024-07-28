using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

     [SerializeField]
    private int quantity;

     [SerializeField]
    private Sprite itemSprite;

[TextArea]
[SerializeField]
    private string itemDescription;

    private Inventory managerInventory;

    void Start()
    {
        managerInventory = GameObject.Find("InventoryCanvas").GetComponent<Inventory>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="PERSONAJ")
        {
           int leftOverItems=  managerInventory.AddItem(itemName,quantity,itemSprite,itemDescription);
           if(leftOverItems<=0)
            Destroy(gameObject);
            else
            quantity=leftOverItems;
        }
    }
   
    
   
}
