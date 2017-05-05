using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerControler : NetworkBehaviour {

    public Camera sceneCamera;
    public GameObject Player;
    public GameObject wall_Left;
    public GameObject wall_Right;
    public GameObject wall_Bottom;
    public GameObject wall_Top;

    bool MoveRight;
    bool MoveLeft;

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

        if (Input.GetKey(KeyCode.RightArrow)) {
            MoveRight = true;
            MoveLeft = false;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            MoveLeft = true;
            MoveRight = false;
        } else {
            MoveRight = false;
            MoveLeft = false;
        }
        Player.transform.position = (new Vector3(Mathf.Clamp(Player.transform.position.x, wall_Left.transform.position.x, wall_Right.transform.position.x),
                Mathf.Clamp(Player.transform.position.y, wall_Bottom.transform.position.y, wall_Top.transform.position.y),
                Player.transform.position.z));

    }
    void FixedUpdate() {

        if (MoveRight) {
            Player.GetComponent<Rigidbody>().velocity = (transform.up * 2);
            Player.transform.Rotate(new Vector3(0, 0, -5));
        } else if (MoveLeft) {
            Player.GetComponent<Rigidbody>().velocity = (transform.up * 2);
            Player.transform.Rotate(new Vector3(0, 0, 5));
        } else {
            Player.GetComponent<Rigidbody>().velocity = (transform.up * 0);
        }
    }
}