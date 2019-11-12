using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour
{
    [Header("Inventory")]
    public int maxSlots = 16;
    public List<ItemStack> items;

    [Header("GUI")]
    public Canvas menu;
    public RectTransform wheelBase;
    public Image iconPrefab;
    public float wheelRadius;

    [Header("Variables")]

    int wheelIndex;
    Image[] wheelIcons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            menu.gameObject.SetActive(true);
            RefreshWheel();
        }

        if (menu.gameObject.activeSelf == true)
        {
            // Do selector stuff

            // Get angle of mouse/stick angle relative to centre of wheel
            // int selectedSector = get ???

            
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            menu.gameObject.SetActive(false);
        }
    }

    void RefreshWheel()
    {
        float angle = 360 / items.Count;

        #region Checks amount of icons and destroys/creates new icons accordingly

        if (wheelIcons.Length != items.Count) // NullReferenceException here, needs fixing
        {
            Image[] newWheelIcons = new Image[items.Count]; // Creates new array whose length matches the amount of items

            if (wheelIcons.Length < items.Count)
            {
                for (int i = 0; i < newWheelIcons.Length; i++) // Put all icons from wheelIcons into newWheelIcons, then instantiate new icons until there is an icon for every item
                {
                    if (i < wheelIcons.Length)
                    {
                        newWheelIcons[i] = wheelIcons[i];
                    }
                    else
                    {
                        Image icon = Instantiate(iconPrefab, Vector3.zero, Quaternion.identity, wheelBase);
                        newWheelIcons[i] = icon;
                    }
                }
                wheelIcons = newWheelIcons; // Replace wheelIcons with newWheelIcons to reference icons
            }
            else if (wheelIcons.Length > items.Count)
            {
                for (int i = 0; i < wheelIcons.Length; i++) // For each image in wheelIcons, put in newWheelIcons until newWheelIcons is full, then destroy any excess images
                {
                    if (i < newWheelIcons.Length)
                    {
                        newWheelIcons[i] = wheelIcons[i];
                    }
                    else
                    {
                        Destroy(wheelIcons[i]);
                    }
                }
            }

            wheelIcons = newWheelIcons; // Replace wheelIcons with newWheelIcons to reference icons
        }
        #endregion

        for (int i = 0; i < wheelIcons.Length; i++)
        {
            Vector3 iconPosition = Quaternion.Euler(0, 0, angle * i) * new Vector3(0, wheelRadius, 0);
            wheelIcons[i].rectTransform.anchoredPosition = iconPosition;

            if (items[i].item != null)
            {
                if (items[i].item.icon != null)
                {
                    wheelIcons[i].sprite = items[i].item.icon;
                }
            }
            //RectTransform rt = Instantiate(iconPrefab, Vector3.zero, Quaternion.identity, wheelBase).rectTransform;
            //rt.anchoredPosition = iconPosition;

            //iconPrefab.sprite = items[i].item.icon;
        }
    }

}
