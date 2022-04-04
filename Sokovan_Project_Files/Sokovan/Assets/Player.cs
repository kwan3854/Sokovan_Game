using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    private float speed = 3f;
    private Rigidbody playerRigidbody; // 실제 존재하는 Rigidbody 를 가져다가 playerRigidbody 라는 이름을 붙여 사용
    // Start is called before the first frame update
    void Start() // 게임이 처음 시작되었을때 한번 실행됨
    {
        playerRigidbody = GetComponent<Rigidbody>(); // 제네릭 문법
    }

    // Update is called once per frame
    // 영화: 초당 24프레임, 모바일게임: 초당 30프레임, PC게임: 초당 60프레임, 콘솔게임: 초당 30프레임
    // 대략 1초에 60번 실행됨. 단, 컴퓨터 사양에 따라 다르다.
    // 즉, 1초에 몇 번 실행되는지 정해져 있지는 않다.
    void Update() // 화면이 한번 깜빡일 때 마다 한번씩 실행됨
    {
        if (gameManager.isGameOver == true)
        {
            return;
        }
        // 유저입력을 넣자.
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        float fallSpeed = playerRigidbody.velocity.y;

        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        velocity = velocity * speed;

        velocity.y = fallSpeed; // Y축 velocity 값을 원래 적용되었어야 할 원래 중력값으로 덮어쓰기 해 줌

        playerRigidbody.velocity = velocity;
    }
}
