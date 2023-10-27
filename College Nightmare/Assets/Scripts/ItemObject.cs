
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData itemData;
   

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
            if (Input.GetKey("e") )
            {
                
                OnHandlePickUp();
                
            }
            
        }
    }
}
