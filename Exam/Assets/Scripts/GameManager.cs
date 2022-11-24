using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool HasKey;
    public KeyCode Escape;
    public GameObject MainMenu;
    public GameObject keyText;
    public KeyScript keyScript;
    
    
    private void Start()
    {
        
        HasKey = false;
    }

    private void Update()
    {
        if (Input.GetKey(Escape))
        {
            MainMenu.SetActive(true);            
        }

        if (keyScript.KeyText == true)
        {
            keyText.SetActive(true);
            StartCoroutine(Text());
        }
    }

    private IEnumerator Text()
    {
        yield return new WaitForSeconds(2f);
        keyText.SetActive(false);
        keyScript.KeyText = false;

    }
}
