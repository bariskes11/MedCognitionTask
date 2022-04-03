
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;

public class ViewerManager : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    GameObject connectingCanvas;
    [SerializeField]
    List<Patient> patients;
    #endregion
    #region Fields
    bool isConnected;
    #endregion

    #region Unity Methods
    private void Start()
    {
        
    }
    #endregion

    #region Private Methods
    void ListenEventsOnServer(int index, PanelType panelType)
    {

        Debug.Log($" Event Has Been Called {index} {panelType}");
        if (panelType == PanelType.SelectGenderPanel)
        {
            GameObject gmobj = Instantiate(patients[index].gameObject);
            gmobj.transform.position = Vector3.zero;
        }
    }
    void TryToJoinRoom()
    {
        StartCoroutine(TryToJoin());
    }
    IEnumerator TryToJoin()
    {
        while (!isConnected)
        {

         
            yield return new WaitForSeconds(1F);
        }

    }
    #endregion
}
