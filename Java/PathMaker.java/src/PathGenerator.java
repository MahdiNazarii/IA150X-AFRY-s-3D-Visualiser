import java.util.ArrayList;

public class PathGenerator {
    public static void main(String[] args) {
        float[][] points = new float[][]{
            {35.7f, -35.2f},
            {19.2f, -7.7f},
            {1.4f, 7.5f},
            {-2.4f, 35.5f},
            {13.3f, 103.6f},
            {16.9f, 125.1f},
            {37.7f, 140.6f},
            
            
        };
        String yoyo ="new float[]{3.0f, 0.0f, 35.70f, -35.20f, 2.111f},\nnew float[]{3.0f, 0.0f, 34.67f, -33.48f, 2.111f},\nnew float[]{3.0f, 0.0f, 33.64f, -31.76f, 2.111f},\nnew float[]{3.0f, 0.0f, 32.61f, -30.04f, 2.111f},\nnew float[]{3.0f, 0.0f, 31.58f, -28.33f, 2.111f},\nnew float[]{3.0f, 0.0f, 30.54f, -26.61f, 2.111f},\nnew float[]{3.0f, 0.0f, 29.51f, -24.89f, 2.111f},\nnew float[]{3.0f, 0.0f, 28.48f, -23.17f, 2.111f},\nnew float[]{3.0f, 0.0f, 27.45f, -21.45f, 2.111f},\nnew float[]{3.0f, 0.0f, 26.42f, -19.73f, 2.111f},\nnew float[]{3.0f, 0.0f, 25.39f, -18.01f, 2.111f},\nnew float[]{3.0f, 0.0f, 24.36f, -16.29f, 2.111f},\nnew float[]{3.0f, 0.0f, 23.33f, -14.58f, 2.111f},\nnew float[]{3.0f, 0.0f, 22.29f, -12.86f, 2.111f},\nnew float[]{3.0f, 0.0f, 21.26f, -11.14f, 2.111f},\nnew float[]{3.0f, 0.0f, 20.23f, -9.42f, 2.111f},\nnew float[]{3.0f, 0.0f, 19.20f, -7.70f, 2.111f},\nnew float[]{3.0f, 0.0f, 19.20f, -7.70f, 2.435f},\nnew float[]{3.0f, 0.0f, 17.72f, -6.43f, 2.435f},\nnew float[]{3.0f, 0.0f, 16.23f, -5.17f, 2.435f},\nnew float[]{3.0f, 0.0f, 14.75f, -3.90f, 2.435f},\nnew float[]{3.0f, 0.0f, 13.27f, -2.63f, 2.435f},\n"
        new float[]{3.0f, 0.0f, 11.78f, -1.37f, 2.435f},\n
        new float[]{3.0f, 0.0f, 10.30f, -0.10f, 2.435f},\n
        new float[]{3.0f, 0.0f, 8.82f, 1.17f, 2.435f},\n
        new float[]{3.0f, 0.0f, 7.33f, 2.43f, 2.435f},\n
        new float[]{3.0f, 0.0f, 5.85f, 3.70f, 2.435f},\n
        new float[]{3.0f, 0.0f, 4.37f, 4.97f, 2.435f},\n
        new float[]{3.0f, 0.0f, 2.88f, 6.23f, 2.435f},\n
        new float[]{3.0f, 0.0f, 1.40f, 7.50f, 2.435f},\n
        new float[]{3.0f, 0.0f, 1.40f, 7.50f, 1.706f},\n
        new float[]{3.0f, 0.0f, 1.13f, 9.50f, 1.706f},\n
        new float[]{3.0f, 0.0f, 0.86f, 11.50f, 1.706f},\n
        new float[]{3.0f, 0.0f, 0.59f, 13.50f, 1.706f},\n
        new float[]{3.0f, 0.0f, 0.31f, 15.50f, 1.706f},\n
        new float[]{3.0f, 0.0f, 0.04f, 17.50f, 1.706f},\n
        new float[]{3.0f, 0.0f, -0.23f, 19.50f, 1.706f},\n
        new float[]{3.0f, 0.0f, -0.50f, 21.50f, 1.706f},\n
        new float[]{3.0f, 0.0f, -0.77f, 23.50f, 1.706f},\n
        new float[]{3.0f, 0.0f, -1.04f, 25.50f, 1.706f},\n
        new float[]{3.0f, 0.0f, -1.31f, 27.50f, 1.706f},\n
        new float[]{3.0f, 0.0f, -1.59f, 29.50f, 1.706f},\n
        new float[]{3.0f, 0.0f, -1.86f, 31.50f, 1.706f},\n
        new float[]{3.0f, 0.0f, -2.13f, 33.50f, 1.706f},\n
        new float[]{3.0f, 0.0f, -2.40f, 35.50f, 1.706f},\n
        new float[]{3.0f, 0.0f, -2.40f, 35.50f, 1.344f},\n
        new float[]{3.0f, 0.0f, -1.95f, 37.45f, 1.344f},\n
        new float[]{3.0f, 0.0f, -1.50f, 39.39f, 1.344f},\n
        new float[]{3.0f, 0.0f, -1.05f, 41.34f, 1.344f},\n
        new float[]{3.0f, 0.0f, -0.61f, 43.28f, 1.344f},\n
        new float[]{3.0f, 0.0f, -0.16f, 45.23f, 1.344f},\n
        new float[]{3.0f, 0.0f, 0.29f, 47.17f, 1.344f},\n
        new float[]{3.0f, 0.0f, 0.74f, 49.12f, 1.344f},\n
        new float[]{3.0f, 0.0f, 1.19f, 51.07f, 1.344f},\n
        new float[]{3.0f, 0.0f, 1.64f, 53.01f, 1.344f},\n
        new float[]{3.0f, 0.0f, 2.09f, 54.96f, 1.344f},\n
        new float[]{3.0f, 0.0f, 2.53f, 56.90f, 1.344f},\n
        new float[]{3.0f, 0.0f, 2.98f, 58.85f, 1.344f},\n
        new float[]{3.0f, 0.0f, 3.43f, 60.79f, 1.344f},\n
        new float[]{3.0f, 0.0f, 3.88f, 62.74f, 1.344f},\n
        new float[]{3.0f, 0.0f, 4.33f, 64.69f, 1.344f},\n
        new float[]{3.0f, 0.0f, 4.78f, 66.63f, 1.344f},\n
        new float[]{3.0f, 0.0f, 5.23f, 68.58f, 1.344f},\n
        new float[]{3.0f, 0.0f, 5.67f, 70.52f, 1.344f},\n
        new float[]{3.0f, 0.0f, 6.12f, 72.47f, 1.344f},\n
        new float[]{3.0f, 0.0f, 6.57f, 74.41f, 1.344f},\n
        new float[]{3.0f, 0.0f, 7.02f, 76.36f, 1.344f},\n
        new float[]{3.0f, 0.0f, 7.47f, 78.31f, 1.344f},\n
        new float[]{3.0f, 0.0f, 7.92f, 80.25f, 1.344f},\n
        new float[]{3.0f, 0.0f, 8.37f, 82.20f, 1.344f},\n
        new float[]{3.0f, 0.0f, 8.81f, 84.14f, 1.344f},\n
        new float[]{3.0f, 0.0f, 9.26f, 86.09f, 1.344f},\n
        new float[]{3.0f, 0.0f, 9.71f, 88.03f, 1.344f},\n
        new float[]{3.0f, 0.0f, 10.16f, 89.98f, 1.344f},\n
        new float[]{3.0f, 0.0f, 10.61f, 91.93f, 1.344f},\n
        new float[]{3.0f, 0.0f, 11.06f, 93.87f, 1.344f},\n
        new float[]{3.0f, 0.0f, 11.51f, 95.82f, 1.344f},\n
        new float[]{3.0f, 0.0f, 11.95f, 97.76f, 1.344f},\n
        new float[]{3.0f, 0.0f, 12.40f, 99.71f, 1.344f},\n
        new float[]{3.0f, 0.0f, 12.85f, 101.65f, 1.344f},\n
        new float[]{3.0f, 0.0f, 13.30f, 103.60f, 1.344f},\n
        new float[]{3.0f, 0.0f, 13.30f, 103.60f, 1.405f},\n
        new float[]{3.0f, 0.0f, 13.63f, 105.55f, 1.405f},\n
        new float[]{3.0f, 0.0f, 13.95f, 107.51f, 1.405f},\n
        new float[]{3.0f, 0.0f, 14.28f, 109.46f, 1.405f},\n
        new float[]{3.0f, 0.0f, 14.61f, 111.42f, 1.405f},\n
        new float[]{3.0f, 0.0f, 14.94f, 113.37f, 1.405f},\n
        new float[]{3.0f, 0.0f, 15.26f, 115.33f, 1.405f},\n
        new float[]{3.0f, 0.0f, 15.59f, 117.28f, 1.405f},\n
        new float[]{3.0f, 0.0f, 15.92f, 119.24f, 1.405f},\n
        new float[]{3.0f, 0.0f, 16.25f, 121.19f, 1.405f},\n
        new float[]{3.0f, 0.0f, 16.57f, 123.15f, 1.405f},\n
        new float[]{3.0f, 0.0f, 16.90f, 125.10f, 1.405f},\n
        new float[]{3.0f, 0.0f, 16.90f, 125.10f, 0.640f},\n
        new float[]{3.0f, 0.0f, 18.50f, 126.29f, 0.640f},\n
        new float[]{3.0f, 0.0f, 20.10f, 127.48f, 0.640f},\n
        new float[]{3.0f, 0.0f, 21.70f, 128.68f, 0.640f},\n
        new float[]{3.0f, 0.0f, 23.30f, 129.87f, 0.640f},\n
        new float[]{3.0f, 0.0f, 24.90f, 131.06f, 0.640f},\n
        new float[]{3.0f, 0.0f, 26.50f, 132.25f, 0.640f},\n
        new float[]{3.0f, 0.0f, 28.10f, 133.45f, 0.640f},\n
        new float[]{3.0f, 0.0f, 29.70f, 134.64f, 0.640f},\n
        new float[]{3.0f, 0.0f, 31.30f, 135.83f, 0.640f},\n
        new float[]{3.0f, 0.0f, 32.90f, 137.02f, 0.640f},\n
        new float[]{3.0f, 0.0f, 34.50f, 138.22f, 0.640f},\n
        new float[]{3.0f, 0.0f, 36.10f, 139.41f, 0.640f},\n
        new float[]{3.0f, 0.0f, 37.70f, 140.60f, 0.640f},"
        String[] lines = yoyo.split("\n")
        System.out.println(lines[1]);
        //float stepDistance = 2.0f;
        //ArrayList<float[]> path = generatePath(points, stepDistance);
        //
        //for (float[] point : path) {
        //    System.out.printf("new float[]{%.1ff, %.1ff, %.2ff, %.2ff, %.3ff},%n",
        //            point[0], point[1], point[2], point[3], point[4]);
        //}
    }

    public static ArrayList<float[]> generatePath(float[][] points, float stepDistance) {
        ArrayList<float[]> path = new ArrayList<>();
        
        for (int i = 0; i < points.length - 1; i++) {
            float x1 = points[i][0];
            float z1 = points[i][1];
            float x2 = points[i + 1][0];
            float z2 = points[i + 1][1];
            
            float dx = x2 - x1;
            float dz = z2 - z1;
            float distance = (float) Math.sqrt(dx * dx + dz * dz);
            int numSteps = Math.max(1, Math.round(distance / stepDistance));
            
            for (int j = 0; j <= numSteps; j++) {
                float t = (float) j / numSteps;
                float x = x1 + t * dx;
                float z = z1 + t * dz;
                float angle = (float) Math.atan2(dz, dx);
                
                path.add(new float[]{3, 0, x, z, angle});
            }
        }
        
        return path;
    }
}
