using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHidingPointStorage : MonoBehaviour {

    static HidingPoint[] HidingPoints;

	// Use this for initialization
	void Start () {
        MonsterHidingPointStorage.HidingPoints = GetComponentsInChildren<HidingPoint>();
	}

    public static HidingPoint GetNearestPoint(Vector3 monsterPos)
    {
        float lowestDist = Vector3.Distance(HidingPoints[0].transform.position, monsterPos);
        int lowestDistIndex = 0;
        for (int i = 1; i < HidingPoints.Length; i++)
        {
            float dist = Vector3.Distance(HidingPoints[i].transform.position, monsterPos);
            if (dist < lowestDist)
            {
                lowestDist = dist;
                lowestDistIndex = i;
            }
        }
        return HidingPoints[lowestDistIndex];
    }

    public static HidingPoint GetNextPointTowardsCenter(Vector3 monsterPos)
    {
        HidingPoint neareastPoint = GetNearestPoint(monsterPos);

        if(neareastPoint.forwardPoints.Length > 0)
        {
            return neareastPoint.forwardPoints[Random.Range(0, neareastPoint.forwardPoints.Length)];  // make random
        }
        else if( neareastPoint.radiusPoints.Length > 0)
        {
            return neareastPoint.radiusPoints[Random.Range(0, neareastPoint.radiusPoints.Length)]; // make random
        }
        else if(neareastPoint.backwardsPoints.Length > 0)
        {
            return neareastPoint.backwardsPoints[Random.Range(0, neareastPoint.backwardsPoints.Length)];
        }

        // if for some reason your point has no registered connected points. just return a random point so game doesn't break
        return HidingPoints[Random.Range(0, HidingPoints.Length)];
    }

    public static HidingPoint GetNextPointAwayFromCenter(Vector3 monsterPos)
    {
        HidingPoint neareastPoint = GetNearestPoint(monsterPos);

        if (neareastPoint.backwardsPoints.Length > 0)
        {
            return neareastPoint.backwardsPoints[Random.Range(0, neareastPoint.backwardsPoints.Length)];
        }
        else if (neareastPoint.radiusPoints.Length > 0)
        {
            return neareastPoint.radiusPoints[Random.Range(0, neareastPoint.radiusPoints.Length)]; // make random
        }
        else if (neareastPoint.forwardPoints.Length > 0)
        {
            return neareastPoint.forwardPoints[Random.Range(0, neareastPoint.forwardPoints.Length)];  // make random
        }

        // if for some reason your point has no registered connected points. just return a random point so game doesn't break
        return HidingPoints[Random.Range(0, HidingPoints.Length)];
    }
}
