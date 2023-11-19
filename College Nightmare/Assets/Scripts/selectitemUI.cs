using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectitemUI : MonoBehaviour
{
    public Vector3 slot1;
    public Vector3 slot2;
    public Vector3 slot3;
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            this.gameObject.SetActive(true);

            GetComponent<RectTransform>().anchoredPosition = slot1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.gameObject.SetActive(true);
            GetComponent<RectTransform>().anchoredPosition = slot2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            this.gameObject.SetActive(true);
            GetComponent<RectTransform>().anchoredPosition = slot3;
        }
    }
}
