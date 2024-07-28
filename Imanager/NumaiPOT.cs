using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New InteractableItem", menuName = "Assets/Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public void UseItem()
    {
        if (statToChange == StatToChange.health)
        {
           // GameObject.Find("PERSONAJ").GetComponent<PlayerLife>().ChangeHealth(amountToChangeStat);
        }
    }

    public enum StatToChange
    {
        health,
        craftable,
        rau
    };
}
