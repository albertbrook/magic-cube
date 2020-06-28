class Paint {
    static getPaint() {
        if (Paint.paint == undefined) {
            Paint.paint = new Paint();
        }
        return Paint.paint;
    }

    constructor() {
        this.size = Settings.blockSize + Settings.lineSize;
        window.onload = () => {
            document.body.style.backgroundColor = "black";
            document.body.innerHTML = "<div id='box' style='position:absolute'></div>";
            const box = document.getElementById("box");
            this.reset();
            this.drawAll();
            const divs = box.getElementsByTagName("div");
            for (let i = 0; i < divs.length; i++) {
                divs[i].style.width = Settings.blockSize + "px";
                divs[i].style.height = Settings.blockSize + "px";
                divs[i].style.border = Settings.lineSize + "px solid " + Settings.lineColor;
                divs[i].style.position = "absolute";
            }
        }
        window.onresize = () => {
            this.reset();
        }
    }

    reset() {
        box.style.left = (document.documentElement.clientWidth - 12 * this.size) / 2 + "px";
        box.style.top = (document.documentElement.clientHeight - 9 * this.size) / 2 + "px";
    }

    drawAll() {
        let z = 0;
        for (let i = 0; i < 4; i++) {
            for (let j = 0; j < 3; j++) {
                if (i == 1 || j == 1) {
                    this.drawPlane(i * this.size * 3, j * this.size * 3, z++);
                }
            }
        }
    }

    drawPlane(x, y, z) {
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++) {
                box.innerHTML += "<div id='" + z + j + i + "'></div>";
                const div = document.getElementById("" + z + j + i);
                div.style.left = x + i * this.size + "px";
                div.style.top = y + j * this.size + "px";
                div.style.backgroundColor = Settings.colors[z];
            }
        }
    }
}

Paint.getPaint();
