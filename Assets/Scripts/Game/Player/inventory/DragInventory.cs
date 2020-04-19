using UnityEngine;
using UnityEngine.EventSystems;                              //아래 핸들러(이벤트시스템)을 사용하기 위해서

public class DragInventory : MonoBehaviour, IDragHandler     // 드래그 함수를 쓰기위해서 부모 클래스 선언
{

    public void OnDrag(PointerEventData eventData)           // 마우스로 클릭하여 드래그 이벤트가 발생할때
    {
        Vector2 currentPos = Input.mousePosition;            // 현재 위치를 마우스 위치로 지정
        this.transform.position = currentPos;                // 이 스크립트가 들어간 오브젝트 위치를
                                                             // 마우스 위치로 조정
        inventory_.get_inventory_pos = false;                      // 인벤토리 위치를 얻었는가를 판단
    }

    }
