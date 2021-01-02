using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public AnimationManager AnimationManager;
    private void Awake()
    {
        new CSVReader().Init();
    }
    IEnumerator MainThread()
    {


        yield break;
    }
    
}
