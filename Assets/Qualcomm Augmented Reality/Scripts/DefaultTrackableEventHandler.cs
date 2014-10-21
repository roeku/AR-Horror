/*==============================================================================
Copyright (c) 2010-2013 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour,
                                            ITrackableEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES
	public static bool TRACKING = false;
	public static string aktName = "";
    private TrackableBehaviour mTrackableBehaviour;
    
    #endregion // PRIVATE_MEMBER_VARIABLES



    #region UNTIY_MONOBEHAVIOUR_METHODS
    
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS



    #region PUBLIC_METHODS

    /// <summary>
    /// Implementation of the ITrackableEventHandler function called when the
    /// tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
			TRACKING = true;
        }
        else
        {
            OnTrackingLost();
			TRACKING = false;
        }
    }

    #endregion // PUBLIC_METHODS



    #region PRIVATE_METHODS

    private void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Enable rendering:
		// render all except Ignore:
        foreach (Renderer component in rendererComponents)
        {
			component.enabled = true;
		}
		
		// Enable colliders:
		// render all except Ignore:
		foreach (Collider component in colliderComponents)
        {
			component.enabled = true;
		}

		aktName = this.name;

		if (mTrackableBehaviour.TrackableName == "FamilyPortrait") {
						Invoke ("fadeToBlackToFire", 15.0f);
						CameraDevice.Instance.SetFlashTorchMode (true);

				} else if (mTrackableBehaviour.TrackableName == "target1") {
						CameraDevice.Instance.SetFlashTorchMode (true);

				} else if (mTrackableBehaviour.TrackableName == "Jim") {
						Invoke ("activateNoise", 5.0f);
				} else if (mTrackableBehaviour.TrackableName == "Jorien") {
						Invoke ("activateNoise", 5.0f);		
				} else if (mTrackableBehaviour.TrackableName == "Wout") {
						Invoke ("activateNoise", 5.0f);		
				} else if (mTrackableBehaviour.TrackableName == "PortraitCharles") {
						GameObject.Find("screenFader").GetComponent<flikkerScript>().enabled = true;
			Debug.Log("XDDDDD");
				}
			//GameObject.Find('schim').GetComponent<FadeObjectInOut>().FadeOut(0.5f);		

		    Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
    }

    private void OnTrackingLost()
    {
				Renderer[] rendererComponents = GetComponentsInChildren<Renderer> (true);
				Collider[] colliderComponents = GetComponentsInChildren<Collider> (true);

				// Disable rendering:
				foreach (Renderer component in rendererComponents) {
						component.enabled = false;
				}

				// Disable colliders:
				foreach (Collider component in colliderComponents) {
						component.enabled = false;
				}
				if (mTrackableBehaviour.TrackableName == "PortraitCharles") {
					GameObject.Find("screenFader").GetComponent<flikkerScript>().enabled = false;
					GameObject.Find("screenFader").GetComponent<GUITexture>().color = Color.clear;
				}

				Debug.Log ("Trackable " + mTrackableBehaviour.TrackableName + " lost");
		}
	private void fadeToBlackToFire(){
		GameObject.Find ("screenFader").GetComponent<FadeScript>().fade = true;
		}

	private void activateNoise(){
		GameObject.Find ("Camera_left").GetComponent<NoiseEffect>().enabled = true;

		GameObject.Find ("Camera_right").GetComponent<NoiseEffect>().enabled = true;
		Invoke ("fadeToBlackToFire", 2.0f);
	}
	

    #endregion // PRIVATE_METHODS
}
