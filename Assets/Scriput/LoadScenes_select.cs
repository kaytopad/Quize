using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ここを追加
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController:MonoBehaviour
{
    //ボタンををクリックするとScene「Story」へ遷移
    public void ButtonClick()
    {
        SceneManager.LoadScene("Story");
    }
}