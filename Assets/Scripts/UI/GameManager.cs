// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class GameManager : MonoBehaviour
// {
//     protected static GameManager Instance; // singleton instance
//     public static GameManager instance{get => Instance;}
//     public float gameTime; // game time
//     public bool gameActive; // game active status
//     void Awake()
//     {
//         if (Instance != null && Instance != this)
//         {
//             Destroy(this);
//         }
//         else
//         {
//             Instance = this;
//         }
//     }
//     void Start()
//     {
//         gameActive = true; // set game active
//     }
//     void Update()
//     {
//         if (gameActive)
//         {
//             gameTime += Time.deltaTime; // increment game time
//             UIController.Instance.UpdateGameTime(gameTime); // update game time in UI

//             if (Input.GetKeyDown(KeyCode.Escape))
//             {
//                 Pause();
//             }
//         }

//     }
//     // Update is called once per frame
//     public void GameOver()
//     {
//         gameActive = false; // set game inactive
//         StartCoroutine(ShowGameOverPanel());
//     }
//     IEnumerator ShowGameOverPanel()
//     {
//         yield return new WaitForSeconds(1f);
//         UIController.Instance.GameOverPanel.SetActive(true);
//     }
//     public void RestartGame()
//     {
//         SceneManager.LoadScene("Game");
//     }
//     public void Pause()
//     {
//         if (UIController.Instance.PausePanel.activeSelf == false && UIController.Instance.GameOverPanel.activeSelf == false)
//         {
//             UIController.Instance.PausePanel.SetActive(true);
//             Time.timeScale = 0f; // pause the game
//         }
//         else
//         {
//             UIController.Instance.PausePanel.SetActive(false);
//             Time.timeScale = 1f; // resume the game
//         }
//     }
//     public void QuitGame()
//     {
//         Application.Quit(); // quit the game
//     }
//     public void GoToMainMenu()
//     {
//         SceneManager.LoadScene("MainMenu"); // load main menu scene
//     }
// }
