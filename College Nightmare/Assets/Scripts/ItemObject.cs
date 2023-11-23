
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData itemData;
    public GameObject pickupText;

    public void OnHandlePickUp()
    {
        
        InventorySystem.Instance.Add(itemData);
        Destroy(gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            Debug.Log("CONTACTO");
            pickupText.SetActive(true);
            if (Input.GetKey("e") )
            {
                pickupText.SetActive(false);
                OnHandlePickUp();
                
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickupText.SetActive(false);
        }
    }
}
