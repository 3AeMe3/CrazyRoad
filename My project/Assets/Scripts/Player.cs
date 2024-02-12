using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    Hope hope;
    private void Awake()
    {
        hope = GetComponent<Hope>();
    }
    private void Update()
    {
        if (hope.Ishopping)
        {
            return; 
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            hope.StartMove(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            hope.StartMove(Vector3.right);


        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            hope.StartMove(Vector3.forward);


        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            hope.StartMove(Vector3.back);

        }
    }
}
