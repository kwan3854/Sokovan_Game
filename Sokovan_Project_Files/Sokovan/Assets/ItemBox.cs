using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public bool isOverlapped = false;
    private Renderer myRenderer;
    public Color touchColor;
    private Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        // GetComponent 를 이용해 자신이 가진 컴포넌트 중 Renderer 를 가져옴.
        myRenderer = GetComponent<Renderer>();
        originalColor = myRenderer.material.color; // 원래 컬러 백업
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // EndPoint 이외에도 뚫고 지나갈 수 있는 collider 가 있을 수 있으므로 Tag 를 통해 필터링
        if (other.tag == "EndPoint")
        {
            isOverlapped = true;
            myRenderer.material.color = touchColor; // 충돌 시 색 변경
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOverlapped = false;
            myRenderer.material.color = originalColor; // 떨어질 때 원래 색으로 변경
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOverlapped = true;
            myRenderer.material.color = touchColor; // 충돌 시 색 변경
        }
    }
}
