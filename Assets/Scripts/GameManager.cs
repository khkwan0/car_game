using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    private GameObject road;
    private GameObject newestRoad;
    private GameObject oldRoad;
    private GameObject playerCar;
    private Camera playerCamera;
    private GameObject grandFather;

    public GameObject playerCarPrefab;
    public GameObject roadPrefab;

    public Camera playerCameraPrefab;

    public float cameraHeight = 50.0f;

    [SerializeField]
    private Vector3 carLocation;

	void Start () {
        grandFather = null;
        newestRoad = Instantiate(roadPrefab);
        playerCar = Instantiate(playerCarPrefab, new Vector3(0.0f, 1.3f, 10.0f), Quaternion.LookRotation(Vector3.forward, Vector3.up));
        playerCamera = Instantiate(playerCameraPrefab);
        playerCamera.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f));
        playerCamera.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        playerCamera.transform.position = new Vector3(0.0f, cameraHeight, playerCar.transform.position.z + 20.0f);
        carLocation = playerCar.transform.position;
	}

    public void createMoreRoad()
    {
        oldRoad = newestRoad;   
        newestRoad = Instantiate(roadPrefab, new Vector3(0.0f, 0.0f, newestRoad.transform.position.z + CreateRoad.height), Quaternion.LookRotation(Vector3.forward, Vector3.up));
        if (grandFather)
        {
            Destroy(grandFather);
        }
        grandFather = oldRoad;
    }
}
