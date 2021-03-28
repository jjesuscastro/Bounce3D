using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public GameObject miniMap;
    public Transform player;
    public float zoomAmount = 5f;
    public float zoomSpeed = 0.2f;

    Camera miniCamera;
    float defaultZoom;
    bool _zoom;
    bool zoomedIn;
    bool _toggleMiniMap;

    void Awake()
    {
        miniCamera = GetComponent<Camera>();
        defaultZoom = miniCamera.orthographicSize;
    }

    void Update()
    {
        GetInputs();
    }

    void FixedUpdate()
    {
        if (_zoom)
        {
            if (!zoomedIn)
            {
                miniCamera.orthographicSize -= zoomSpeed;

                if (miniCamera.orthographicSize <= zoomAmount)
                {
                    _zoom = false;
                    zoomedIn = true;
                }
            }
            else
            {
                miniCamera.orthographicSize += zoomSpeed;

                if (miniCamera.orthographicSize >= defaultZoom)
                {
                    _zoom = false;
                    zoomedIn = false;
                }
            }
        }

        if (_toggleMiniMap)
        {
            if (miniMap.activeInHierarchy)
                miniMap.SetActive(false);
            else
                miniMap.SetActive(true);

            _toggleMiniMap = false;
        }
    }

    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }

    void GetInputs()
    {
        if (InputCheck.isInputEnabled)
        {
            if (Input.GetAxisRaw("Zoom") > 0)
                _zoom = true;

            if (Input.GetKeyDown(KeyCode.M))
                _toggleMiniMap = true;
        }
    }
}
