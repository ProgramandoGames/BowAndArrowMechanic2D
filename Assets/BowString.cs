using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowString : MonoBehaviour {

    public Transform pivot;

    LineRenderer line;

    Transform p1;
    Transform p2;

    Vector2 direction;
    Vector2 midPosition;
    Vector2 stretchPosition;

    public float stretchSpeed = 0.05f;
    public float throwSpeed  = 1f;
    public float stretchLimit = 0.5f;

    public Vector2 MidPosition => midPosition;
    public Vector2 Direction   => direction;

    float speed;

    void Awake() {

        line = transform.GetChild(0).GetComponent<LineRenderer>();

        p1 = transform.GetChild(1);
        p2 = transform.GetChild(2);

    }

    void Start() {

        midPosition = (p1.localPosition + p2.localPosition) / 2;

        line.positionCount = 3;
        line.SetPositions(new Vector3[] { p1.localPosition, midPosition, p2.localPosition});

    }

    void Update() {

        Vector2 mousePos  = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePos - (Vector2)pivot.position).normalized;

        Vector2 mid = (p1.position + p2.position) / 2;

        if(Input.GetKey(KeyCode.Mouse0)) {
            stretchPosition = mid - direction * stretchLimit;
            speed = stretchSpeed;
        } else {
            stretchPosition = mid;
            speed = throwSpeed;
        }

        midPosition = Vector2.Lerp(midPosition, stretchPosition, speed);

        line.SetPosition(0, p1.position);
        line.SetPosition(1, midPosition);
        line.SetPosition(2, p2.position);

    }

}
