using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {

	public GameObject player;
    private GameObject ghost = null;
    public float speed;
    const int updateConst = 500;
    private int toUpdate = updateConst;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.Find("/Player");

        GameObject respawns = GameObject.FindWithTag(gameObject.tag);

     //   if (toUpdate >= updateConst/2)
      //  {
        float step = 1.5F * Time.deltaTime;
            
        Vector3 newPos = Vector3.MoveTowards(transform.position, player.transform.position, step);
        newPos.y = 1.5F;
        transform.position = newPos;
       /* }
        else
        {
            if (!ghost || toUpdate <= 0)
            {
                System.Random random = new System.Random();
                int randomNumber = random.Next(0, 10000);
                GameObject[] ghostList = GameObject.FindGameObjectsWithTag("Ghost");
                ghost = ghostList[randomNumber % ghostList.Length];
            }
            else
            {
                float step = 3 * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, ghost.transform.position, step);
            }
        }

        toUpdate--;
        if (toUpdate <= 0)
            toUpdate = updateConst;*/
    }
}
