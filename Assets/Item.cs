using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Items", order = 1)]
public class Item : ScriptableObject
{
    public string description;
    public Sprite icon;
    public GameObject mesh;

    public string miscellaneousStats;

    public int maxStack;
    public int price;
}
