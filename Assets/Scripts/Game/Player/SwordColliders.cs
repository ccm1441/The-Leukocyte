using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordColliders : MonoBehaviour {
    [SerializeField]
    private PolygonCollider2D[] colliders; // 콜라이더 배열로
    private int currentColliderIndex; // 현재 콜라이더 인덱스
    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }
}
