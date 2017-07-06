using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    #region Enum
    private enum _direction { up, down }
    private _direction direct;
    #endregion


    #region Deligates
    #endregion

    #region Propertes
    #endregion

    #region Fields
    private bool _move = false;
    public bool Hit { get; private set; }
    private GameObject floorObject = null;
    private Vector3 newSpotPositio;
    private GameObject heigtHiro;
    private string floorIgnore = null;
    #endregion

    #region Events
    #endregion

    #region Metods
    private void Update()
    {
        if (!_move)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                getFloor(_direction.up);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                getFloor(_direction.down);

            }
        }
    }
    private void getFloor(_direction dir)
    {
        switch (dir)
        {
            case _direction.up:
                if (rayCaster(Vector3.up))
                {
                    CalculateMove(floorObject);
                }
                break;
            case _direction.down:
                if (rayCaster(Vector3.down))
                {
                    CalculateMove(floorObject);
                }
                break;
        }
    }
    private void CalculateMove(GameObject floorObject)
    {
        floorIgnore = floorObject.name;
        Debug.Log("floorIgnore " + floorIgnore);
        float HeightHiro = GetComponent<Collider>().transform.localScale.y / 2;
        float HeightFloor = floorObject.GetComponent<Collider>().transform.localScale.y / 2;
        Vector3 SpotPosition = new Vector3(0, floorObject.transform.position.y + HeightFloor + HeightHiro, 0);
        transform.position = SpotPosition;
    }
private bool rayCaster(Vector3 dir)
{
    RaycastHit[] hits;
    hits = Physics.RaycastAll(transform.position, dir, 100.0f);
    for (int i = 0; i < hits.Length; i++)
    {
        RaycastHit hit = hits[i];
        Collider Hit = hit.transform.GetComponent<Collider>();
        Debug.DrawRay(transform.position, dir, Color.green);
        if (Hit)
        {
            if (hit.collider.tag == "floor" && hit.collider.gameObject.name != floorIgnore)
            {
                floorObject = hit.collider.gameObject;
                return Hit;
            }
        }
        floorObject = null;
    }
    return false;
}
    #endregion
}


