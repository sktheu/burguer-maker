using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRestart : MonoBehaviour
{
    [Header("Referências:")] 
    [SerializeField] private GameObject fadeIn;
    [SerializeField] private AudioManager audioManager;

    public void Restart(float t)
    {
        audioManager.PlaySFX("button 1");
        fadeIn.SetActive(true);
        Invoke("LoadLevel", t);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
