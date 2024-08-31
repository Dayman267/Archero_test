using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 120;
    }
}
