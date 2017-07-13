using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloorToTap : MonoBehaviour
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
    private Vector3 hitTo;
    [SerializeField]
    private GameObject spotPatch;
    private GameObject spotOld = null;
    public GameObject _stage;


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
            if (Input.GetMouseButton(1))
            {
                getFloor();
            }
        }
    }
    private void getFloor()
    {

        if (rayCaster(Vector3.forward))
        {
            CalculateMove(floorObject);
        }
    }
    private void CalculateMove(GameObject floorObject)
    {
       floorIgnore = floorObject.name;
        float HeightHiro = GetComponentInChildren<Collider>().transform.localScale.y/2;
        float HeightFloor = floorObject.GetComponent<Collider>().transform.localScale.y/2;
        //SpotPosition = new Vector3(hitTo.x, floorObject.transform.position.y+HeightFloor + HeightHiro, hitTo.z);
        SpotPosition = _stage.transform.position + transform.position - new Vector3(hitTo.x, floorObject.transform.position.y + HeightFloor + HeightHiro, hitTo.z);
        instatientPatchSpot(spotPatch);

        _move = true;
    }
    private void instatientPatchSpot(GameObject spot_pach)
    {
        spotPatch.transform.position = SpotPosition;
        spotPatch.transform.LookAt(new Vector3(transform.position.x,spotPatch.transform.position.y,transform.position.z));
        spotOld = spotPatch;
    }
    private bool rayCaster(Vector3 dir)
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward, 1000f);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Collider Hit = hit.transform.GetComponent<Collider>();
            Debug.DrawRay(transform.position, Camera.main.transform.forward, Color.red);
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


