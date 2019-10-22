using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemData
{
    static string[] items = new string[]
    {
        ""
    };

    public static Item GetItemByID(int id)
    {
        return Resources.Load<Item>("Items/ItemObjects/" + items[id]);
    }

    public static Item GetItemByName(string name)
    {
        return Resources.Load<Item>("Items/ItemObjects/" + name);
    }

    public static Item[] GetAllItems()
    {
        //return Resources.LoadAll<Item>("Items/ItemObjects/");
        return Resources.LoadAll<Item>("");
    }
}
