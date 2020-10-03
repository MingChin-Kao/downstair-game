using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trapManage : MonoBehaviour
{
    readonly float initPositionY = 0;
    readonly float liftBorder = -3;   
    readonly float rightBorder = 3;	
    readonly int MIN_TRAP_COUNT_UNDER_PLAYER = 3;
    readonly int MAX_TRAP_COUNT = 10;
    public Transform player;
    public List<Transform> traps;
    [Range(2, 6)]public float spacingY;


    float NewGroundPositionY(){
        if(traps.Count==0){
            return initPositionY;
        }
        int lowerIndex = traps.Count - 1;
        return traps[lowerIndex].transform.position.y - spacingY;
    }

    public void ControlSpawnTrap(){
        int trapsCountUnderPlayer = 0;

        foreach (Transform trap in traps){
            if(trap.position.y < player.transform.position.y){
                trapsCountUnderPlayer++;
            }    
        }

        if(trapsCountUnderPlayer<MIN_TRAP_COUNT_UNDER_PLAYER){
            SpawnTrap();
            ControlTrapsCount();
        }

    }

    float NewGroundPositionX(){
        if(traps.Count==0){
            return 0;
        }
    	return Random.Range(liftBorder, rightBorder);
    }

    void ControlTrapsCount(){   //控制地板的總數量
        if(traps.Count>MAX_TRAP_COUNT){
            Destroy(traps[0].gameObject);
            traps.RemoveAt(0);
        }
    }

    void SpawnTrap(){      //新增單一陷阱
        GameObject newTrap = Instantiate(Resources.Load<GameObject>("dead"));
        newTrap.transform.position = new Vector3(NewGroundPositionX(), NewGroundPositionY(), 0);
        traps.Add(newTrap.transform); 
    }

    void Start()
    {
    	traps = new List<Transform>();
    	for(int i = 0; i<MAX_TRAP_COUNT; i++){
    		SpawnTrap();
        }
    	
    }

    
    void Update()
    {	
    	ControlSpawnTrap();
        
    }
}




