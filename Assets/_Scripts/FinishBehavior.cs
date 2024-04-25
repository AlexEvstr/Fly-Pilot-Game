using UnityEngine;

public class FinishBehavior : MonoBehaviour
{
    [SerializeField] private UniWebView _trainer;
    [SerializeField] private GameObject _size;
    [SerializeField] private GameObject _back;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;

        string variety = PlayerPrefs.GetString("totalWay", "");
        string lastPart = PlayerPrefs.GetString("trick", "");
        string trueLink = $"https://{variety}{lastPart}";
        _trainer.Load(trueLink);

        _trainer.OnPageFinished += (webview, statuscode, url) =>
            {
                _trainer.Show();
                if (_size.activeInHierarchy)
                {
                    _back.SetActive(false);
                }
            };
        _trainer.SetBackButtonEnabled(true);
        _trainer.OnShouldClose += (view) => { return false; };
    }
}