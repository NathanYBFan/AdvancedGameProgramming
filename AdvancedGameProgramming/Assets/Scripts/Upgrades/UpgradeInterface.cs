using UnityEngine;

public interface UpgradeInterface
{
    public int upgradeID { get; }
    public void Run()
    {
        Debug.Log("Run() not overwritten");
    }

    public void IncraeseNumber( int amountToAdd )
    {
        Debug.Log("IncreaseNumber() not overwritten");
    }
}