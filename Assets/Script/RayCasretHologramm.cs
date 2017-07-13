using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasretHologramm : MonoBehaviour
{
    #region Enums
    #endregion

    #region Delegates
    #endregion

    #region Structures
    #endregion

    #region Classes
    #endregion

    #region Fields
    #endregion

    #region Events
    #endregion

    #region Properties
    #endregion

    #region Methods
    private void Update()
    {
        rayCaster();

    }
    private void rayCaster()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward, 1000f);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Collider Hit = hit.transform.GetComponent<Collider>();
            Debug.DrawRay(transform.position, Camera.main.transform.forward, Color.cyan);
            if (Hit)
            {
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
                return;
            }
        }
    }
    #endregion

    #region Event Handlers
    #endregion
}
