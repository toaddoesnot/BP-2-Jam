using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableLayer : MonoBehaviour
{
    [SerializeField]
    private LayerMask Clickable;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, Clickable);

            if (hit)
            {
                print("i clicked");
            }
        }
    }
}
