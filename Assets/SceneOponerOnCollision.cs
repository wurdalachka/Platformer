using UnityEngine;

public class SceneOpenerOnCollision : Screen_opener


{
    public string NextLevelName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OpenScene(NextLevelName);

    }

}
