using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Viewer Controller Mechanics Zoom in Zoom out and rotate around to patient
/// </summary>
[RequireComponent(typeof(Camera))]
public class OrbitCamera : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    float mouseSensitivity = 3.0f;
    [SerializeField]
    float scroolSensivity = 4F;
    [SerializeField]
    float minFov;
    [SerializeField]
    float maxFov;
    [SerializeField]
    Transform target;
    [SerializeField]
    float smoothTime = 0.2f;
    [SerializeField]
    float distanceFromTarget = 3.0f;
    #endregion
    #region Fields
    float rotationY;
    float rotationX;
    Vector3 currentRotation;
    Vector3 nextRotation;
    Vector3 smoothVelocity = Vector3.zero;

    Camera cam;
    float fov;
    #endregion
    #region Unity Methods
    private void Start()
    {
        cam = Camera.main;
        fov = cam.fieldOfView;
        //initial distance
        OrbitAction();
    }
    void Update()
    {
        this.SetZoomInOut();
        if (!Input.GetMouseButton(0)) { return; }
        this.OrbitAction();
    }
    private void SetZoomInOut()
    {
       this.fov -= Input.GetAxis("Mouse ScrollWheel") * scroolSensivity;
       this.fov = Mathf.Clamp(fov, minFov, maxFov);
       this.cam.fieldOfView = fov;
    }
    #endregion
    private void OrbitAction()
    {
        this.rotationY += Input.GetAxis("Mouse X") * mouseSensitivity;
        this.rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        this.nextRotation = new Vector3(rotationX, rotationY);
        this.currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
        transform.localEulerAngles = currentRotation;
        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}