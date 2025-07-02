using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrHandler : MonoBehaviour
{
    public GameObject[] Instructions;
    public int InstructionCount = 1;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("ThemeController").GetComponent<ThemeController>().UpdateTheme(PlayerPrefs.GetInt("theme", -1));
        UpdateInstr();
    }

    public void UpdateInstr()
    {
        for (int i = 0; i < Instructions.Length; i++)
        {
            Instructions[i].SetActive(false);
        }
        Instructions[InstructionCount].SetActive(true);
    }
}
