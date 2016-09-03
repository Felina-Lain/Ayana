using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour {


	public AudioSource[] audios = new AudioSource[10];
    //for testing game
    public bool debugMode = true;

    private static GameManager instance; 



    //-------------------------------------------
    //retrieve currently active instance of object if any
    public static GameManager Instance
    {
        get
        {
            //create gameManager object if needed
            if (instance == null) instance = new GameObject("GameManager").AddComponent<GameManager>();
            return instance;
        }
    }


    void Awake()
    {
        //check if there is an existing instance of this object
        if ((instance) && (instance.GetInstanceID() != GetInstanceID()))
            DestroyImmediate(gameObject); //delete duplicate
        else
        {
            instance = this;
         //   DontDestroyOnLoad(gameObject); //do not destroy
        }


    }


    // Use this for initialization
    void Start() {

        if (!debugMode)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update() {	
		
        SetCursorActive();

		audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
	
		foreach (AudioSource _audio in audios){
			if(_audio != null){
				if (!_audio.name.Contains ("Background")) {
					_audio.volume = VolumeGestion._volumeFX;
				}
				if (_audio.name.Contains ("Background")) {
					_audio.volume = VolumeGestion._volumeM;
				}
			}
		}
		//System.Array.Clear (audios, 0, 10);

	}

    private void SetCursorActive()
    {
		if (Input.GetKeyDown(KeyCode.V))
        {
            Cursor.visible = !Cursor.visible;

            if (Cursor.lockState == CursorLockMode.None)
                Cursor.lockState = CursorLockMode.Locked;
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
        }
    }
}



