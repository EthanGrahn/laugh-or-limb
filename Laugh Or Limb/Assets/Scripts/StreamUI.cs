using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class StreamUI : MonoBehaviour
{
    public static StreamUI Instance;

    public VerticalLayoutGroup chatGroup;
    public GameObject messagePrefab;
    public StreamChatter.Sentiment currentSentiment = StreamChatter.Sentiment.NEUTRAL;
    public TextMeshProUGUI scoreIndicator;

    private StreamChatter[] chatters;
    private List<StreamChatter> positiveChatters = new List<StreamChatter>();
    private List<StreamChatter> neutralChatters = new List<StreamChatter>();
    private List<StreamChatter> negativeChatters = new List<StreamChatter>();
    private Queue<int> pointQueue = new Queue<int>();

    private int currentScore = 0;
    public UnityEvent<int> OnSentimentChange = new UnityEvent<int>();

    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        chatters = Resources.LoadAll<StreamChatter>("StreamChatters");
        foreach (var chatter in chatters)
        {
            chatter.color = Random.ColorHSV(0.26f, 1, 0.85f, 1, 0.6f, 1, 1, 1);
            if (chatter.positiveResponses.Length != 0)
                positiveChatters.Add(chatter);
            if (chatter.neutralResponses.Length != 0)
                neutralChatters.Add(chatter);
            if (chatter.negativeResponses.Length != 0)
                negativeChatters.Add(chatter);

        }
        StartCoroutine(ChatMessages());
        StartCoroutine(MonitorPointQueue());
    }

    private IEnumerator ChatMessages()
    {
        yield return new WaitForSeconds(3);
        while (gameObject.activeInHierarchy)
        {
            GameObject prefab = Instantiate(messagePrefab, chatGroup.transform);
            StreamChatter chatter = GetChatterWithSentiment(currentSentiment);
            prefab.GetComponent<ChatMessage>().InitMessage(chatter, currentSentiment);
            yield return new WaitForSeconds(Random.Range(2f, 4f));
        }
    }

    private IEnumerator MonitorPointQueue()
    {
        while (gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(2);
            if (pointQueue.Count > 0)
            {
                pointQueue.Dequeue();
            }
        }
    }

    private StreamChatter GetChatterWithSentiment(StreamChatter.Sentiment sentiment)
    {
        switch (sentiment)
        {
            case StreamChatter.Sentiment.POSITIVE:
                return positiveChatters[Random.Range(0, positiveChatters.Count)];
            case StreamChatter.Sentiment.NEUTRAL:
                return neutralChatters[Random.Range(0, neutralChatters.Count)];
            case StreamChatter.Sentiment.NEGATIVE:
                return negativeChatters[Random.Range(0, negativeChatters.Count)];
            default:
                return null;
        }
    }

    private StreamChatter.Sentiment CalculateSentiment()
    {
        int total = 0;
        foreach(var point in pointQueue)
        {
            total += point;
        }
        if (total >= 400)
        {
            currentSentiment = StreamChatter.Sentiment.POSITIVE;
            OnSentimentChange.Invoke(4);
        }
        else if (total >= 150)
        {
            currentSentiment = StreamChatter.Sentiment.NEUTRAL;
            OnSentimentChange.Invoke(0);
        }
        else
        {
            currentSentiment = StreamChatter.Sentiment.NEGATIVE;
            OnSentimentChange.Invoke(1);
        }

        return currentSentiment;
    }

    public void AddPoints(int amount)
    {
        currentScore += amount;
        pointQueue.Enqueue(amount);
        CalculateSentiment();
        scoreIndicator.text = string.Format("viewers: {0}", currentScore);
    }
}
