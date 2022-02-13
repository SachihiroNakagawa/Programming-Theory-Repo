using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleHandler : MonoBehaviour
{
    public void StartGeme()
    {
        SceneManager.LoadScene(1);
    }
}
