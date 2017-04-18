using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraController : NetworkBehaviour {

    [SerializeField]
    private GameObject target;
    private Vector3 offset;
    public float smoothing;

    // Use this for initialization
    void Start() {
        offset = transform.localPosition - target.transform.localPosition;
    }

    void FixedUpdate() {
        Vector3 targetCamPos = target.transform.localPosition + offset;
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetCamPos, smoothing * Time.deltaTime);
    }

}
