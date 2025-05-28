using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private Image PFPLogo;
    [SerializeField] private TextMeshProUGUI DevName;

    private void Awake()
    {
        Color newColour = PFPLogo.color;
        newColour.a = 0f;
        PFPLogo.color = newColour;
        DevName.color = newColour;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {
        // changes alpha value of logo
        if (PFPLogo.color.a < 246)
        {
            Color newColour = PFPLogo.color;
            newColour.a += 0.001f;
            PFPLogo.color = newColour;
            DevName.color = newColour;
        }

        StartCoroutine(Wait());
    }
}
