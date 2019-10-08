import pygame


class Functions(object):
    def __init__(self, settings, screen, cube, actions):
        self.settings = settings
        self.screen = screen
        self.cube = cube
        self.actions = actions

    def check_events(self):
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                pygame.quit()
                exit()
            if event.type == pygame.KEYDOWN:
                if event.key == pygame.K_j:
                    self.actions.up_rotate()
                elif event.key == pygame.K_d:
                    self.actions.down_rotate()
                elif event.key == pygame.K_s:
                    self.actions.left_rotate()
                elif event.key == pygame.K_i:
                    self.actions.right_rotate()
                elif event.key == pygame.K_t:
                    self.actions.front_rotate()
                elif event.key == pygame.K_f:
                    self.actions.back_rotate()
                elif event.key == pygame.K_z:
                    self.actions.x_rotate()
                elif event.key == pygame.K_x:
                    self.actions.y_rotate()
                elif event.key == pygame.K_c:
                    self.actions.z_rotate()
                elif event.key == pygame.K_l:
                    for i in range(3):
                        self.actions.up_rotate()
                elif event.key == pygame.K_a:
                    for i in range(3):
                        self.actions.down_rotate()
                elif event.key == pygame.K_w:
                    for i in range(3):
                        self.actions.left_rotate()
                elif event.key == pygame.K_k:
                    for i in range(3):
                        self.actions.right_rotate()
                elif event.key == pygame.K_g:
                    for i in range(3):
                        self.actions.front_rotate()
                elif event.key == pygame.K_h:
                    for i in range(3):
                        self.actions.back_rotate()
                elif event.key == pygame.K_b:
                    for i in range(3):
                        self.actions.x_rotate()
                elif event.key == pygame.K_n:
                    for i in range(3):
                        self.actions.y_rotate()
                elif event.key == pygame.K_m:
                    for i in range(3):
                        self.actions.z_rotate()
                elif event.key == pygame.K_r:
                    self.cube.block.clear()
                    self.cube.create_cube()

    def draw_screen(self):
        center = self.screen.get_rect().center
        size = self.settings.block_size + self.settings.line_size
        z = 0
        for i in range(-6, 6, 3):
            for j in range(-3, 3, 2):
                if i == -3 or j == -1:
                    self.draw_block(center[0] + i * size, center[1] + 1.5 * j * size, z)
                    z += 1
        pygame.display.flip()

    def draw_block(self, i, j, z):
        size = self.settings.block_size + self.settings.line_size
        for x in range(3):
            for y in range(3):
                pygame.draw.rect(self.screen, self.settings.line_color,
                                 (i + x * size, j + y * size, size + 1, size + 1),
                                 self.settings.line_size)
                pygame.draw.rect(self.screen, self.cube.block[z][x][y],
                                 (i + y * size + self.settings.line_size // 2 + 1,
                                  j + x * size + self.settings.line_size // 2 + 1,
                                  self.settings.block_size, self.settings.block_size))
