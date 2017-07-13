using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloorLift : MonoBehaviour
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
    private Vector3 SpotPosition;
    private bool _moveCorutine = false;
    public GameObject _stage;
    private Vector3 hitTo;


    #endregion

    #region Events
    #endregion

    #region Metods
    private void Update()
    {
        controlKeys();
        controllMove();
    }

    private void controllMove()
    {
        if (!_moveCorutine && _move)
        {
            StartCoroutine(moveToPosition(_stage.transform.position, SpotPosition));
            _moveCorutine = true;
        }
    }

    private IEnumerator moveToPosition(Vector3 v1, Vector3 v2)//корутина плавного изменения позиции
    {
        float timer = 0f;
        float maxTime = 1.5f;
        while (timer < maxTime)
        {
            float coeff = timer / maxTime;
           _stage.transform.position = Vector3.Lerp(v1, v2, timer);
            timer += Time.deltaTime;
            yield return null;
        }
       
        _move = false;
        _moveCorutine = false;
       
    }
    private void controlKeys()//команды управления.
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
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -2, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 2, 0);
            }
            if (Input.GetMouseButton(0))
            {
                transform.Translate(Vector3.forward*Time.deltaTime*5);

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
       // Debug.Log("floorIgnore " + floorIgnore);
        float HeightHiro = GetComponentInChildren<Collider>().transform.localScale.y/2;
        float HeightFloor = floorObject.GetComponent<Collider>().transform.localScale.y/2;
        //SpotPosition = new Vector3(transform.position.x, floorObject.transform.position.y+HeightFloor + HeightHiro, transform.position.z);
        SpotPosition =_stage.transform.position+transform.position-new Vector3(hitTo.x, floorObject.transform.position.y + HeightFloor + HeightHiro,hitTo.z);
        //transform.position = SpotPosition;
        _move = true;
    }
    private bool rayCaster(Vector3 dir)
    {     
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, dir, 1000.0f);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Collider Hit = hit.transform.GetComponent<Collider>();
            Debug.DrawRay(transform.position, dir, Color.green);
            if (Hit)
            {
                if (hit.collider.tag == "floor" && hit.collider.gameObject.name != floorIgnore)
                {
                    floorObject = hit.transform.gameObject;
                    hitTo = hit.point;
                    return Hit;
                }
            }
            floorObject = null;
        }
        return false;
    }
    #endregion
}


