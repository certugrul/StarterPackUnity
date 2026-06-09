using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Consts.WheatTypes.GOLD_WHEAT))
        {
            other.gameObject?.GetComponent<GoldWheatCollectible>().Collect();
              Debug.Log("Player collected gold wheat!");
        }
         if (other.CompareTag(Consts.WheatTypes.HOLY_WHEAT))
        {
            other.gameObject.GetComponent<HolyWheatCollectible>().Collect();
            Debug.Log("Player collected holy wheat!");
        }
         if (other.CompareTag(Consts.WheatTypes.ROTTEN_WHEAT))
        {
            other.gameObject?.GetComponent<RottenWheatCollectible>().Collect();
            Debug.Log("Player collected rotten wheat!");
        }
        }
    
    }

