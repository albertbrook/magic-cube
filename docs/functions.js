class Functions {
    static getFunctions() {
        if (Functions.functions == undefined) {
            Functions.functions = new Functions();
        }
        return Functions.functions;
    }

    constructor() {
        this.actions = Actions.getActions();
        window.onkeypress = (e) => {
            switch (e.keyCode) {
                case 106:
                    this.actions.upRotate();
                    break;
                case 100:
                    this.actions.downRotate();
                    break;
                case 115:
                    this.actions.leftRotate();
                    break;
                case 105:
                    this.actions.rightRotate();
                    break;
                case 116:
                    this.actions.frontRotate();
                    break;
                case 102:
                    this.actions.backRotate();
                    break;
                case 122:
                    this.actions.xRotate();
                    break;
                case 120:
                    this.actions.yRotate();
                    break;
                case 99:
                    this.actions.zRotate();
                    break;
                case 108:
                    for (let i = 0; i < 3; i++) {
                        this.actions.upRotate();
                    }
                    break;
                case 97:
                    for (let i = 0; i < 3; i++) {
                        this.actions.downRotate();
                    }
                    break;
                case 119:
                    for (let i = 0; i < 3; i++) {
                        this.actions.leftRotate();
                    }
                    break;
                case 107:
                    for (let i = 0; i < 3; i++) {
                        this.actions.rightRotate();
                    }
                    break;
                case 103:
                    for (let i = 0; i < 3; i++) {
                        this.actions.frontRotate();
                    }
                    break;
                case 104:
                    for (let i = 0; i < 3; i++) {
                        this.actions.backRotate();
                    }
                    break;
                case 98:
                    for (let i = 0; i < 3; i++) {
                        this.actions.xRotate();
                    }
                    break;
                case 110:
                    for (let i = 0; i < 3; i++) {
                        this.actions.yRotate();
                    }
                    break;
                case 109:
                    for (let i = 0; i < 3; i++) {
                        this.actions.zRotate();
                    }
                    break;
                case 48:
                    location.reload();
                    break;
            }
        }
    }
}

Functions.getFunctions();
