using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public void Move(Vector2 coordinate, Vector2 targetCoordinate, Action callback)
    {
        Set();
        StartCoroutine(Move());

        void Set()
        {
            transform.rotation = targetCoordinate.x < coordinate.x ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
            transform.position = coordinate;
        }

        IEnumerator Move()
        {
            float speed = UnityEngine.Random.Range(0.7f, 1.2f);
            var startTime = Time.time;
            var distance = Vector2.Distance(coordinate, targetCoordinate);
            while (Vector2.Distance(transform.position, targetCoordinate) > 0.01)
            {
                transform.position = Vector2.Lerp(
                    coordinate,
                    targetCoordinate,
                    (startTime - Time.time) * speed / distance
                    );
                yield return null;
            }
            callback();
            Destroy(gameObject);
        }
    }
}

