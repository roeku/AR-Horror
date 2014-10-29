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
	public GameObject ARFader;
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
						fadeInAlpha script = ARFader.GetComponent<fadeInAlpha> ();
						script.enabled = true;
						CameraDevice.Instance.SetFlashTorchMode (true);
				} else if (mTrackableBehaviour.TrackableName == "veiligheidswerkerfoto") {
						fadeInAlpha script = ARFader.GetComponent<fadeInAlpha> ();
						script.enabled = true;
				} else if (mTrackableBehaviour.TrackableName == "archeoloogfoto") {
						Invoke ("activateDarknessFilter", 5.0f);
				} else if (mTrackableBehaviour.TrackableName == "TagDeur") {
						fadeToBlackToFire ();
				} else if (mTrackableBehaviour.TrackableName == "Jim") {
						Invoke ("activateNoise", 5.0f);
				} else if (mTrackableBehaviour.TrackableName == "Jorien") {
						Invoke ("activateNoise", 5.0f);		
				} else if (mTrackableBehaviour.TrackableName == "Wout") {
						Invoke ("activateNoise", 5.0f);
				} else if (mTrackableBehaviour.TrackableName == "jethro") {
						Invoke ("activateNoise", 5.0f);
				} else if (mTrackableBehaviour.TrackableName == "PortraitCharles") {
						Invoke("fadeToBlackToFire", 5.0f);
						GameObject.Find("screenFlikkerer").GetComponent<flikkerScript>().enabled = true;
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
					GameObject.Find("screenFlikkerer").GetComponent<flikkerScript>().enabled = false;
			GameObject.Find("screenFlikkerer").GetComponent<GUITexture>().color = Color.clear;
			GameObject.Find("screenFader").GetComponent<GUITexture>().color = Color.clear;
		} else if(mTrackableBehaviour.TrackableName == "FamilyPortrait") {
			fadeInAlpha script = ARFader.GetComponent<fadeInAlpha>();
			script.enabled = false;
		} else if(mTrackableBehaviour.TrackableName == "veiligheidswerkerfoto") {
			fadeInAlpha script = ARFader.GetComponent<fadeInAlpha>();
			script.enabled = false;
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

	private void activateDarknessFilter() {
		GameObject.Find ("Camera_left").GetComponent<GrayscaleEffect>().enabled = true;
		GameObject.Find ("Camera_right").GetComponent<GrayscaleEffect>().enabled = true;

	}
	

    #endregion // PRIVATE_METHODS
}
