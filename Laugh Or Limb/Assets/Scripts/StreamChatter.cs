using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CustomObjects/StreamChatters")]
public class StreamChatter : ScriptableObject
{
    public enum Sentiment
    {
        POSITIVE,
        NEUTRAL,
        NEGATIVE
    }

    public string chatterName;
    public Color color = Color.blue;
    public string[] positiveResponses;
    public string[] neutralResponses;
    public string[] negativeResponses;

    public string GetRandomResponse(Sentiment sentiment)
    {
        switch (sentiment)
        {
            case Sentiment.POSITIVE:
                if (positiveResponses.Length == 0)
                    return string.Empty;
                return positiveResponses[Random.Range(0, positiveResponses.Length)];
            case Sentiment.NEUTRAL:
                if (neutralResponses.Length == 0)
                    return string.Empty;
                return neutralResponses[Random.Range(0, neutralResponses.Length)];
            case Sentiment.NEGATIVE:
                if (negativeResponses.Length == 0)
                    return string.Empty;
                return negativeResponses[Random.Range(0, negativeResponses.Length)];
            default:
                throw new System.Exception("Unknown response type");
        }
    }
}
