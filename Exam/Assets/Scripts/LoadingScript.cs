using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    private  IEnumerator Loading()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }

    private void Update()
    {
        StartCoroutine(Loading());
        
    }
}
