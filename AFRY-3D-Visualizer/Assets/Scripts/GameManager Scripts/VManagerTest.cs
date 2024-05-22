using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VManagerTest : MonoBehaviour
{
    private int points = 106;
    int index = 0;
    [SerializeField] GameObject[] vehicle;

    // <Connection to MCS-Core>
    ///////////////////////////////////////////////
    ///
    /// 

    int rows = 0;
    int cols = 5;
    float[,] MCSCoreData;
    float[][][] combinedArray = new float[][][] { };
    float[][] v1 = new float[][]
    {
new float[]{3.0f, 0.0f, 35.70f, -35.20f, 2.111f},
new float[]{3.0f, 0.0f, 34.67f, -33.48f, 2.111f},
new float[]{3.0f, 0.0f, 33.64f, -31.76f, 2.111f},
new float[]{3.0f, 0.0f, 32.61f, -30.04f, 2.111f},
new float[]{3.0f, 0.0f, 31.58f, -28.33f, 2.111f},
new float[]{3.0f, 0.0f, 30.54f, -26.61f, 2.111f},
new float[]{3.0f, 0.0f, 29.51f, -24.89f, 2.111f},
new float[]{3.0f, 0.0f, 28.48f, -23.17f, 2.111f},
new float[]{3.0f, 0.0f, 27.45f, -21.45f, 2.111f},
new float[]{3.0f, 0.0f, 26.42f, -19.73f, 2.111f},
new float[]{3.0f, 0.0f, 25.39f, -18.01f, 2.111f},
new float[]{3.0f, 0.0f, 24.36f, -16.29f, 2.111f},
new float[]{3.0f, 0.0f, 23.33f, -14.58f, 2.111f},
new float[]{3.0f, 0.0f, 22.29f, -12.86f, 2.111f},
new float[]{3.0f, 0.0f, 21.26f, -11.14f, 2.111f},
new float[]{3.0f, 0.0f, 20.23f, -9.42f, 2.111f},
new float[]{3.0f, 0.0f, 19.20f, -7.70f, 2.111f},
new float[]{3.0f, 0.0f, 19.20f, -7.70f, 2.435f},
new float[]{3.0f, 0.0f, 17.72f, -6.43f, 2.435f},
new float[]{3.0f, 0.0f, 16.23f, -5.17f, 2.435f},
new float[]{3.0f, 0.0f, 14.75f, -3.90f, 2.435f},
new float[]{3.0f, 0.0f, 13.27f, -2.63f, 2.435f},
new float[]{3.0f, 0.0f, 11.78f, -1.37f, 2.435f},
new float[]{3.0f, 0.0f, 10.30f, -0.10f, 2.435f},
new float[]{3.0f, 0.0f, 8.82f, 1.17f, 2.435f},
new float[]{3.0f, 0.0f, 7.33f, 2.43f, 2.435f},
new float[]{3.0f, 0.0f, 5.85f, 3.70f, 2.435f},
new float[]{3.0f, 0.0f, 4.37f, 4.97f, 2.435f},
new float[]{3.0f, 0.0f, 2.88f, 6.23f, 2.435f},
new float[]{3.0f, 0.0f, 1.40f, 7.50f, 2.435f},
new float[]{3.0f, 0.0f, 1.40f, 7.50f, 1.706f},
new float[]{3.0f, 0.0f, 1.13f, 9.50f, 1.706f},
new float[]{3.0f, 0.0f, 0.86f, 11.50f, 1.706f},
new float[]{3.0f, 0.0f, 0.59f, 13.50f, 1.706f},
new float[]{3.0f, 0.0f, 0.31f, 15.50f, 1.706f},
new float[]{3.0f, 0.0f, 0.04f, 17.50f, 1.706f},
new float[]{3.0f, 0.0f, -0.23f, 19.50f, 1.706f},
new float[]{3.0f, 0.0f, -0.50f, 21.50f, 1.706f},
new float[]{3.0f, 0.0f, -0.77f, 23.50f, 1.706f},
new float[]{3.0f, 0.0f, -1.04f, 25.50f, 1.706f},
new float[]{3.0f, 0.0f, -1.31f, 27.50f, 1.706f},
new float[]{3.0f, 0.0f, -1.59f, 29.50f, 1.706f},
new float[]{3.0f, 0.0f, -1.86f, 31.50f, 1.706f},
new float[]{3.0f, 0.0f, -2.13f, 33.50f, 1.706f},
new float[]{3.0f, 0.0f, -2.40f, 35.50f, 1.706f},
new float[]{3.0f, 0.0f, -2.40f, 35.50f, 1.344f},
new float[]{3.0f, 0.0f, -1.95f, 37.45f, 1.344f},
new float[]{3.0f, 0.0f, -1.50f, 39.39f, 1.344f},
new float[]{3.0f, 0.0f, -1.05f, 41.34f, 1.344f},
new float[]{3.0f, 0.0f, -0.61f, 43.28f, 1.344f},
new float[]{3.0f, 0.0f, -0.16f, 45.23f, 1.344f},
new float[]{3.0f, 0.0f, 0.29f, 47.17f, 1.344f},
new float[]{3.0f, 0.0f, 0.74f, 49.12f, 1.344f},
new float[]{3.0f, 0.0f, 1.19f, 51.07f, 1.344f},
new float[]{3.0f, 0.0f, 1.64f, 53.01f, 1.344f},
new float[]{3.0f, 0.0f, 2.09f, 54.96f, 1.344f},
new float[]{3.0f, 0.0f, 2.53f, 56.90f, 1.344f},
new float[]{3.0f, 0.0f, 2.98f, 58.85f, 1.344f},
new float[]{3.0f, 0.0f, 3.43f, 60.79f, 1.344f},
new float[]{3.0f, 0.0f, 3.88f, 62.74f, 1.344f},
new float[]{3.0f, 0.0f, 4.33f, 64.69f, 1.344f},
new float[]{3.0f, 0.0f, 4.78f, 66.63f, 1.344f},
new float[]{3.0f, 0.0f, 5.23f, 68.58f, 1.344f},
new float[]{3.0f, 0.0f, 5.67f, 70.52f, 1.344f},
new float[]{3.0f, 0.0f, 6.12f, 72.47f, 1.344f},
new float[]{3.0f, 0.0f, 6.57f, 74.41f, 1.344f},
new float[]{3.0f, 0.0f, 7.02f, 76.36f, 1.344f},
new float[]{3.0f, 0.0f, 7.47f, 78.31f, 1.344f},
new float[]{3.0f, 0.0f, 7.92f, 80.25f, 1.344f},
new float[]{3.0f, 0.0f, 8.37f, 82.20f, 1.344f},
new float[]{3.0f, 0.0f, 8.81f, 84.14f, 1.344f},
new float[]{3.0f, 0.0f, 9.26f, 86.09f, 1.344f},
new float[]{3.0f, 0.0f, 9.71f, 88.03f, 1.344f},
new float[]{3.0f, 0.0f, 10.16f, 89.98f, 1.344f},
new float[]{3.0f, 0.0f, 10.61f, 91.93f, 1.344f},
new float[]{3.0f, 0.0f, 11.06f, 93.87f, 1.344f},
new float[]{3.0f, 0.0f, 11.51f, 95.82f, 1.344f},
new float[]{3.0f, 0.0f, 11.95f, 97.76f, 1.344f},
new float[]{3.0f, 0.0f, 12.40f, 99.71f, 1.344f},
new float[]{3.0f, 0.0f, 12.85f, 101.65f, 1.344f},
new float[]{3.0f, 0.0f, 13.30f, 103.60f, 1.344f},
new float[]{3.0f, 0.0f, 13.30f, 103.60f, 1.405f},
new float[]{3.0f, 0.0f, 13.63f, 105.55f, 1.405f},
new float[]{3.0f, 0.0f, 13.95f, 107.51f, 1.405f},
new float[]{3.0f, 0.0f, 14.28f, 109.46f, 1.405f},
new float[]{3.0f, 0.0f, 14.61f, 111.42f, 1.405f},
new float[]{3.0f, 0.0f, 14.94f, 113.37f, 1.405f},
new float[]{3.0f, 0.0f, 15.26f, 115.33f, 1.405f},
new float[]{3.0f, 0.0f, 15.59f, 117.28f, 1.405f},
new float[]{3.0f, 0.0f, 15.92f, 119.24f, 1.405f},
new float[]{3.0f, 0.0f, 16.25f, 121.19f, 1.405f},
new float[]{3.0f, 0.0f, 16.57f, 123.15f, 1.405f},
new float[]{3.0f, 0.0f, 16.90f, 125.10f, 1.405f},
new float[]{3.0f, 0.0f, 16.90f, 125.10f, 0.640f},
new float[]{3.0f, 0.0f, 18.50f, 126.29f, 0.640f},
new float[]{3.0f, 0.0f, 20.10f, 127.48f, 0.640f},
new float[]{3.0f, 0.0f, 21.70f, 128.68f, 0.640f},
new float[]{3.0f, 0.0f, 23.30f, 129.87f, 0.640f},
new float[]{3.0f, 0.0f, 24.90f, 131.06f, 0.640f},
new float[]{3.0f, 0.0f, 26.50f, 132.25f, 0.640f},
new float[]{3.0f, 0.0f, 28.10f, 133.45f, 0.640f},
new float[]{3.0f, 0.0f, 29.70f, 134.64f, 0.640f},
new float[]{3.0f, 0.0f, 31.30f, 135.83f, 0.640f},
new float[]{3.0f, 0.0f, 32.90f, 137.02f, 0.640f},
new float[]{3.0f, 0.0f, 34.50f, 138.22f, 0.640f},
new float[]{3.0f, 0.0f, 36.10f, 139.41f, 0.640f},
new float[]{3.0f, 0.0f, 37.70f, 140.60f, 0.640f},
 };
    float[][] v2 = new float[][] {
new float[]{5, 1, 35.70f, -35.20f, 2.111f},
new float[]{5, 1, 34.67f, -33.48f, 2.111f},
new float[]{5, 1, 33.64f, -31.76f, 2.111f},
new float[]{5, 1, 32.61f, -30.04f, 2.111f},
new float[]{5, 1, 31.58f, -28.33f, 2.111f},
new float[]{5, 1, 30.54f, -26.61f, 2.111f},
new float[]{5, 1, 29.51f, -24.89f, 2.111f},
new float[]{5, 1, 28.48f, -23.17f, 2.111f},
new float[]{5, 1, 27.45f, -21.45f, 2.111f},
new float[]{5, 1, 26.42f, -19.73f, 2.111f},
new float[]{5, 1, 25.39f, -18.01f, 2.111f},
new float[]{5, 1, 24.36f, -16.29f, 2.111f},
new float[]{5, 1, 23.33f, -14.58f, 2.111f},
new float[]{5, 1, 22.29f, -12.86f, 2.111f},
new float[]{5, 1, 21.26f, -11.14f, 2.111f},
new float[]{5, 1, 20.23f, -9.42f, 2.111f},
new float[]{5, 1, 19.20f, -7.70f, 2.111f},
new float[]{5, 1, 19.20f, -7.70f, 2.435f},
new float[]{5, 1, 17.72f, -6.43f, 2.435f},
new float[]{5, 1, 16.23f, -5.17f, 2.435f},
new float[]{5, 1, 14.75f, -3.90f, 2.435f},
new float[]{5, 1, 13.27f, -2.63f, 2.435f},
new float[]{5, 1, 11.78f, -1.37f, 2.435f},
new float[]{5, 1, 10.30f, -0.10f, 2.435f},
new float[]{5, 1, 8.82f, 1.17f, 2.435f},
new float[]{5, 1, 7.33f, 2.43f, 2.435f},
new float[]{5, 1, 5.85f, 3.70f, 2.435f},
new float[]{5, 1, 4.37f, 4.97f, 2.435f},
new float[]{5, 1, 2.88f, 6.23f, 2.435f},
new float[]{5, 1, 1.40f, 7.50f, 2.435f},
new float[]{5, 1, 1.40f, 7.50f, 1.706f},
new float[]{5, 1, 1.13f, 9.50f, 1.706f},
new float[]{5, 1, 0.86f, 11.50f, 1.706f},
new float[]{5, 1, 0.59f, 13.50f, 1.706f},
new float[]{5, 1, 0.31f, 15.50f, 1.706f},
new float[]{5, 1, 0.04f, 17.50f, 1.706f},
new float[]{5, 1, -0.23f, 19.50f, 1.706f},
new float[]{5, 1, -0.50f, 21.50f, 1.706f},
new float[]{5, 1, -0.77f, 23.50f, 1.706f},
new float[]{5, 1, -1.04f, 25.50f, 1.706f},
new float[]{5, 1, -1.31f, 27.50f, 1.706f},
new float[]{5, 1, -1.59f, 29.50f, 1.706f},
new float[]{5, 1, -1.86f, 31.50f, 1.706f},
new float[]{5, 1, -2.13f, 33.50f, 1.706f},
new float[]{5, 1, -2.40f, 35.50f, 1.706f},
new float[]{5, 1, -2.40f, 35.50f, 1.344f},
new float[]{5, 1, -1.95f, 37.45f, 1.344f},
new float[]{5, 1, -1.50f, 39.39f, 1.344f},
new float[]{5, 1, -1.05f, 41.34f, 1.344f},
new float[]{5, 1, -0.61f, 43.28f, 1.344f},
new float[]{5, 1, -0.16f, 45.23f, 1.344f},
new float[]{5, 1, 0.29f, 47.17f, 1.344f},
new float[]{5, 1, 0.74f, 49.12f, 1.344f},
new float[]{5, 1, 1.19f, 51.07f, 1.344f},
new float[]{5, 1, 1.64f, 53.01f, 1.344f},
new float[]{5, 1, 2.09f, 54.96f, 1.344f},
new float[]{5, 1, 2.53f, 56.90f, 1.344f},
new float[]{5, 1, 2.98f, 58.85f, 1.344f},
new float[]{5, 1, 3.43f, 60.79f, 1.344f},
new float[]{5, 1, 3.88f, 62.74f, 1.344f},
new float[]{5, 1, 4.33f, 64.69f, 1.344f},
new float[]{5, 1, 4.78f, 66.63f, 1.344f},
new float[]{5, 1, 5.23f, 68.58f, 1.344f},
new float[]{5, 1, 5.67f, 70.52f, 1.344f},
new float[]{5, 1, 6.12f, 72.47f, 1.344f},
new float[]{5, 1, 6.57f, 74.41f, 1.344f},
new float[]{5, 1, 7.02f, 76.36f, 1.344f},
new float[]{5, 1, 7.47f, 78.31f, 1.344f},
new float[]{5, 1, 7.92f, 80.25f, 1.344f},
new float[]{5, 1, 8.37f, 82.20f, 1.344f},
new float[]{5, 1, 8.81f, 84.14f, 1.344f},
new float[]{5, 1, 9.26f, 86.09f, 1.344f},
new float[]{5, 1, 9.71f, 88.03f, 1.344f},
new float[]{5, 1, 10.16f, 89.98f, 1.344f},
new float[]{5, 1, 10.61f, 91.93f, 1.344f},
new float[]{5, 1, 11.06f, 93.87f, 1.344f},
new float[]{5, 1, 11.51f, 95.82f, 1.344f},
new float[]{5, 1, 11.95f, 97.76f, 1.344f},
new float[]{5, 1, 12.40f, 99.71f, 1.344f},
new float[]{5, 1, 12.85f, 101.65f, 1.344f},
new float[]{5, 1, 13.30f, 103.60f, 1.344f},
new float[]{5, 1, 13.30f, 103.60f, 1.405f},
new float[]{5, 1, 13.63f, 105.55f, 1.405f},
new float[]{5, 1, 13.95f, 107.51f, 1.405f},
new float[]{5, 1, 14.28f, 109.46f, 1.405f},
new float[]{5, 1, 14.61f, 111.42f, 1.405f},
new float[]{5, 1, 14.94f, 113.37f, 1.405f},
new float[]{5, 1, 15.26f, 115.33f, 1.405f},
new float[]{5, 1, 15.59f, 117.28f, 1.405f},
new float[]{5, 1, 15.92f, 119.24f, 1.405f},
new float[]{5, 1, 16.25f, 121.19f, 1.405f},
new float[]{5, 1, 16.57f, 123.15f, 1.405f},
new float[]{5, 1, 16.90f, 125.10f, 1.405f},
new float[]{5, 1, 16.90f, 125.10f, 0.640f},
new float[]{5, 1, 18.50f, 126.29f, 0.640f},
new float[]{5, 1, 20.10f, 127.48f, 0.640f},
new float[]{5, 1, 21.70f, 128.68f, 0.640f},
new float[]{5, 1, 23.30f, 129.87f, 0.640f},
new float[]{5, 1, 24.90f, 131.06f, 0.640f},
new float[]{5, 1, 26.50f, 132.25f, 0.640f},
new float[]{5, 1, 28.10f, 133.45f, 0.640f},
new float[]{5, 1, 29.70f, 134.64f, 0.640f},
new float[]{5, 1, 31.30f, 135.83f, 0.640f},
new float[]{5, 1, 32.90f, 137.02f, 0.640f},
new float[]{5, 1, 34.50f, 138.22f, 0.640f},
new float[]{5, 1, 36.10f, 139.41f, 0.640f},
new float[]{5, 1, 37.70f, 140.60f, 0.640f},
};

    float[][] v3 = {
    new float[] {7, 1, 1.4f, 6.0f, 0.1f},
    new float[] {7, 1, 0.82f, 7.7f, 0.1f},
    new float[] {7, 1, 0.24f, 9.4f, 0.1f},
    new float[] {7, 1, -0.34f, 11.1f, 0.1f},
    new float[] {7, 1, -0.92f, 12.8f, 0.1f},
    new float[] {7, 1, -1.5f, 14.5f, 0.1f},
    new float[] {7, 1, -2.08f, 16.2f, 0.1f},
    new float[] {7, 1, -2.66f, 17.9f, 0.1f},
    new float[] {7, 1, -3.24f, 19.6f, 0.1f},
    new float[] {7, 1, -3.82f, 21.3f, 0.1f},
    new float[] {7, 1, -4.4f, 23.0f, 0.1f},
    new float[] {7, 1, -2.22f, 32.07f, 0.1f},
    new float[] {7, 1, -0.04f, 41.14f, 0.1f},
    new float[] {7, 1, 2.14f, 50.21f, 0.1f},
    new float[] {7, 1, 4.32f, 59.28f, 0.1f},
    new float[] {7, 1, 6.5f, 68.35f, 0.1f},
    new float[] {7, 1, 8.68f, 77.42f, 0.1f},
    new float[] {7, 1, 10.86f, 86.49f, 0.1f},
    new float[] {7, 1, 13.04f, 95.56f, 0.1f},
    new float[] {7, 1, 15.22f, 104.63f, 0.1f},
    new float[] {7, 1, 17.4f, 113.7f, 0.1f}};

    float[][] v4 = {
    new float[] {9, 1, 37.8f, 140.7f, -2.094f},
    new float[] {9, 1, 35.51f, 139.08f, -2.094f},
    new float[] {9, 1, 33.22f, 137.46f, -2.094f},
    new float[] {9, 1, 30.93f, 135.84f, -2.094f},
    new float[] {9, 1, 28.64f, 134.22f, -2.094f},
    new float[] {9, 1, 26.35f, 132.6f, -2.094f},
    new float[] {9, 1, 24.06f, 130.98f, -2.094f},
    new float[] {9, 1, 21.77f, 129.36f, -2.094f},
    new float[] {9, 1, 19.48f, 127.74f, -2.094f},
    new float[] {9, 1, 17.19f, 126.12f, -2.618f},
    new float[] {9, 1, 17.02f, 119.92f, -3.24f},
    new float[] {9, 1, 15.87f, 110.66f, -2.818f},
    new float[] {9, 1, 15.22f, 104.63f, -2.818f},
    new float[] {9, 1, 13.04f, 95.56f, -2.818f},
    new float[] {9, 1, 10.86f, 86.49f, -2.818f},
    new float[] {9, 1, 8.68f, 77.42f, -2.818f},
    new float[] {9, 1, 6.5f, 68.35f, -2.818f},
    new float[] {9, 1, 4.32f, 59.28f, -2.818f},
    new float[] {9, 1, 2.14f, 50.21f, -2.818f},
    new float[] {9, 1, -0.04f, 41.14f, -2.818f},
    new float[] {9, 1, -2.22f, 32.07f, -3.24f},
    new float[] {9, 1, -3.82f, 21.3f, -3.24f},
    new float[] {9, 1, -2.08f, 16.2f, -3.24f},
    new float[] {9, 1, -1.5f, 14.5f, -3.24f},
    new float[] {9, 1, 0.24f, 9.4f, -3.24f},
    new float[] {9, 1, 0.82f, 7.7f, -3.24f},
    new float[] {9, 1, 1.4f, 6.0f, -3.24f}
    };


    void Start()
    {
        // initialize the 2D array for the data from MCS-Core
        rows = VehicleConfiguration.instance.vehicles.Count;
        MCSCoreData = new float[rows, cols];

        combinedArray = new float[][][] { v1, v2, v3, v4 };

        InvokeRepeating("SetVehicleDataEverySecond", 0, 1);

    }



    private void SetVehicleData()
    {
        for (int i = 0; i < VehicleConfiguration.instance.vehicles.Count; i++)
        {
            float id = MCSCoreData[i, 0];
            try
            {
                UpdateVehicleWithId(id);

            }
            catch (System.Collections.Generic.KeyNotFoundException e)
            {
                Debug.LogError(e);
            }
        }
    }


    // OBS: This method will be removed in the final version
    private void SetVehicleDataEverySecond()
    {
        if (index < points)
        {
            for (int i = 0; i < VehicleConfiguration.instance.vehicles.Count; i++)
            {
                float id = combinedArray[i][index][0];
                try
                {
                    UpdateVehicleWithId(id);

                }
                catch (System.Collections.Generic.KeyNotFoundException e)
                {
                    Debug.LogError(e);
                }
            }
            index++;
        }
    }


    public void UpdateVehicleWithId(float id)
    {
        int length = vehicle.Length;
        for (int i = 0; i < length; i++)
        {
            if (vehicle[i].GetComponent<MetaData>().GetId().Equals((int)id))
            {

                vehicle[i].GetComponent<CoordinateBasedMovement>().MovementSystem(combinedArray[i][index][2], combinedArray[i][index][3], -combinedArray[i][index][4]+ Mathf.PI/2, combinedArray[i][index][1]);
                return;
            }
        }
        throw new System.Collections.Generic.KeyNotFoundException("Vehicle id was not found: " + id);
    }
}



