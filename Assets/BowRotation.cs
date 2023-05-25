using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowRotation : MonoBehaviour {

    public Transform pivot;

    public float speed = 0.05f;
    public float distance = 1f;

    Vector2 toPosition;

    void Start() {

    }

    void Update() {

        Vector2 mousePos  = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)pivot.position).normalized;

        toPosition = Vector2.Lerp(toPosition, (Vector2)pivot.position + direction * distance, speed);

        transform.position = (Vector3)toPosition;

        transform.right = direction.normalized;

    }

}
