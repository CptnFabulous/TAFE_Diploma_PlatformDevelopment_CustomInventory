using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipSlot
{
    public Item item;
    public Transform location;
}

[System.Serializable]
public class ItemStack
{
    public Item item;
    public int quantity;
}

public class Inventory : MonoBehaviour
{
    [Header("Slots")]
    public int slots = 30;
    public List<ItemStack> items;
    
    [Header("Equip slots")]
    public EquipSlot rightHand;
    public EquipSlot leftHand;
    public EquipSlot head;
    public EquipSlot torso;
    public EquipSlot lower;

    
    // Start is called before the first frame update
    void Start()
    {
        print("Item list");
        Item[] id = ItemData.GetAllItems();
        foreach (Item i in id)
        {
            Debug.Log(i.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SanityCheck()
    {
        items.RemoveRange(slots, items.Count - slots); // Removes item slots that exceed the max amount
        items.RemoveAll(s => s.quantity <= 0);

        foreach (ItemStack s in items)
        {
            s.quantity = Mathf.Clamp(s.quantity, 0, s.item.maxStack);
        }
    }

    void Equip(Item equippable, EquipSlot slot)
    {
        slot.item = equippable;
        Instantiate(equippable.mesh, slot.location);
    }
}
