using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems; 


public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //=====ItemeDate==//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull=false;
    public string itemDescription;

[SerializeField]
private int maxNumberOfItems;

//====itemSlot====//
[SerializeField]
private TMP_Text quantityText;

[SerializeField]
private Image itemImage;


//===DESCRIERE===//
public Image itemDescriptionImage;
public TMP_Text ItemDescriptionNameText;
public TMP_Text ItemDescriptionText;




public GameObject seelectedShader;
public bool  thisItemSelected;
private Inventory inventoryManager;

void Start()
{
    inventoryManager=GameObject.Find("InventoryCanvas").GetComponent<Inventory>();
    itemImage=GetComponent<Image>();
    itemImage.sprite=itemSprite;
}

public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
{
    //VEDEM DACA SLOTUL E PLIN//
    if(isFull)
    return quantity;
    ////
this.itemName=itemName;

this.itemSprite=itemSprite;
itemImage.sprite=itemSprite;

this.itemDescription=itemDescription;

this.quantity+=quantity;
if(this.quantity>=maxNumberOfItems)
{
quantityText.text=quantity.ToString();
quantityText.enabled=true;
isFull=true;

//RETURNEAZA CE A RAMAS
int extraItems=this.quantity-maxNumberOfItems;
this.quantity=maxNumberOfItems;
return extraItems;
}
//UPDATE
quantityText.text=this.quantity.ToString();
quantityText.enabled=true;

return 0;

}
public void OnPointerClick(PointerEventData eventData)
{
    if(eventData.button==PointerEventData.InputButton.Left)
    {
OnLeftClick();
    }
    else  if(eventData.button==PointerEventData.InputButton.Right)
    {
        //OnRightClick();
    }
}
 public void OnLeftClick()
 {
    if(thisItemSelected)
    {
         inventoryManager.UseItem(itemName);
    }

inventoryManager.DeselectAllSlots();
seelectedShader.SetActive(true);
thisItemSelected=true;
ItemDescriptionNameText.text=itemName;
ItemDescriptionText.text=itemDescription;
itemDescriptionImage.sprite=itemSprite;
 }
 //public OnRightClick()
 //{
//GameObject itemToDrop=new GameObject(itemName);
//Item NewItem=itemToDrop.AddComponent<Item>();
//newItem;
 //}
}
