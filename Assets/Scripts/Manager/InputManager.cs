using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonMonoBehaviour<InputManager> {

    public KeyCode up;
    public KeyCode down;
    public KeyCode right;
    public KeyCode left;
    public KeyCode forward;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    /// <summary>
    /// キー入力処理
    /// </summary>
    /// <returns></returns>
    public Vector3 GetInput() {
        Vector3 input = Vector3.zero;
        if (Input.GetKey(up)) {
            input.y = 1;
        }
        if (Input.GetKey(down)) {
            input.y = -1;
        }
        if (Input.GetKey(right)) {
            input.x = 1;
        }
        if (Input.GetKey(left)) {
            input.x = -1;
        }
        if (Input.GetKey(forward)) {
            input.z = 1;
        }
        return input;
    }
}
