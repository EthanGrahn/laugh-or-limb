using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ChatMessage : MonoBehaviour
{
    const string FORMAT_STRING = "<color={0}>{1}:</color> {2}";
    [SerializeField] private TextMeshProUGUI m_TextMeshPro;
    public void InitMessage(StreamChatter chatter, StreamChatter.Sentiment sentiment)
    {
        string message = chatter.GetRandomResponse(sentiment);

        m_TextMeshPro.text = string.Format(FORMAT_STRING, "#" + chatter.color.ToHexString(), chatter.chatterName, message);
    }

    private void Update()
    {
        if (transform.localPosition.y >= 100f)
        {
            Destroy(gameObject);
        }
    }
}
