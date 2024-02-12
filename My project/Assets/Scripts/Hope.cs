using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Hope : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField] float speed;

    [Range(0, 5)]
    [SerializeField] float distance;
    [Range(0,5)]
    [SerializeField] float height;

    [SerializeField] bool rotation;

    public bool Ishopping { get; private set; }


    public void StartMove(Vector3 direction)
    {
        Ishopping = true;
        if (rotation)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
        Vector3 targetPos = transform.position + direction * distance;
        StartCoroutine(Move(targetPos));
    }
    IEnumerator Move(Vector3 targetPos)
    {
        Vector3 startPos = transform.position;
        float movePorcentage = 0;
        while (movePorcentage <= 1.0f)
        {
            movePorcentage += speed * Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, targetPos, movePorcentage);

            //jumping
            float jumpPercentage = CalculateJumpPercentage(movePorcentage);
            transform.position = new Vector3(transform.position.x, startPos.y + jumpPercentage * height, transform.position.z);

            yield return null;
        }
        transform.position = targetPos;
        Ishopping = false;
    }
    float CalculateJumpPercentage(float movePercentage)
    {
        float jumpPercentage = movePercentage * 2;
        return Mathf.Lerp(0,1, -jumpPercentage * jumpPercentage + 2 * jumpPercentage);
    }

}
