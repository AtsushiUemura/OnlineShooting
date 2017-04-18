using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeaponController : NetworkBehaviour {

    [SerializeField]
    private GameObject[] unit;

    private Vector3[] offset = new Vector3[2];
    // Use this for initialization
    void Start() {
        offset[0] = unit[0].transform.localPosition - transform.localPosition;
        offset[1] = unit[1].transform.localPosition - transform.localPosition;

    }

    // Update is called once per frame
    void Update() {
        if (isLocalPlayer) {
            unit[0].transform.localPosition = transform.localPosition + offset[0];
            unit[1].transform.localPosition = transform.localPosition + offset[1];
        }
    }

    private void Shot() {

    }
}
