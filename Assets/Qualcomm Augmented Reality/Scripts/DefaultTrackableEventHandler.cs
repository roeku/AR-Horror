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

		if (mTrackableBehaviour.TrackableName == "mijn1") {
			Invoke("fadeToBlackToFire", 2.0f);
		} else if (mTrackableBehaviour.TrackableName == "mijn5") {
			//Invoke("GameObject.Find ('Cube').GetComponent<FadeObjectInOut>().FadeOut (5.0f)", 2.0f);
			CameraDevice.Instance.SetFlashTorchMode(true);
		} //else if (mTrackableBehaviour.TrackableName == "mijn8") {GameObject.Find("ARCamera").GetComponent<DataSetLoadBehaviour>()}
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

				Debug.Log ("Trackable " + mTrackableBehaviour.TrackableName + " lost");
		}
	private void fadeToBlackToFire(){
		GameObject.Find ("screenFader").GetComponent<FadeScript> ().fade = true;
		CameraDevice.Instance.SetFlashTorchMode(false);
		Invoke ("restartFlashLight", 4.0f);
		}
	private void restartFlashLight() {
		CameraDevice.Instance.SetFlashTorchMode(true);
	}

    #endregion // PRIVATE_METHODS
}
