using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Collectable
{

    public string[] sceneNames;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "player")
        {
            //GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

        }
        base.OnCollide(coll);
    }
}
