using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DeathAnim;
    private bool isDead = false;


    IEnumerator quitGameDefense_win()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("DEATH ");
        SceneManager.LoadScene("Defense_win");
        Destroy(gameObject);
    }
    IEnumerator quitGameAttack_win()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("DEATH ");
        SceneManager.LoadScene("Attack_win");
        Destroy(gameObject);
    }

    public void Die()
    {

        GameObject.Find("Canvas").SetActive(false);
        GameObject.Find("gameManager").SetActive(false);
        GameObject.Find("Station").SetActive(false);
        GameObject.Find("Crystal 1").SetActive(false);//AsteroidWall
        GameObject.Find("AsteroidWall").SetActive(false);//AsteroidWall
        GameObject a = Instantiate(DeathAnim) as GameObject;
        a.transform.position = gameObject.transform.position;


        if (gameObject.name == "Station")
        {

            StartCoroutine(quitGameAttack_win());
        }
        else
        {
            StartCoroutine(quitGameDefense_win());
        }


    }
}
