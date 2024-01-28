using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUnStuck : MonoBehaviour
{
    [SerializeField]
    private GameObject Body;
    [SerializeField]
    private float distance, current;
    public int waitTime;

    private void Start()
    {
        StartCoroutine(nameof(checkY));
    }

    private IEnumerator checkY()
    {
        distance = Body.transform.position.y;
        yield return new WaitForSeconds(waitTime);
        current = Body.transform.position.y;
        if (current - distance <= 0.5f)
        {
            Body.GetComponent<Rigidbody2D>().AddForce(transform.up * 175, ForceMode2D.Impulse);
            Debug.Log("YEET");
        }

        StartCoroutine(nameof(checkY));

    }
}
