using UnityEngine;

/// <summary>
/// ???????? ????? ? ???????????? ??????
/// </summary>
public class EnemyAppearance : MonoBehaviour
{
    public GameObject enemy;
    private Vector3 enemyOffsetRelativeToTrigger = new Vector3(-2f, -0.6f, 3.5f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (PlayerMovement.ZAxisDirection == PlayerMovement.AxisDirection.Forward && !GameProperties.PassedFloors.Contains(GameProperties.FloorNumber))
            {
                GameProperties.PassedFloors.Add(GameProperties.FloorNumber);

                var random = new System.Random();
                float generatedFloat = (float)random.NextDouble();
                if (generatedFloat < GameProperties.EnemyAppearanceChance)
                {
                    var enemyPosition = transform.position + enemyOffsetRelativeToTrigger;
                    Instantiate(enemy, enemyPosition, Quaternion.identity);
                }
            }
        }
    }
}