using OneSignalSDK;
using UnityEngine;
using UnityEngine.Android;

public class DataLoader : MonoBehaviour
{
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        OneSignal.Initialize("56c12a53-f804-4ff4-8563-1ac9e7e8b55e");
        Branch.initSession(CallbackWithBranchUniversalObject);
    }

    private void CallbackWithBranchUniversalObject(BranchUniversalObject buo,
                                            BranchLinkProperties linkProps,
                                            string error)
    {
        if (error != null)
        {
            Debug.LogError("Error : "
                                    + error);
        }
        else if (linkProps.controlParams.Count > 0)
        {
            Debug.Log("Deeplink params : "
                                    + buo.ToJsonString()
                                    + linkProps.ToJsonString());
        }
    }
}