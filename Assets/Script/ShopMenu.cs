using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PrevPage()
    {
        SceneManager.LoadScene(2);
    }

   

    public void NextPage()
    {
        SceneManager.LoadScene(3);
    }
}
