class Actions {
    static getActions() {
        if (Actions.actions == undefined) {
            Actions.actions = new Actions();
        }
        return Actions.actions;
    }

    upRotate() {
        for (let i = 0; i < 3; i++) {
            this.exchangeBlock([[2, 0, i], [4, 0, i], [5, 0, i], [0, 0, i]]);
        }
        this.clockwise(1);
    }
    
    downRotate() {
        for (let i = 0; i < 3; i++)
            this.exchangeBlock([[2, 2, i], [0, 2, i], [5, 2, i], [4, 2, i]]);
        this.clockwise(3);
    }
    
    leftRotate() {
        for (let i = 0; i < 3; i++)
            this.exchangeBlock([[2, i, 0], [1, i, 0], [5, 2 - i, 2], [3, i, 0]]);
        this.clockwise(0);
    }
    
    rightRotate() {
        for (let i = 0; i < 3; i++)
            this.exchangeBlock([[2, i, 2], [3, i, 2], [5, 2 - i, 0], [1, i, 2]]);
        this.clockwise(4);
    }
    
    frontRotate() {
        for (let i = 0; i < 3; i++)
            this.exchangeBlock([[1, 2, i], [0, 2 - i, 2], [3, 0, 2 - i], [4, i, 0]]);
        this.clockwise(2);
    }
    
    backRotate() {
        for (let i = 0; i < 3; i++)
            this.exchangeBlock([[1, 0, i], [4, i, 2], [3, 2, 2 - i], [0, 2 - i, 0]]);
        this.clockwise(5);
    }
    
    xRotate() {
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++)
                this.exchangeBlock([[2, i, j], [3, i, j], [5, 2 - i, 2 - j], [1, i, j]]);
            this.clockwise(0);
        }
        this.clockwise(4);
    }
    
    yRotate() {
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++)
                this.exchangeBlock([[2, i, j], [4, i, j], [5, i, j], [0, i, j]]);
            this.clockwise(3);
        }
        this.clockwise(1);
    }
    
    zRotate() {
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++)
                this.exchangeBlock([[1, i, j], [0, 2 - j, i], [3, 2 - i, 2 - j], [4, j, 2 - i]]);
            this.clockwise(5);
        }
        this.clockwise(2);
    }
    
    clockwise(z) {
        this.exchangeBlock([[z, 0, 0], [z, 2, 0], [z, 2, 2], [z, 0, 2]]);
        this.exchangeBlock([[z, 0, 1], [z, 1, 0], [z, 2, 1], [z, 1, 2]]);
    }
    
    exchangeBlock(is) {
        for (let i = 0; i < is.length - 1; i++) {
            const block1 = document.getElementById("" + is[i][0] + is[i][1] + is[i][2]);
            const block2 = document.getElementById("" + is[i + 1][0] + is[i + 1][1] + is[i + 1][2]);
            const temp = block1.style.backgroundColor;
            block1.style.backgroundColor = block2.style.backgroundColor;
            block2.style.backgroundColor = temp;
        }
    }    
}
