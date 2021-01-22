using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public void Move(Vector2 coordinate,Vector2 targetCoordinate, Action callback)
    {
        Set();
        StartCoroutine(Move());

        void Set()
        {
            coordinate.x += UnityEngine.Random.Range(-20, 20);
            coordinate.y += UnityEngine.Random.Range(-20, 20);
            targetCoordinate.x += UnityEngine.Random.Range(-20, 20);
            targetCoordinate.y += UnityEngine.Random.Range(-20, 20);
            transform.rotation = targetCoordinate.x < coordinate.x ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
            transform.localPosition = coordinate;
        }
        
        IEnumerator Move()
        {
            float startTime = Time.time;
            float speed = UnityEngine.Random.Range(30, 50);
            var distance = Vector2.Distance(coordinate, targetCoordinate);
            while (Vector2.Distance(transform.localPosition, targetCoordinate) > 0.01)
            {
                transform.localPosition = Vector2.Lerp(
                    coordinate,
                    targetCoordinate,
                    (Time.time-startTime) * speed / distance
                    );
                yield return null;
            }
            callback();
            Destroy(gameObject);
        }
    }
}

