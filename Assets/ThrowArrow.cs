using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowArrow : MonoBehaviour {

    public Transform arrowPrefab;

    BowString bowString;
    Arrow arrow;

    public float offset = 0.5f;

    bool started = false;

    void Awake() {
        bowString = GetComponent<BowString>();
    }

    void Start() {

    }

    void Update() {

        Vector2 midPosition = (Vector3)bowString.MidPosition + transform.right * offset;

        if(Input.GetKeyDown(KeyCode.Mouse0) && !started) {
            arrow = Instantiate(arrowPrefab, midPosition, transform.rotation).GetComponent<Arrow>();
            started = true;
        }

        if(Input.GetKey(KeyCode.Mouse0)) {
            arrow.transform.position = midPosition;
            arrow.SetDirection(bowString.Direction);
        }

        if(Input.GetKeyUp(KeyCode.Mouse0)) {
            started = false;
            arrow.Throw(bowString.Direction);
        }
        

    }

}
