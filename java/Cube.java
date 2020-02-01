import java.awt.*;

class Cube {
    private static Cube cube;

    private Color[][][] block = new Color[6][3][3];

    private Cube() {
        init();
    }

    static Cube getCube() {
        if (cube == null)
            cube = new Cube();
        return cube;
    }

    void init() {
        for (int z = 0; z < block.length; z++) {
            for (int x = 0; x < block[z].length; x++) {
                for (int y = 0; y < block[z][x].length; y++) {
                    block[z][x][y] = Settings.COLORS[z];
                }
            }
        }
    }

    Color[][][] getBlock() {
        return block;
    }
}
