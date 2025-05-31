using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SPV
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject settingPanel;
        [SerializeField] private Button settingButton;
        [SerializeField] private Button homeButton;
        [SerializeField] private Button quitButton;

        private bool isSettingsOpen = false;

        private void OnEnable()
        {
            settingButton.onClick.AddListener(OnSettingButton);
            homeButton.onClick.AddListener(OnHomeButton);
            quitButton.onClick.AddListener(OnQuitButton);
        }

        private void OnDisable()
        {
            settingButton.onClick.RemoveListener(OnSettingButton);
            homeButton.onClick.RemoveListener(OnHomeButton);
            quitButton.onClick.RemoveListener(OnQuitButton);
        }

        private void OnSettingButton()
        {
            isSettingsOpen = !isSettingsOpen;
            settingPanel.SetActive(isSettingsOpen);
        }

        private void OnHomeButton()
        {
            SceneManager.LoadScene("MainMenu");
        }

        private void OnQuitButton()
        {
            Application.Quit();
        }
    }
}
