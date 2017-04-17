// BEGIN MIT LICENSE BLOCK //
//
// Copyright (c) 2016 dskjal
// This software is released under the MIT License.
// http://opensource.org/licenses/mit-license.php
//
// END MIT LICENSE BLOCK   //
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CarChaseCamera : MonoBehaviour {

    public float baseDistance = 5f;       // 停止時のカメラ―プレイヤー間の距離[m]
    public float baseCameraHeight = 2f;   // 停止時のカメラの高さ[m]
    public float chaseDamper = 3f;        // カメラの追跡スピード（追跡時のカメラ―プレイヤー間の距離がきまる）
    public Transform player;
    private Transform cam;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cam = GetComponent<Camera>().transform;
    }

    void FixedUpdate() {
        // カメラの位置を設定
        var desiredPos = player.position - player.forward * baseDistance + Vector3.up * baseCameraHeight;
        cam.position = Vector3.Lerp(cam.position, desiredPos, Time.deltaTime * chaseDamper);

        // カメラの向きを設定
        cam.LookAt(player);
        
        //cam.LookAt(Vector3.SmoothDamp(cam.position, player.position, velocity, lookChaseDamper));
    }
}