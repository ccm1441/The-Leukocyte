using UnityEngine;

public class MouseOver : MonoBehaviour
{
    // 이 스크립트는 아이템에 마우스를 올렸을시 설명을 해주는 스크립트

    public GameObject weapon_display;                       // 무기 테두리
    public GameObject Market_item_explain;                  // 무기 설명 창

    private void Start()
    {
        weapon_display.gameObject.SetActive(false);         // 처음 무기 테두리 비활성화
        market_.mouse_over = false;                            // 마우스 오버 판단 false
    }
    private void Update()
    {
        if (market_.success_buy)                               // 구매 성공시
        {
            Market_item_explain.SetActive(false);           // 설명창 비활성화
            market_.success_buy = false;                       // 구매 성공여부 초기화
        }
    }

    public void OnMouseOver()
    { //마우스 오버시
        market_.current_select_item = this.name;               // 현재 오버된 아이템 이름을 업데이트
        market_.mouse_over = true;                             // 마우스 오버 true
        weapon_display.gameObject.SetActive(true);          // 무기 테두리 활성화 // 설명창 위치 조정
        Market_item_explain.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 2f);
        Market_item_explain.gameObject.SetActive(true);     // 설명창 활성화
    }

    public void OnMouseExit()
    { // 마우스 오버후 나갈시
        market_.current_select_item = null;                    // 현재 오버된 아이템 null 대입
        market_.mouse_over = false;                            // 마우스 오버 false
        weapon_display.gameObject.SetActive(false);         // 무기 테두리 비활성화
        Market_item_explain.gameObject.SetActive(false);    // 설명창 비활성화
    }

}
