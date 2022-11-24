using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraOrthoZoom : MonoBehaviour
{
    private CinemachineVirtualCamera _virtCam = null;
    private float _defaultOrthoZoom = 0;
    private int _zoomLevel = 0;
    void Start()
    {
        _virtCam = gameObject.GetComponent<CinemachineVirtualCamera>();
        _defaultOrthoZoom = _virtCam.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            _zoomLevel = Mathf.Clamp(Input.mouseScrollDelta.y > 0 ? --_zoomLevel : ++_zoomLevel, -3, +12);
            _virtCam.m_Lens.OrthographicSize = _defaultOrthoZoom + (_defaultOrthoZoom * 0.25f * _zoomLevel);
        }
    }
}
