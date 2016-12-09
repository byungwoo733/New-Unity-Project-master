using UnityEngine;
using System.Collections;

public class MovingPoint : MonoBehaviour {

    Vector3 movingPoint;
    public float moveTime = 2f;

    void Start()
    {
        InvokeRepeating("MovePoint", 0, moveTime);
    }

    void MovePoint()
    {
        if (GameManager.Instance.isGameStop) return;

        movingPoint.x = Random.Range(-4f, 4f);
        movingPoint.y = 0;
        movingPoint.z = Random.Range(-4f, 4f);

        transform.position =  movingPoint;
    }

}
