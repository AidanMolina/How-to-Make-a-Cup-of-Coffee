using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoticeButton : MonoBehaviour
{
    void Start(){
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnButtonPressed(){
        SceneManager.LoadScene(2);
    }
}
