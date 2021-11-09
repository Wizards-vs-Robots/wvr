using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public Vector2 topLeft = new Vector2(8, 1);
    public Vector2 bottomRight = new Vector2(14, -16);
    // Update is called once per frame
    void Update()
    {
        var targetPosition = target.transform.position;
        var newPos = gameObject.transform.position;
        if (targetPosition.x < bottomRight.x && targetPosition.x > topLeft.x)
        {
            newPos.x = targetPosition.x;
        }
        if (targetPosition.y > bottomRight.y && targetPosition.y < topLeft.y)
        {
            newPos.y = targetPosition.y;
        }

        gameObject.transform.position = newPos;
    }
}
