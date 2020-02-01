import pygame
from settings import Settings
from functions import Functions
from cube import Cube
from actions import Actions


class Game(object):
    def __init__(self):
        pygame.init()
        self.settings = Settings()
        self.screen = pygame.display.set_mode(self.settings.screen_size)
        self.cube = Cube(self.settings)
        self.actions = Actions(self.cube.block)
        self.functions = Functions(self.settings, self.screen, self.cube, self.actions)

    def start(self):
        while True:
            self.functions.check_events()
            self.functions.draw_screen()


if __name__ == '__main__':
    game = Game()
    game.start()
