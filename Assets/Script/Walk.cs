using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour 
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
    public GameObject _scene;
    public GameObject spot;

    #endregion

    #region Events

    #endregion

    #region Properties
    #endregion

    #region Methods
    private void Start()
    {
        teleport();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //_scene.transform.position = new Vector3(_scene.transform.position.x, _scene.transform.position.y, _scene.transform.position.z+Time.deltaTime*5);
            //_scene.transform.Translate(Vector3.forward * Time.deltaTime * 5);
            _scene.transform.Translate(transform.forward * -Time.deltaTime * 5, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _scene.transform.RotateAround(transform.position, transform.up, 50 * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            _scene.transform.RotateAround(transform.position, transform.up, -50 * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //StartCoroutine(moveToPosition(_scene.transform.position,spot.transform.position));
            teleport();
            
        }
     
    }
    private void teleport()
    {
        //float dictance = Vector3.Distance(new Vector2(transform.position.x,transform.position.y), new Vector2(spot.transform.position.x, spot.transform.position.y));
        //_scene.transform.localPosition = new Vector3(_scene.transform.position.x + dictance, 0, _scene.transform.position.z + dictance);
        


       // _scene.transform.position = newPosition;
    }

    private IEnumerator moveToPosition(Vector3 v2, Vector3 v1)//корутина плавного изменения позиции
    {
        float timer = 0f;
        float maxTime = 10000f;
        while (timer < maxTime)
        {
            float coeff = timer / maxTime;
            //_scene.transform.position = Vector3.Lerp(v2, v1, timer);
           // _scene.transform.Translate(spot.transform.position);
            timer += Time.deltaTime;
            yield return null;
        }
    }
    #endregion

    #region Event Handlers
    #endregion
}
