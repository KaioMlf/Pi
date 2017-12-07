using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    public Text endTime_txt;

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleEndMenu(float timer)
    {
        gameObject.SetActive(true);
        endTime_txt.text = ((int)timer).ToString();
    }

    public void Restar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
