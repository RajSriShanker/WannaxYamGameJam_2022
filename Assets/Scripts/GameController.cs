using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerRuneSelection playerRuneSelectionScript;
    public CthulhuManager chulhuManagerScript;
    public ColourChange[] colourChangeScript;

    public GameObject winImage;
    public GameObject loseImage;

    [SerializeField]
    private int pointsCounter = 0;
    [SerializeField]
    private int missCounter = 0;

    AudioSource audioSource;
    public AudioClip runeMatch;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsCounter > 10)
        {
            GameWin();
        }

        if (missCounter > 10)
        {
            GameLose();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            MenuSceneChange();
        }
    }

    public void RuneMatch()
    {
        if (playerRuneSelectionScript.conveyorRune == playerRuneSelectionScript.playerRune)
        {
            Debug.Log("1 Point");
            colourChangeScript[0].StartChange();
            colourChangeScript[1].StartChange();
            pointsCounter++;
            audioSource.PlayOneShot(runeMatch);
        }
        else
        { 
            missCounter++;
            Debug.Log("Miss");
        }
    }

    private void GameWin()
    {

        Debug.Log($"YOU WON THE GAME");
        chulhuManagerScript.DeadHead();
        winImage.SetActive(true);
        StartCoroutine(PauseGame());

    }

    private void GameLose()
    {
        Debug.Log($"YOU LOST :((((((((");
        chulhuManagerScript.EvilWins();
        loseImage.SetActive(true);
        StartCoroutine(PauseGame());
    }

    private void MenuSceneChange()
    {
        SceneManager.LoadScene("MenuScene");
    }

    IEnumerator PauseGame()
    {
        yield return new WaitForSeconds(5f);
        MenuSceneChange();
    }
}
