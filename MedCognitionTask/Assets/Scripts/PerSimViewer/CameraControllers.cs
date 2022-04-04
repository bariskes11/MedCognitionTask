using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllers : MonoBehaviour
{
    #region Fields
    Camera cam;
    bool isconnectionready;
    IPatient currentPatient;
    #endregion
    #region Unity Methods
    private void Start()
    {
        cam = Camera.main;
    }


    private void Update()
    {
        if (!this.isconnectionready)
            return;
        cam.transform.LookAt(this.currentPatient.Transform);
        

    }
    #endregion
    #region Public Methods
    public void SetConnection(IPatient patient)
    {
        this.isconnectionready = true;
        this.currentPatient = patient;
    }
    #endregion


}
