using UnityEngine;

public class CatapultArrow : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            gameObject.SetActive(false);
            return;
        }

        /*
        if (Input.GetMouseButtonDown(0))
        {
            if (throwLengh < 50f)
            {
                throwLengh += Time.deltaTime * 5f;
                throwBar.transform.localScale = new Vector3(0f, throwLengh, 0f);
            }
        }
        */
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
