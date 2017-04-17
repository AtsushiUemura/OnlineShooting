using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    [SerializeField]
    private Animator animator;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Animation(InputManager.Instance.GetInput());
    }

    private Vector3 prePos;
    private void Animation(Vector2 input) {

        if (input.y == 1) {
            animator.SetBool("Wait", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);
        }
        if (input.y == -1) {
            animator.SetBool("Wait", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
        }
        if (input.x == 1) {
            animator.SetBool("Wait", false);
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }
        if (input.x == -1) {
            animator.SetBool("Wait", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", true);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }
        if (input == Vector2.zero) {
            animator.SetBool("Wait", true);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }
    }
}
