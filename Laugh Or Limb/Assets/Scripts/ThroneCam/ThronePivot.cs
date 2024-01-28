using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThronePivot : MonoBehaviour
{
    [SerializeField]
    private Transform followtarget;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(followtarget);
        float newy = transform.rotation.eulerAngles.y + 180;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, newy, transform.rotation.eulerAngles.z);
    }


}
