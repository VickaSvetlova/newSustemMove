using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotPosition : MonoBehaviour
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
    private LineRenderer lineRender;
    #endregion

    #region Events
    #endregion

    #region Properties
    #endregion

    #region Methods
    private void Start()
    {
        lineRender = GetComponent<LineRenderer>();
    }
    public void lineCaster(Vector3 spotActualFloor, Vector3 goFloor)
    {
        return;
        lineRender.SetPosition(0, spotActualFloor);
        lineRender.SetPosition(1, goFloor);
        lineRender.SetPosition(2, goFloor);
        lineRender.SetPosition(3, goFloor);
    }
    #endregion

    #region Event Handlers
    #endregion
}
