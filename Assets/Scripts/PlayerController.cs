using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {


    [SerializeField]
    private GameObject sceneCamera;
    [SerializeField]
    private float smoothing;

    #region
    // Use this for initialization
    void Start() {
        if (isLocalPlayer) {
            sceneCamera.GetComponent<Camera>().enabled = true;
            sceneCamera.GetComponent<AudioListener>().enabled = true;
            sceneCamera.transform.parent = null;
        }
    }
    // Update is called once per frame
    void Update() {
        if (isLocalPlayer) {
            Move(InputManager.Instance.GetInput());
            //Shot(Vector3.zero, 0.1f);
            Escape();
        }
    }
    #endregion

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Vector3 offset;
    private bool Move(Vector3 input) {
        if (input == Vector3.zero) { return false; }
        Vector3 correctedInput = GetCorrectedInput(input);
        transform.localPosition += new Vector3(correctedInput.x, correctedInput.y, correctedInput.z) * moveSpeed;
        return true;
    }

    /// <summary>
    /// 斜め移動修正
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private Vector3 GetCorrectedInput(Vector3 input) {
        if (input.x != 0 && input.y != 0) {
            Vector3 correctedInput = new Vector3(input.x * 0.71f, input.y * 0.71f, input.z);
            return correctedInput;
        }
        return input;
    }

    [SerializeField]
    private GameObject[] bullet;
    [SerializeField]
    private float distance;
    private void Shot(Vector3 pos, float deray) {
        if (Input.GetKey(KeyCode.Space) && !isDeray) {
            StartCoroutine(Deray(deray));
        }
    }
    private bool isDeray;
    private IEnumerator Deray(float deray) {
        isDeray = true;
        var clone = Instantiate(bullet[0], transform.localPosition, Quaternion.identity);
        yield return new WaitForSeconds(deray);
        isDeray = false;
    }

    private void Escape() {
        if (Input.GetKeyDown(KeyCode.E)) {
            StartCoroutine(Rolling());
        }
    }

    private bool isRolling;
    private IEnumerator Rolling() {
        if (isRolling) { yield break; }
        isRolling = true;
        bool flag = false;
        while (!flag) {
            if (Mathf.DeltaAngle(transform.eulerAngles.z, 360) < -0.1f) {
                transform.Rotate(new Vector3(0f, 0f, 5f));
            }
            yield return null;
        }
        isRolling = false;
    }
}
