import java.awt.*;
import java.awt.event.*;

class Functions {
    private static Functions functions;

    private Main main;
    private Cube cube;
    private Actions actions;

    private Canvas canvas = setCanvas();

    private Functions(Main main) {
        this.main = main;
        this.cube = Cube.getCube();
        this.actions = Actions.getActions();

        this.main.add(canvas);
    }

    static Functions getFunctions(Main main) {
        if (functions == null)
            functions = new Functions(main);
        return functions;
    }

    private Canvas setCanvas() {
        return new Canvas() {
            @Override
            public void paint(Graphics g) {
                Graphics2D g2 = (Graphics2D) g;
                g2.setStroke(new BasicStroke(Settings.LINE_SIZE));
                int z = 0;
                for (int i = 0; i < 12; i += 3)
                    for (int j = 0; j < 9; j += 3) {
                        if (i == 3 || j == 3) {
                            drawPlane(i, j, g2);
                            fillPlane(i, j, z++, g2);
                        }
                    }
            }

            @Override
            public void update(Graphics g) {
                paint(g);
            }
        };
    }

    private void drawPlane(int i, int j, Graphics2D g2) {
        g2.setColor(Settings.LINE_COLOR);
        int location = Settings.LINE_SIZE / 2 + Settings.BLOCK_SIZE;
        int size = Settings.LINE_SIZE + Settings.BLOCK_SIZE;
        for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++)
                g2.drawRect(location + (i + x) * size, location + (j + y) * size, size, size);
    }

    private void fillPlane(int i, int j, int z, Graphics2D g2) {
        int size = Settings.LINE_SIZE + Settings.BLOCK_SIZE;
        for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++) {
                g2.setColor(cube.getBlock()[z][x][y]);
                g2.fillRect((i + y + 1) * size, (j + x + 1) * size, Settings.BLOCK_SIZE, Settings.BLOCK_SIZE);
            }
    }

    void event() {
        KeyAdapter keyAdapter = new KeyAdapter() {
            @Override
            public void keyPressed(KeyEvent e) {
                switch (e.getKeyCode()) {
                    case KeyEvent.VK_J:
                        actions.upRotate();
                        break;
                    case KeyEvent.VK_D:
                        actions.downRotate();
                        break;
                    case KeyEvent.VK_S:
                        actions.leftRotate();
                        break;
                    case KeyEvent.VK_I:
                        actions.rightRotate();
                        break;
                    case KeyEvent.VK_T:
                        actions.frontRotate();
                        break;
                    case KeyEvent.VK_F:
                        actions.backRotate();
                        break;
                    case KeyEvent.VK_Z:
                        actions.xRotate();
                        break;
                    case KeyEvent.VK_X:
                        actions.yRotate();
                        break;
                    case KeyEvent.VK_C:
                        actions.zRotate();
                        break;
                    case KeyEvent.VK_L:
                        for (int i = 0; i < 3; i++) {
                            actions.upRotate();
                        }
                        break;
                    case KeyEvent.VK_A:
                        for (int i = 0; i < 3; i++) {
                            actions.downRotate();
                        }
                        break;
                    case KeyEvent.VK_W:
                        for (int i = 0; i < 3; i++) {
                            actions.leftRotate();
                        }
                        break;
                    case KeyEvent.VK_K:
                        for (int i = 0; i < 3; i++) {
                            actions.rightRotate();
                        }
                        break;
                    case KeyEvent.VK_G:
                        for (int i = 0; i < 3; i++) {
                            actions.frontRotate();
                        }
                        break;
                    case KeyEvent.VK_H:
                        for (int i = 0; i < 3; i++) {
                            actions.backRotate();
                        }
                        break;
                    case KeyEvent.VK_B:
                        for (int i = 0; i < 3; i++) {
                            actions.xRotate();
                        }
                        break;
                    case KeyEvent.VK_N:
                        for (int i = 0; i < 3; i++) {
                            actions.yRotate();
                        }
                        break;
                    case KeyEvent.VK_M:
                        for (int i = 0; i < 3; i++) {
                            actions.zRotate();
                        }
                        break;
                    case KeyEvent.VK_0:
                        cube.init();
                        break;
                }
                canvas.repaint();
            }
        };
        main.addKeyListener(keyAdapter);
        canvas.addKeyListener(keyAdapter);
    }
}
