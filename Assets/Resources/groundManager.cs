using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class groundManager : MonoBehaviour
{	
	//邊界設定
	readonly float liftBorder = -3;   
    readonly float rightBorder = 3;		
    readonly float initPositionY = 0;
    readonly int MAX_GROUND_COUNT = 10;
    readonly int MIN_GROUND_COUNT_UNDER_PLAYER = 3;
    public Transform player;
    static int groundNumber = -1;
    [Range(2, 6)]public float spacingY;
    [Range(1,20)]public float singleFloorHeight;
    public List<Transform> grounds;
    public Text displayCountFloor;
   

    void Start()
    {	
        grounds = new List<Transform>();
    	for(int i = 0; i<MAX_GROUND_COUNT; i++){
    		SpawnGround();
        }
    }

    public void ControlSpawnGround(){
        int groundsCountUnderPlayer = 0;

        foreach (Transform ground in grounds){
            if(ground.position.y < player.transform.position.y){
                groundsCountUnderPlayer++;
            }    
        }

        if(groundsCountUnderPlayer<MIN_GROUND_COUNT_UNDER_PLAYER){
            SpawnGround();
            ControlGroundsCount();
        }

    }

    void ControlGroundsCount(){   //控制地板的總數量
        if(grounds.Count>MAX_GROUND_COUNT){
            Destroy(grounds[0].gameObject);
            grounds.RemoveAt(0);
        }
    }

    float NewGroundPositionX(){
        if(grounds.Count==0){
            return 0;
        }
    	return Random.Range(liftBorder, rightBorder);
    }

    //計算新地板的y座標
    float NewGroundPositionY(){
        if(grounds.Count==0){
            return initPositionY;
        }
        int lowerIndex = grounds.Count - 1;
        return grounds[lowerIndex].transform.position.y - spacingY;
    }

    //產生單一地板
    void SpawnGround(){
        GameObject newGround = Instantiate(Resources.Load<GameObject>("ground"));
        newGround.transform.position = new Vector3(NewGroundPositionX(), NewGroundPositionY(), 0);
        grounds.Add(newGround.transform); 
    }

    float CountLowerGroundFloor(){

    	float playerPositionY = player.transform.position.y;
    	float deep = Mathf.Abs(initPositionY-playerPositionY);
    	return (deep/singleFloorHeight)+1;
    }

    void DisplayCountFloor(){
    	displayCountFloor.text = "地下" + CountLowerGroundFloor().ToString("0000") + "樓";
    }
  
    void Update()
    {	
        ControlSpawnGround();
        DisplayCountFloor();

    }
}
