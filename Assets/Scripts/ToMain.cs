using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToMain : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Main"));
    }
}
