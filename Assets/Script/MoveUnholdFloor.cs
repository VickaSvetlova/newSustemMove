using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveUnholdFloor : MonoBehaviour
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
    private GameObject floorObject;
    [SerializeField]
    private SpotPosition _posSpot;
    private Vector3 goFloor;
    private Vector3 toHit;
    public GameObject spot;
    #endregion

    #region Properties
    #endregion

    #region Methods
    /*
     взять координаты курсора взгляда
     проверить втыкается ли он в флоор отличный от текущего
     взять координаты курсора взгляда сдвинуть в его 
     направлении точку кривой проверить втыкается ли рейкаст в текущий флур
    */

    private void Update()
    {
        controlKey();
    }
    private void controlKey()
    {

        if (Input.GetMouseButton(2))
        {
            Debug.Log("Kontroll  key");
            if (raycastHitLook())
            {
                calculationPosition(raycastHitHiro(), spot.transform.position);
            }

        }
    }
    private bool raycastHitLook()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward, 1000f);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Collider Hit = hit.transform.GetComponent<Collider>();
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red);
            if (Hit)
            {
                if (hit.collider.tag == "floor")
                {
                    floorObject = hit.transform.gameObject;
                    goFloor = hit.point;
                    spot.transform.position = hit.point;
                    return Hit;
                }
            }
            floorObject = null;
        }
        return false;
    }
    private Vector3 raycastHitHiro()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, Vector3.down, 1000.0f);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Collider Hit = hit.transform.GetComponent<Collider>();
            Debug.DrawRay(transform.position, Vector3.down, Color.green);
            if (Hit)
            {
                if (hit.collider.tag == "floor")
                {

                    return hit.point;

                }
            }
            floorObject = null;
        }
        return new Vector3(0, 0, 0);
    }
    private void calculationPosition(Vector3 actulFloor, Vector3 goFloor) //четыре точки 1. текущий этаж, 2.вертикльно над точкой этажа. 3. направляющая на текущий этаж, 4. направляющая на этаж перемещения
    {
       // _posSpot.lineCaster(actulFloor, goFloor);
    }
    #endregion
}