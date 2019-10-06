class Actions(object):
    def __init__(self, block):
        self.block = block

    def up_rotate(self):
        for i in range(3):
            self.exchange_block([2, 0, i], [4, 0, i], [5, 0, i], [0, 0, i])
        self.clockwise(1)

    def down_rotate(self):
        for i in range(3):
            self.exchange_block([2, 2, i], [0, 2, i], [5, 2, i], [4, 2, i])
        self.clockwise(3)

    def left_rotate(self):
        for i in range(3):
            self.exchange_block([2, i, 0], [1, i, 0], [5, 2 - i, 2], [3, i, 0])
        self.clockwise(0)

    def right_rotate(self):
        for i in range(3):
            self.exchange_block([2, i, 2], [3, i, 2], [5, 2 - i, 0], [1, i, 2])
        self.clockwise(4)

    def front_rotate(self):
        for i in range(3):
            self.exchange_block([1, 2, i], [0, 2 - i, 2], [3, 0, 2 - i], [4, i, 0])
        self.clockwise(2)

    def back_rotate(self):
        for i in range(3):
            self.exchange_block([1, 0, i], [4, i, 2], [3, 2, 2 - i], [0, 2 - i, 0])
        self.clockwise(5)

    def clockwise(self, z):
        self.exchange_block([z, 0, 0], [z, 2, 0], [z, 2, 2], [z, 0, 2])
        self.exchange_block([z, 0, 1], [z, 1, 0], [z, 2, 1], [z, 1, 2])

    def exchange_block(self, *args):
        for i in range(len(args)-1):
            (self.block[args[i][0]][args[i][1]][args[i][2]],
             self.block[args[i + 1][0]][args[i + 1][1]][args[i + 1][2]]) = \
                (self.block[args[i + 1][0]][args[i + 1][1]][args[i + 1][2]],
                 self.block[args[i][0]][args[i][1]][args[i][2]])
