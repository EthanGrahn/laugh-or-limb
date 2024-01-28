using UnityEngine;
using UnityEngine.UIElements;

public class CatapultArrow : MonoBehaviour
{
    public GameObject arrow, cannon, finalCannonPos, nArrow;
    public Image neoArrow;
    bool fired = false;
    float mouseDownTimer;

    private void Start()
    {
        neoArrow = nArrow.GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownTimer = Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            arrow.SetActive(false);
            fired = true;
            cannon.transform.SetParent(finalCannonPos.transform, true);
            return;
        }

        if (!fired)
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Input.mousePosition - pos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
