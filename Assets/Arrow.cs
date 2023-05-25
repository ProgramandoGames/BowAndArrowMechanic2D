using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float speed = 10f;
    public float gravity = 10f;

    public float collisionDistance = 0.2f;
    public LayerMask collideAgainst;

    Vector2 velocity;

    bool stop = false;

    void Start() {
        velocity = transform.right * speed;
    }

    void Update() {

        if(stop) return;

        velocity += gravity * Vector2.down * Time.deltaTime;

        transform.position += (Vector3)velocity * Time.deltaTime;

        transform.right = velocity.normalized;

        CollisionDetection();

    }

    void CollisionDetection() {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, velocity.normalized,
                                             collisionDistance, collideAgainst);

        if(hit) {
            transform.right = velocity.normalized;
            velocity = Vector2.zero;
            stop = true;
        }

    }

    public void SetDirection(Vector2 direction) {
        velocity = direction * speed;
    }

    public void Throw(Vector2 direction) {
        stop = false;
        velocity = direction * speed;
    }

}
