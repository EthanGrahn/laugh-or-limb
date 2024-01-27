using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StreamUI : MonoBehaviour
{
    public VerticalLayoutGroup chatGroup;
    public ChatMessage testMessage;
    public GameObject messagePrefab;

    private StreamChatter[] chatters;

    void Start()
    {
        chatters = Resources.LoadAll<StreamChatter>("StreamChatters");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            GameObject prefab = Instantiate(messagePrefab, chatGroup.transform);
            prefab.GetComponent<ChatMessage>().InitMessage(chatters[0], StreamChatter.Sentiment.POSITIVE);
        }
    }
}
