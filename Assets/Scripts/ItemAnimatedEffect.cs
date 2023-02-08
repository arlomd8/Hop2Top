using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimatedEffect : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(AnimateItem());
    }
    IEnumerator AnimateItem()
    {
        UIManager.instance.scoreEffectText.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        UIManager.instance.scoreEffectText.SetActive(false);
        Destroy(gameObject);
    }
}
