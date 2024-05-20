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

        float stepDistance = 2.0f;
        ArrayList<float[]> path = generatePath(points, stepDistance);
        
        for (float[] point : path) {
            System.out.printf("new float[]{%.1ff, %.1ff, %.2ff, %.2ff, %.3ff},%n",
                    point[0], point[1], point[2], point[3], point[4]);
        }
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
