using UnityEngine;
using UnityEngine.SceneManagement;

public class Map_Change : MonoBehaviour
{
    public GameObject player;
    Scene scene;
    static string before_map;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        before_map = map_.scene_name;                       // 맵 비교를 위해 전맵을 저장
        map_.scene_name = scene.name;                       // 현재 맵을 저장
    }

    private void FixedUpdate()
    {                                                       //
        if (scene.name == before_map)                       // 현재맵과 전맵이 같으면
            map_.map_check = false;                         // 좌표 수정안하기 위해
        else map_.map_check = true;                         // bool 값 조정

        if (before_map == "Game_square")                    // 튜툐리얼맵 판단
            map_.town_off = true;

        if (scene.name != before_map && map_.map_check)     // (2중체크임)현재맵과 전맵이 다르고 맵체크가 트루
        {
            if (map_.right_check)
            {
                player.transform.position = new Vector3(map_.portal_position_left + 1.5f, 0, 0);
                map_.right_check = false;
            }
            if (map_.left_check)
            {

                player.transform.position = new Vector3(map_.portal_position_right - 1.5f, 0, 0);
                map_.left_check = false;
            }
            if (map_.up_check)
            {

                player.transform.position = new Vector3(0, map_.portal_position_down + 1.5f, 0);
                map_.up_check = false;
            }
            if (map_.down_check)
            {

                player.transform.position = new Vector3(0, map_.portal_position_up - 1.5f, 0);
                map_.down_check = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("PortalToRight") )
        {
            if (map_.town_off && map_.right_map == "Game_square") //튜토리얼맵을 거르기 위해서
                SceneManager.LoadScene("Town");
            else SceneManager.LoadScene(map_.right_map);
            map_.right_check = true;
            map_.map_check = true;
        }
        if (hit.CompareTag("PortalToLeft"))
        {
            if (map_.town_off && map_.left_map == "Game_square") //튜토리얼맵을 거르기 위해서
                SceneManager.LoadScene("Town");
            else SceneManager.LoadScene(map_.left_map);

            map_.left_check = true;
            map_.map_check = true;
        }
        if (hit.CompareTag("PortalToUp"))
        {
            if (map_.town_off && map_.up_map == "Game_square") //튜토리얼맵을 거르기 위해서
                SceneManager.LoadScene("Town");
            else SceneManager.LoadScene(map_.up_map);
            map_.up_check = true;
            map_.map_check = true;
        }
        if (hit.CompareTag("PortalToDown"))
        {
            if (map_.town_off && map_.down_map == "Game_square") //튜토리얼맵을 거르기 위해서
                SceneManager.LoadScene("Town");
            else SceneManager.LoadScene(map_.down_map);
            map_.down_check = true;
            map_.map_check = true;
        }
        if (hit.CompareTag("PortalToHidden"))
        {
            if (map_.town_off && map_.up_map == "Game_square") //튜토리얼맵을 거르기 위해서
                SceneManager.LoadScene("Town");
            else SceneManager.LoadScene(map_.hidden_map);
            map_.up_check = true;
            map_.map_check = true;
        }
    }
}
