using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sposet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rangeObject;
    BoxCollider rangeCollider;
    public int NumOfObstacle;
    
    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
    }
    
    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;
        
        range_X = Random.Range( (range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range( (range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }
    public GameObject cube_obstacle;
    public GameObject moving_obstacle;
    public GameObject killer_obstacle;
    public GameObject point;
    private  GameObject instantObstacle;
    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    void Randomset()
    {
        NumOfObstacle = Random.Range(1, 5);
    }
    IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Randomset();

            // 생성 위치 부분에 위에서 만든 함수 Return_RandomPosition() 함수 대입
            if (NumOfObstacle == 1) 
            {
                instantObstacle = Instantiate(cube_obstacle, Return_RandomPosition() + new Vector3(0, 1, 0), Quaternion.identity);
            }
            else if (NumOfObstacle == 2) 
            {
                instantObstacle = Instantiate(moving_obstacle, Return_RandomPosition()+new Vector3(0, 1, 0), Quaternion.identity);
            }

            else if (NumOfObstacle == 3)
            {
                instantObstacle = Instantiate(killer_obstacle, Return_RandomPosition() + new Vector3(0, 0.5f, 0), Quaternion.identity);
            }
             else if (NumOfObstacle == 4)
            {
                instantObstacle = Instantiate(point, Return_RandomPosition() + new Vector3(0, 1f, 0), Quaternion.Euler(0, 0, 30));
            }
        }
    }

}
