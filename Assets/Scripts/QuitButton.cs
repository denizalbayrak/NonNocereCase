using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    [SerializeField] private Button quitButton;

    private void Start()
    {
        quitButton = GetComponent<Button>();
        quitButton.onClick.AddListener(QuitApplication);
    }

    private void QuitApplication()
    {
        Application.Quit();


#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
