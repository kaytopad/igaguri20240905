using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        GameManager.Instance.StartGame();
    }
}
