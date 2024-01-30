using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingFaceController : MonoBehaviour
{
    public Image controller;
    public Sprite neutralFace;
    public Sprite boredFace, chuckleFace, laughFace, smirkFace;
    private Sprite[] faces = new Sprite[5];
    // Start is called before the first frame update
    void Start()
    {
        //Quick Fix
        faces[0] = neutralFace; 
        faces[1] = boredFace;
        faces[2] = smirkFace;
        faces[3] = chuckleFace; 
        faces[4] = laughFace;

        controller = this.gameObject.GetComponent<Image>();
        setFace(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFace(int faceCode)
    {
        controller.sprite = faces[faceCode];
    }
}
