using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonMonoBehaviour<InputManager> {

    public KeyCode up;
    public KeyCode down;
    public KeyCode right;
    public KeyCode left;

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
    public Vector2 GetInput() {
        Vector2 input = Vector2.zero;
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
        return input;
    }
}
