using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 GetCajaPosition()
    {
        return (Vector3.right * transform.position.x + Vector3.forward * transform.position.z);
    }


}
