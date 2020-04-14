using UnityEngine;

public class map1_animation : MonoBehaviour
{
    public Animator map1;                                               // 맵1 애니메이터
    public AnimationClip map1_clip;                                     // 맵1 애니메이션 클립
    public GameObject character;                                        // 캐릭터 오브젝트
    public GameObject info_ui;
    public GameObject[] monster;

    static float time;                                                  // 시간을 담을 변수
    static bool stop = false;                                           // 1 반복

    void Start()
    {
        if (!map_.animation_off)                                        // 애니메이션 실행 옵션
        {
            map1.SetBool("exit", true);                                 // 애미메이션 실행
            map_.animation_off = true;                                  // 실행했음을 저장
        }
        else
        {
            character.gameObject.SetActive(true);                     // 다음에 왔을때 애니가 실행했었다면 바로 캐릭터 소환
            info_ui.gameObject.SetActive(true);
            for (int i = 0; i < monster.Length; i++)
            {
                monster[i].SetActive(true);
            }
        }
    }
    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if (map1_clip.length+1.5f < time && map1.GetBool("exit") && !stop)       // 타임이 클립길이+1.5보다 길고 애니가 실행되는 중이면
        {
          
            character.gameObject.SetActive(true);                       // 캐릭터 소환
            info_ui.gameObject.SetActive(true);
            for (int i = 0; i < monster.Length; i++)
            {
                monster[i].SetActive(true);
            }
            stop = true;
            map1.SetBool("exit", false);                                // 애니 종료
        }         
    }
}

