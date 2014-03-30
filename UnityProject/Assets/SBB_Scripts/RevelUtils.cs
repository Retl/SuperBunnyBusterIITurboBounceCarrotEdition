/*
 * Author: Carlis Moore
 * Creation Date: 30 March 2014
 * Last Modified: 30 March 2014
 * Software Description: These are a set of methods that I find myself using in a variety of scenarios when making games in Unity 3D.
*/
using UnityEngine;
using System.Collections;

public class RevelUtils : MonoBehaviour
{
		public static GameObject FindClosestGameObjectWithTag (GameObject theGameObject, string tagToFind) //I should probably move this into a library or something.
		{
				GameObject result = null;
				GameObject[] allObjects = GameObject.FindGameObjectsWithTag (tagToFind);
		
				foreach (GameObject current in allObjects) {
						if (current != theGameObject) {
								if (result == null) {
										result = current;
								} else {
										if (Vector3.Distance (theGameObject.transform.position, result.transform.position) > Vector3.Distance (theGameObject.transform.position, current.transform.position)) {
												result = current;
										}
								}
						}
				}
				return result;
		}

	
		public static Vector3 RandomVector3InRange (float xLow, float xHigh, float yLow, float yHigh, float zLow, float zHigh)
		{
				float tempX = Random.Range (xLow, xHigh);
				float tempY = Random.Range (yLow, yHigh);
				float tempZ = Random.Range (zLow, zHigh);

				return new Vector3 (tempX, tempY, tempZ);
		}
	
		public static bool IsWithinDistanceThreshold (GameObject source, GameObject destination, float theThreshold)
		{
				bool result = false;

				if (Vector3.Distance (source.transform.position, destination.transform.position) > theThreshold) { //If it is outside of the threshold...
						result = false; //Return false. - Moore
				} else { // Otherwise, return true. - Moore
						return true;
				}

				return result;
		}
	
		//Convenience Negation Wrapper Method for the above:
		public static bool IsNotWithinDistanceThreshold (GameObject source, GameObject destination, float theThreshold)
		{
				return !IsWithinDistanceThreshold (source, destination, theThreshold);
		}
}
