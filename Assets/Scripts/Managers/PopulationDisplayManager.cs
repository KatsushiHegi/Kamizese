using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationDisplayManager : MonoBehaviour
{
    [SerializeField] PrefectureManager PrefectureManager;
    
    private void Start(){
        Debug.Log("あおもりのひと"+PrefectureManager.prefectureControllers[1].prefecture.population);
    }
}
