import java.awt.*;

class Settings {
    static final int LINE_SIZE = 3;
    static final int BLOCK_SIZE = 60;
    static final Dimension SCREEN_SIZE = setScreenSize();

    static final Color LINE_COLOR = new Color(127, 127, 127);
    static final Color[] COLORS = setCOLORS();

    private Settings() {}

    private static Dimension setScreenSize() {
        int width = 13 * LINE_SIZE + 14 * BLOCK_SIZE + 6;
        int height = 10 * LINE_SIZE + 11 * BLOCK_SIZE + 29;
        return new Dimension(width, height);
    }

    private static Color[] setCOLORS() {
        Color[] colors = new Color[6];
        colors[0] = new Color(0, 0, 255);
        colors[1] = new Color(255, 255,0);
        colors[2] = new Color(255, 0, 0);
        colors[3] = new Color(255, 255, 255);
        colors[4] = new Color(0, 255, 0);
        colors[5] = new Color(255, 127, 0);
        return colors;
    }
}
