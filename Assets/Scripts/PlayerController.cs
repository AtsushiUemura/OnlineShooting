using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {



    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Move(InputManager.Instance.GetInput());
    }

    [SerializeField]
    private float moveSpeed;
    private bool Move(Vector2 input) {
        if (input == Vector2.zero) { return false; }
        Vector2 correctedInput = GetCorrectedInput(input);
        transform.localPosition += new Vector3(correctedInput.x, correctedInput.y, 0) * moveSpeed;
        return true;
    }

    /// <summary>
    /// 斜め移動修正
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private Vector2 GetCorrectedInput(Vector2 input) {
        if (input.x != 0 && input.y != 0) {
            return input * 0.71f;
        }
        return input;
    }

}
