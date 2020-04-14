using UnityEngine;

public class blood_pump : MonoBehaviour
{
    public ParticleSystem blood_p;      //파티클 시스템
    static float time;                  // 시간담을꺼

    private void FixedUpdate()
    {
        time += Time.deltaTime;         // 시간 계속 쌓음

        if (time > 0.2)                 // 0.2초 지나면
        {
            if(!blood_p.isPlaying)      // 파티클이 플레이중이 아님면
            {
                blood_p.Play();         // 플레이
                time = 0;               // 타임 0
            }            
        }          
    }
}

// 파티클 메소드 참고 : https://docs.unity3d.com/kr/530/ScriptReference/ParticleSystem.html