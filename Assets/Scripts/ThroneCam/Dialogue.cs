using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [Serializable]
    public struct conversationpiece
    {
        public string name;
        public string text;
    };

    [SerializeField]
    private List<conversationpiece> dialogues;
    public TMP_Text text;
    public TMP_Text name;
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
        textbox.gameObject.SetActive(true);
        StartCoroutine(nameof(DisplayDialogue));
    }

    IEnumerator DisplayDialogue()
    {
        for (int i = 0; i < dialogues.Count; i++)
        {
            name.text = dialogues[i].name;
            text.text = dialogues[i].text;
            yield return null;
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }
        textbox.gameObject.SetActive(false);
        LookSwap.endDialogue();
    }
}
