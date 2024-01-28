using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JestorFaceController : MonoBehaviour
{
    public GameObject neutralFace, hurtFace;
    // Start is called before the first frame update
    void Start()
    {
        neutralFace.SetActive(true);
        hurtFace.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (neutralFace.activeSelf)
            {
                neutralFace.SetActive(false);
                hurtFace.SetActive(true);
            }
            else
            {
                neutralFace.SetActive(true);
                hurtFace.SetActive(false);
            }
        }
    }
}
