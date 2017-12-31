using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {
	//public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;
	
	public float distanceBetweenMin;
	public float distanceBetweenMax;
	private float[] platformWidths;
	private int platformIndex;
	public GameObject[] thePlatforms;
	
	public Transform maxHeightPoint;
	private float minHeight;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;
	
	// Use this for initialization
	void Start () {
		
		platformWidths = new float[thePlatforms.Length];
		for (int i = 0; i < thePlatforms.Length; i++){
			platformWidths[i] = thePlatforms[i].GetComponent<BoxCollider2D>().size.x;
		}
		
		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < generationPoint.position.x){
			
			distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
			
			heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
			
			//if(heightChange > maxHeight){
				//heightChange = maxHeight;
			//}
			//else if(heightChange < minHeight){
				//heightChange = minHeight;
			//}
			transform.position = new Vector3(transform.position.x + (platformWidths[platformIndex]/2)+ distanceBetween, heightChange, transform.position.z);
			
			platformIndex = Random.Range(0, thePlatforms.Length);
			
			Instantiate (thePlatforms[platformIndex], transform.position, transform.rotation);
		}
	}
}
