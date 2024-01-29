using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class FitToWaterSurface : MonoBehaviour
{
    public WaterSurface targetSurface = null;
    public float boatLength = 5f; // Length of the boat
    public float boatWidth = 2f; // Width of the boat
    public float rotationScale = 0.1f; // Scale factor for rotation
    public float rotationSmoothing = 0.1f; // Smoothing factor for rotation
    public float selfRightingStrength = 0.1f; // Strength of self-righting behavior

    private Quaternion initialRotation; // Initial rotation of the boat

    // Internal search params
    private WaterSearchParameters searchParameters = new WaterSearchParameters();
    private WaterSearchResult searchResult = new WaterSearchResult();

    void Start()
    {
        // Store the initial rotation of the boat
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetSurface != null)
        {
            Vector3 frontLeft = transform.TransformPoint(new Vector3(-boatWidth / 2, 0, boatLength / 2));
            Vector3 frontRight = transform.TransformPoint(new Vector3(boatWidth / 2, 0, boatLength / 2));
            Vector3 backLeft = transform.TransformPoint(new Vector3(-boatWidth / 2, 0, -boatLength / 2));
            Vector3 backRight = transform.TransformPoint(new Vector3(boatWidth / 2, 0, -boatLength / 2));

            float frontLeftHeight = 0f, frontRightHeight = 0f, backLeftHeight = 0f, backRightHeight = 0f;
            int validPointsCount = 0;

            bool UpdateHeight(Vector3 edgePosition, out float height)
            {
                height = 0f;
                searchParameters.startPositionWS = edgePosition;
                searchParameters.targetPositionWS = edgePosition;
                searchParameters.error = 0.01f;
                searchParameters.maxIterations = 8;

                if (targetSurface.ProjectPointOnWaterSurface(searchParameters, out searchResult))
                {
                    height = searchResult.projectedPositionWS.y;
                    return true;
                }
                return false;
            }

            if (UpdateHeight(frontLeft, out frontLeftHeight)) validPointsCount++;
            if (UpdateHeight(frontRight, out frontRightHeight)) validPointsCount++;
            if (UpdateHeight(backLeft, out backLeftHeight)) validPointsCount++;
            if (UpdateHeight(backRight, out backRightHeight)) validPointsCount++;

            if (validPointsCount == 4)
            {
                float averageFrontHeight = (frontLeftHeight + frontRightHeight) / 2;
                float averageBackHeight = (backLeftHeight + backRightHeight) / 2;

                float pitch = Mathf.Atan2(averageBackHeight - averageFrontHeight, boatLength) * Mathf.Rad2Deg * rotationScale;
                float roll = Mathf.Atan2(frontLeftHeight + backLeftHeight - frontRightHeight - backRightHeight, boatWidth) * Mathf.Rad2Deg * rotationScale;

                float averageHeight = (frontLeftHeight + frontRightHeight + backLeftHeight + backRightHeight) / 4;
                Vector3 newPosition = new Vector3(transform.position.x, averageHeight, transform.position.z);

                Quaternion targetRotation = Quaternion.Euler(pitch, initialRotation.eulerAngles.y, roll);
                Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothing * Time.deltaTime);
                Quaternion selfRightingRotation = Quaternion.Slerp(smoothedRotation, initialRotation, selfRightingStrength * Time.deltaTime);

                transform.position = newPosition;
                transform.rotation = selfRightingRotation;
            }
            else
            {
                // Debug.LogError("Can't Find Projected Positions for All Edges");
                Debug.Log("Can't Find Projected Positions for All Edges");
            }
        }
    }
}
