using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterController : MonoBehaviour
{
    private bool isWaterUsed = false;
    public GameObject waterInfo;
    private void Update()
    {
        if (waterInfo.activeSelf)
            waterInfo.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 2, 0));
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isWaterUsed == false && collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.playerStats.CurrentHealth = GameManager.Instance.playerStats.MaxHealth;
            GameManager.Instance.playerStats.CurrentEnergy = GameManager.Instance.playerStats.MaxEnergy;
            isWaterUsed = true;
            waterInfo.GetComponent<Text>().text = "Oh my, so sweet~";
            waterInfo.SetActive(true);
            StartCoroutine(SetInfoFalse());
        }
        else if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            waterInfo.GetComponent<Text>().text = "It's all gone~ (*^��^*)";
            waterInfo.SetActive(true);
            StartCoroutine(SetInfoFalse());
        }
    }

    IEnumerator SetInfoFalse()
    {
        yield return new WaitForSeconds(2);
        waterInfo.SetActive(false);
    }
}
