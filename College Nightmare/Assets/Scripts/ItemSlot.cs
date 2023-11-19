using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _itemName;

    [SerializeField]
    private Image _itemIcon;

    [SerializeField]
    private GameObject _stackObj;


    public void Set(InventoryItem item)
    {
        _itemName.text = item.data.itemName;
        _itemIcon.sprite = item.data.itemIcon;

        
            _stackObj.SetActive(false);
            return;
     

        
    }

}
