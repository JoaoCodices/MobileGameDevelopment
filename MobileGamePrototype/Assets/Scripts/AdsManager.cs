using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;

    void Awake()
    {
        InitializeAds();
    }
    public void InitializeAds()
    {
#if UNITY_IOS
            _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#elif UNITY_EDITOR
        _gameId = _androidGameId; //Only for testing the functionality in the Editor
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (/*scene.name == "IntroScene" ||*/ scene.name == "DeathScene")
        {
            Debug.Log("IntroScene");
            GetComponent<AdsBanner>().enabled = true;
        }
        else
        {
            GetComponent<AdsBanner>().enabled = false;
        }
    }
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "IntroScene" || scene.name == "DeathScene")
        {
            GetComponent<AdsBanner>().enabled = true;
        }
        else
        {
            GetComponent<AdsBanner>().HideBannerAd();
            GetComponent<AdsBanner>().enabled = false;
        }
    }
}
