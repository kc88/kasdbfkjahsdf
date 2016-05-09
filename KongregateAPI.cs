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

        Object.DontDestroyOnLoad(gameObject);

        earnAdCoinButton.GetComponent<Button>().interactable = true;

        Application.ExternalEval(
            "if(typeof(kongregateUnitySupport) != 'undefined'){" +
            "    kongregateUnitySupport.initAPI('KongregateAPI', 'OnKongregateAPILoaded');" +
            "};"
        );
    }

    public void Submit(string name, int value)
    {
        Application.ExternalCall("kongregate.stats.submit", name, value);
    }

    public void OnKongregateAPILoaded(string userInfoString)
    {
        OnKongregateUserInfo(userInfoString);
        GameManager.instance.APICallBack();

        #region take2
        // adsAvailable
        Application.ExternalEval(
            "kongregate.mtx.addEventListener('adsAvailable', function(e:Event):void{" +
            "   unityObject.SendMessage('KongregateAPI', 'adsAvailable');" +
            "});"
        );

        // adsUnavailable
        Application.ExternalEval(
            "kongregate.mtx.addEventListener('adsUnavailable', function(e:Event):void{" +
            "   unityObject.SendMessage('KongregateAPI', 'adsUnavailable');" +
            "});"
        );

        // adOpened
        Application.ExternalEval(
            "kongregate.mtx.addEventListener('adOpened', function(e:Event):void{" +
            "   unityObject.SendMessage('KongregateAPI', 'adOpened');" +
            "});"
        );

        // adCompleted
        Application.ExternalEval(
            "kongregate.mtx.addEventListener('adCompleted', function(e:Event):void{" +
            "   unityObject.SendMessage('KongregateAPI', 'adCompleted');" +
            "});"
        );
        // adAbandoned
        Application.ExternalEval(
            "kongregate.mtx.addEventListener('adAbandoned', function(e:Event):void{" +
            "   unityObject.SendMessage('KongregateAPI', 'adAbandoned');" +
            "});"
        );
        // initializeIncentivizedAds
        Application.ExternalEval(
            "kongregate.mtx.initializeIncentivizedAds();"
        );
        #endregion
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
        Application.ExternalEval(
            "kongregate.mtx.showIncentivizedAd();"
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
