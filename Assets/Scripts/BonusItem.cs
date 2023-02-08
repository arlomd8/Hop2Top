using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BonusItem : MonoBehaviour
{
    public GameObject itemAnimated;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.targetCount += 1;
            GameManager.instance.score += 10;
            Instantiate(itemAnimated, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator AnimateItem()
    {
        Instantiate(itemAnimated, transform.position, Quaternion.identity);
        UIManager.instance.scoreEffectText.SetActive(true);
        yield return new WaitForSeconds(1.1f);  
        UIManager.instance.scoreEffectText.SetActive(false);    
    }
}
