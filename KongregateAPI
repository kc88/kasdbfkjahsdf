using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class KongregateAPI :MonoBehaviour
{
    static public KongregateAPI instance;

    public int userID;
    public string userName;
    public string userAuth;

    public GameObject earnAdCoinButton;
    private bool adsAvalable;

    public Text somethingOutput;

    private void Start()
    {
        gameObject.name = "KongregateAPI";
        instance = this;

        earnAdCoinButton.GetComponent<Button>().interactable = true;

        Application.ExternalEval(
            "if(typeof(kongregateUnitySupport) != 'undefined'){" +
            "    kongregateUnitySupport.initAPI('KongregateAPI', 'OnKongregateAPILoaded');" +
            "};"
        );
        somethingOutput.text = "Start();";
    }

    public void Submit(string name, int value)
    {
        Application.ExternalCall("kongregate.stats.submit", name, value);
    }

    public void OnKongregateAPILoaded(string userInfoString)
    {
        OnKongregateUserInfo(userInfoString);
        GameManager.instance.APICallBack("Kong Access!");
        somethingOutput.text = "OnKongregateAPILoaded();";
        // adsAvailable
        Application.ExternalEval(
            "kongregate.mtx.addEventListener('adsAvailable', function(){" +
            "   kongregateUnitySupport.getUnityObject().SendMessage('KongregateAPI', 'adsAvailable', params);" +
            "});"
        );

        // adsUnavailable
        Application.ExternalEval(
            "kongregate.mtx.addEventListener('adsUnavailable', function(){" +
            "   kongregateUnitySupport.getUnityObject().SendMessage('KongregateAPI', 'adsUnavailable', params);" +
            "});"
        );

        // adOpened
        Application.ExternalEval(
            "kongregate.mtx.addEventListener('adOpened', function(){" +
            "   kongregateUnitySupport.getUnityObject().SendMessage('KongregateAPI', 'adOpened', params);" +
            "});"
        );

        // adCompleted
        Application.ExternalEval(
            "kongregate.mtx.addEventListener('adCompleted', function(){" +
            "   kongregateUnitySupport.getUnityObject().SendMessage('KongregateAPI', 'adCompleted', params);" +
            "});"
        );
        // adAbandoned
        Application.ExternalEval(
            "kongregate.mtx.addEventListener('adAbandoned', function(){" +
            "   kongregateUnitySupport.getUnityObject().SendMessage('KongregateAPI', 'adAbandoned', params);" +
            "});"
        );
        // initializeIncentivizedAds
        Application.ExternalEval(
            "if(typeof(kongregateUnitySupport) != 'undefined'){ kongregate.mtx.initializeIncentivizedAds(); };"
        );
        somethingOutput.text = "initializeIncentivizedAds();";
        InvokeRepeating("UpdateCheckAdsAvalable", 5f, 5f);
    }

    public void OnKongregateUserInfo(string userInfoString)
    {
        string[] info = userInfoString.Split('|');
        userID = int.Parse(info[0]);
        userName = info[1];
        userAuth = info[2];
        Debug.Log("Kongregate User Info: " + userName + ", userId: " + userID);
    }

    #region KongregateAds

    private void Update()
    {
        if (adsAvalable == true)
            earnAdCoinButton.GetComponent<Button>().interactable = true;
        else// if(earnAdCoinButton.GetComponent<Button>().IsInteractable())
            earnAdCoinButton.GetComponent<Button>().interactable = false;
    }

    public void EarnAdCoinsClick()
    {
        //GameManager.instance.GetPlayerStat().AdCoins += 1;
        ShowAd();
    }

    public void ShowAd()
    {
        somethingOutput.text = "kongregate.mtx.showIncentivizedAd();";
        Application.ExternalEval(
            "if(typeof(kongregateUnitySupport) != 'undefined'){ kongregate.mtx.showIncentivizedAd(); };"
        );
    }

    public void adsAvailable()
    {
        adsAvalable = true;
        somethingOutput.text = "adsAvailable();";
    }

    public void adsUnavailable()
    {
        adsAvalable = false;
        somethingOutput.text = "adsUnavailable();";
    }

    public void adOpened()
    {
        SoundsManager.instance.ToggleSoundPause();
        somethingOutput.text = "adOpened();";
    }

    public void adCompleted()
    {
        GameManager.instance.GetPlayerStat().AdCoins += 1;
        SoundsManager.instance.ToggleSoundPause();
        somethingOutput.text = "adCompleted();";
    }

    public void adAbandoned()
    {
        SoundsManager.instance.ToggleSoundPause();
        somethingOutput.text = "adAbandoned();";
    }
    #endregion
}
