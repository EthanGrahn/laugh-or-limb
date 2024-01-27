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
        StartCoroutine(ChatMessages());
    }

    private IEnumerator ChatMessages()
    {
        yield return new WaitForSeconds(3);
        while (gameObject.activeInHierarchy)
        {
            GameObject prefab = Instantiate(messagePrefab, chatGroup.transform);
            StreamChatter chatter = chatters[Random.Range(0, chatters.Length)];
            prefab.GetComponent<ChatMessage>().InitMessage(chatter, StreamChatter.Sentiment.POSITIVE);
            yield return new WaitForSeconds(Random.Range(0.1f, 1.3f));
        }
    }
}
