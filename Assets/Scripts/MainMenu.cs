using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SPV
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button homeButton;
        [SerializeField] private Button quitButton;

        private void OnEnable()
        {
            homeButton.onClick.AddListener(OnHomeButton);
            quitButton.onClick.AddListener(OnQuitButton);
        }

        private void OnDisable()
        {
            homeButton.onClick.RemoveListener(OnHomeButton);
            quitButton.onClick.RemoveListener(OnQuitButton);
        }

        private void OnHomeButton()
        {
            SceneManager.LoadScene("MainScene");
        }

        private void OnQuitButton()
        {
            Application.Quit();
        }
    }
}
