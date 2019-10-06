class Cube(object):
    def __init__(self, settings):
        self.settings = settings
        self.block = list()
        self.create_cube()

    def create_cube(self):
        for z in range(6):
            self.block.append(list())
            for x in range(3):
                self.block[z].append(list())
                for y in range(3):
                    self.block[z][x].append(self.settings.colors[z])
