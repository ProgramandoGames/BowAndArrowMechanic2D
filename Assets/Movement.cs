using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    SpriteRenderer sprite;

    public float maxSpeed        = 10f;
    public float acceleration    = 1f;

    Vector2 velocity;
    Vector2 currentVelocity;

    private void Awake() {

        sprite = GetComponent<SpriteRenderer>();

    }

    void Update() {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if((transform.position.x - mousePos.x) > 0) {
            sprite.flipX = true;
        }
        if((transform.position.x - mousePos.x) < 0) {
            sprite.flipX = false;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        velocity = Vector2.SmoothDamp(velocity, horizontalInput * maxSpeed * Vector2.right, ref currentVelocity, 1/ acceleration);

        transform.position += (Vector3)velocity * Time.deltaTime;

    }

}
