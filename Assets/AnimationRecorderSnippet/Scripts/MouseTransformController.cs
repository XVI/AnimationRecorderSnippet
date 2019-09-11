using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Transformをマウスの位置に追従させるためのコンポーネント
public class MouseTransformController : MonoBehaviour, IRecordableController
{
    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        var mousePosition = Input.mousePosition;
        var position =
            mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z));
        transform.position = position;
    }
}
