using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition2 : MonoBehaviour
{

    private float speed = 15f;

    private void Start()
    {
        transform.Rotate(0f, 0f, -90f);
    }

    private void Update()
    {

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
