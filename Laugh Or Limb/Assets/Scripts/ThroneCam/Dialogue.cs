using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [Serializable]
    public struct dialogue
    {
        public Sprite emote;
        public string text;
    }

    [SerializeField]
    private List<dialogue> dialogues;
    public TextMeshPro text;
    public Image textbox;
    //public Sprite kingFace;

    public static Action nextDialogue = delegate { };

    private void OnEnable()
    {
        LookSwap.beginDialogue += Begin;
    }

    private void OnDisable()
    {
        LookSwap.beginDialogue -= Begin;
    }

    private void Begin()
    {
        textbox.enabled = true;
        StartCoroutine(nameof(DisplayDialogue));
    }

    private bool advanceDialogue()
    {
        return true;
    }

    IEnumerator DisplayDialogue()
    {
        for(int i = 0; i < dialogues.Count; i++)
        {
            //kingFace = dialogues[i].emote;
            text.text = dialogues[i].text;
            yield return new WaitUntil(advanceDialogue);
        }
        LookSwap.endDialogue();
    }
}
