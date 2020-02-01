import java.awt.*;

class Actions {
    private static Actions actions;

    private Color[][][] block;

    private Actions() {
        this.block = Cube.getCube().getBlock();
    }

    static Actions getActions() {
        if (actions == null)
            actions = new Actions();
        return actions;
    }

    void upRotate() {
        for (int i = 0; i < 3; i++) {
            exchangeBlock(new int[][]{{2, 0, i}, {4, 0, i}, {5, 0, i}, {0, 0, i}});
        }
        clockwise(1);
    }

    void downRotate() {
        for (int i = 0; i < 3; i++)
            exchangeBlock(new int[][]{{2, 2, i}, {0, 2, i}, {5, 2, i}, {4, 2, i}});
        clockwise(3);
    }

    void leftRotate() {
        for (int i = 0; i < 3; i++)
            exchangeBlock(new int[][]{{2, i, 0}, {1, i, 0}, {5, 2 - i, 2}, {3, i, 0}});
        clockwise(0);
    }

    void rightRotate() {
        for (int i = 0; i < 3; i++)
            exchangeBlock(new int[][]{{2, i, 2}, {3, i, 2}, {5, 2 - i, 0}, {1, i, 2}});
        clockwise(4);
    }

    void frontRotate() {
        for (int i = 0; i < 3; i++)
            exchangeBlock(new int[][]{{1, 2, i}, {0, 2 - i, 2}, {3, 0, 2 - i}, {4, i, 0}});
        clockwise(2);
    }

    void backRotate() {
        for (int i = 0; i < 3; i++)
            exchangeBlock(new int[][]{{1, 0, i}, {4, i, 2}, {3, 2, 2 - i}, {0, 2 - i, 0}});
        clockwise(5);
    }

    void xRotate() {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++)
                exchangeBlock(new int[][]{{2, i, j}, {3, i, j}, {5, 2 - i, 2 - j}, {1, i, j}});
            clockwise(0);
        }
        clockwise(4);
    }

    void yRotate() {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++)
                exchangeBlock(new int[][]{{2, i, j}, {4, i, j}, {5, i, j}, {0, i, j}});
            clockwise(3);
        }
        clockwise(1);
    }

    void zRotate() {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++)
                exchangeBlock(new int[][]{{1, i, j}, {0, 2 - j, i}, {3, 2 - i, 2 - j}, {4, j, 2 - i}});
            clockwise(5);
        }
        clockwise(2);
    }

    private void clockwise(int z) {
        exchangeBlock(new int[][]{{z, 0, 0}, {z, 2, 0}, {z, 2, 2}, {z, 0, 2}});
        exchangeBlock(new int[][]{{z, 0, 1}, {z, 1, 0}, {z, 2, 1}, {z, 1, 2}});
    }

    private void exchangeBlock(int[][] is) {
        for (int i = 0; i < is.length - 1; i++) {
            Color temp = block[is[i][0]][is[i][1]][is[i][2]];
            block[is[i][0]][is[i][1]][is[i][2]] = block[is[i + 1][0]][is[i + 1][1]][is[i + 1][2]];
            block[is[i + 1][0]][is[i + 1][1]][is[i + 1][2]] = temp;
        }
    }
}
