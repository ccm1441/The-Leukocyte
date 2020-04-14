using UnityEngine;

public class possiblebuy : MonoBehaviour {
    
    // 이 스크립트는 지정된 공간 안에 와야 아이템을 구매할수 있도록
    // 하는 스크립트

    private void OnTriggerEnter2D(Collider2D other)         // 지역에 들어오면 구매권한 부여
    {
        if(other.CompareTag("Player"))
            market_.enter_market = true;
    }

    private void OnTriggerStay2D(Collider2D other)          // 지역에 들어온 후 계속 있을시에도 구매권한 부여
    {
        if (other.CompareTag("Player"))
            market_.enter_market = true;
    }

    private void OnTriggerExit2D(Collider2D collision)      // 지역에 나가면 구매권한 박탈
    {
        market_.enter_market = false;
    }
}
