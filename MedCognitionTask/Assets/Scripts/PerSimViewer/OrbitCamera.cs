using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class OrbitCamera : MonoBehaviour
{
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
    #region Fields
    float rotationY;
    float rotationX;
    Vector3 currentRotation;
    Vector3 smoothVelocity = Vector3.zero;
    Camera cam;
    float fov;
    #endregion
    #region Unity Methods

    private void Start()
    {
        cam = Camera.main;
        fov = cam.fieldOfView;
    }
    void Update()
    {
        if (!Input.GetMouseButton(0)) { return; }
        this.OrbitAction();
        this.SetZoomInOut();
    }
    private void SetZoomInOut()
    {
        fov += Input.GetAxis("Mouse ScrollWheel") * scroolSensivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        cam.fieldOfView = fov;
    }
    #endregion

    private void OrbitAction()
    {
        rotationY += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        Vector3 nextRotation = new Vector3(rotationX, rotationY);
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
        transform.localEulerAngles = currentRotation;
        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}