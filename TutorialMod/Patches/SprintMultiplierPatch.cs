using UnityEngine;

public class SprintMultiplierPatch
{
    // Original sprintMultiplier variable
    private float sprintMultiplier = 1f;
    private bool isSprinting = false;
    private float sprintMeter = 1f;
    private float deltaTime => Time.deltaTime; // Simulating deltaTime for this example

    // Modified thresholds for high speed
    private const float ModifiedSprintMax = 10f; // Higher max sprint multiplier for extreme speed
    private const float ModifiedSprintIncreaseRate = 20f; // Much faster increase rate
    private const float ModifiedSprintDecreaseRate = 10f; // Faster decrease rate

    public void UpdateSprintMultiplier(bool isWalking)
    {
        if (isWalking)
        {
            if (isSprinting)
            {
                // Rapidly increase sprint multiplier
                sprintMultiplier = Mathf.Lerp(sprintMultiplier, ModifiedSprintMax, deltaTime * ModifiedSprintIncreaseRate);
            }
            else
            {
                // Gradually return to fast walking speed
                sprintMultiplier = Mathf.Lerp(sprintMultiplier, 2f, deltaTime * ModifiedSprintDecreaseRate);
            }
        }
        else
        {
            // Not walking: Reset to normal walking speed
            sprintMultiplier = Mathf.Lerp(sprintMultiplier, 1f, deltaTime * ModifiedSprintDecreaseRate);
        }

        // Ensure the sprintMultiplier stays within bounds
        sprintMultiplier = Mathf.Clamp(sprintMultiplier, 1f, ModifiedSprintMax);
    }

    // Method to simulate toggling sprint
    public void ToggleSprint(bool sprinting)
    {
        isSprinting = sprinting;
    }

    // Method to simulate updating the sprint meter
    public void UpdateSprintMeter(float value)
    {
        sprintMeter = Mathf.Clamp01(value); // Ensure sprint meter stays between 0 and 1
    }

    // Getter for current sprint multiplier (useful for debugging or display purposes)
    public float GetSprintMultiplier()
    {
        return sprintMultiplier;
    }
}
