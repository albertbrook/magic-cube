### 原理
断断续续做了半个月了，终于完成了，原理不难，主要难点还是从0到1的过程<br>
#### 数据结构
3d游戏是用4*4的矩阵来完成点的平移，旋转，所以设计数据结构时，一开始打算用四阶矩阵<br>
魔方的旋转角度都是90°，没有平移，所以计算相对容易, 代入sin、cos只有0、1<br>
但一个角块有3种状态，一个棱块有2种状态，除了记录位置，还要记录状态<br>
因为打算做的是一个平面展开图，要映射到上面很麻烦，所以放弃了<br>
<br>
然后打算设计一个类，在类属性里记录周围的块<br>
角块记录周围的3个棱块，棱块记录周围的2个角块<br>
这样可以通过他们的相对关系找到它们的位置<br>
但还是那个问题，映射到平面很麻烦<br>
<br>
最后直接从平面考虑，给每个面标上数字z，x表示行数，y表示列数<br>
如图所示：<br>
<img src="http://m.qpic.cn/psb?/V12HtLmb1YIcpa/E4nlaBm7HLiKD0uoiKrtsUJbFTFHKD5P3CJzZjdTlsQ!/b/dL4AAAAAAAAA&bo=JANpAgAAAAARF2w!&rf=viewer_4" width="402" height="308"></img><br>
比如[2, 0, 1]表示红色面靠黄色面的中间那块<br>
这样的数据结构只要用一个三维数组就可以表示了，而且映射到平面也变简单了<br>
```
for z in range(6):
    self.block.append(list())
    for x in range(3):
        self.block[z].append(list())
        for y in range(3):
            self.block[z][x].append(self.settings.colors[z])
```
#### 绘图
绘图分为两步，先绘制边框再绘制方块，绘制边框比较简单，最先完成的就是它<br>
一开始直接用一根线走到底的方法，用了很多的pygame.draw.line()<br>
后来觉得这样代码不美观，像个二愣子一样，而且计算线的位置也很麻烦<br>
所以决定先用2个for循环来绘制每个面，用i、j来表示3*4的循环，只有在i=1或j=1时才绘制，其余跳过，这样正好绘制6个面<br>
为了计算方便，i从-6循环到3，步长为3，j从-3循环到1，步长为2<br>
```
center = self.screen.get_rect().center
size = self.settings.block_size + self.settings.line_size
for i in range(-6, 6, 3):
    for j in range(-3, 3, 2):
        if i == -3 or j == -1:
            self.draw_block(center[0] + i * size, center[1] + 1.5 * j * size)
```
然后就是绘制每个面的9个块了<br>
```
def draw_block(self, i, j):
    size = self.settings.block_size + self.settings.line_size
    for x in range(3):
        for y in range(3):
            pygame.draw.rect(self.screen, self.settings.line_color,
                             (i + x * size, j + y * size, size + 1, size + 1),
                             self.settings.line_size)
```
一开始的代码只有绘制边框的功能，后来发现这样做不就正好遍历了每个块吗，正好用一个三维数组来放颜色，画边框时顺便方块也画好了，数据结构也有了，我可真是个机灵鬼<br>
```
z = 0
for i in range(-6, 6, 3):
    for j in range(-3, 3, 2):
        if i == -3 or j == -1:
            self.draw_block(···, z)
            z += 1
```
传入每个面的坐标z后就可以绘制每个面的块了<br>
```
pygame.draw.rect(self.screen, self.cube.block[z][x][y],
    (i + y * size + self.settings.line_size // 2 + 1,
     j + x * size + self.settings.line_size // 2 + 1,
     self.settings.block_size, self.settings.block_size))
```
#### 动作
有了数据结构完成面的旋转就容易了，用F面顺时针旋转举例<br>
首先交换侧面的颜色
```
for i in range(3):
    self.exchange_block([1, 2, i], [0, 2 - i, 2], [3, 0, 2 - i], [4, i, 0])
```
exchange_block是一个顺时针交换传入的数据的函数
```
for i in range(len(args)-1):
    (self.block[args[i][0]][args[i][1]][args[i][2]],
     self.block[args[i+1][0]][args[i+1][1]][args[i+1][2]]) = \
        (self.block[args[i+1][0]][args[i+1][1]][args[i+1][2]],
         self.block[args[i][0]][args[i][1]][args[i][2]])
```
因为传入的是三维数组的坐标的原因，代码看上去比较乱，本质上只是利用python的不可变类型数据的特性来交换<br>
然后是面上颜色块的旋转，只要调用exchange_block分别完成角块和棱块的交换就可以了<br>
```
self.exchange_block([z, 0, 0], [z, 2, 0], [z, 2, 2], [z, 0, 2])
self.exchange_block([z, 0, 1], [z, 1, 0], [z, 2, 1], [z, 1, 2])
```
所有面的旋转只是对三维数组做一个计算，这样一个平面魔方模拟器就完成了<br>
### 操作
w = L'<br>
s = L<br>
a = D'<br>
d = D<br>
t = F<br>
g = F'<br>
f = B<br>
h = B'<br>
i = R<br>
k = R'<br>
j = U<br>
l = U'<br>
z = x<br>
x = y<br>
c = z<br>
b = x'<br>
n = y'<br>
m = z'<br>
0 = 魔方复位<br>
左边表示键盘按键，右边表示魔方旋转方式<br>
不带引号表示字母面顺时针旋转，带引号表示字母面逆时针旋转<br>
如R表示右面顺时针旋转90°，R'表示右面逆时针旋转90°（你要喜欢也可以当作顺时针旋转-90°）<br>
魔方旋转方式图：<br>
<img src="http://m.qpic.cn/psb?/V12HtLmb1YIcpa/Z0sBnEZQ23KfX9dteyXd2PIYZfALDrsYah0MhCC.CPA!/b/dFIBAAAAAAAA&bo=ngJ0AgAAAAARF8o!&rf=viewer_4" width="502" height="471"></img><br>
按键图：<br>
<img src="http://m.qpic.cn/psb?/V12HtLmb1YIcpa/A.iB9D0ON1ISLg6sm4xVGB56ni0*0JcA.CdLRl3LWUk!/b/dFMBAAAAAAAA&bo=wwEJAQAAAAARF.o!&rf=viewer_4" width="451" height="265"></img><br>
<br>
<img src="http://m.qpic.cn/psb?/V12HtLmb1YIcpa/LIKOenZh3wEiwp1*4C770FDZCmx8GWyiW51BSstCjr0!/b/dL8AAAAAAAAA&bo=cAGJAAAAAAARB8g!&rf=viewer_4" width="368" height="137"></img><br>
### 一些图案
#### 为了方便操作，字母表示键盘按键
六面回字公式：L D G F S K L D<br>
四色回字公式：F2 S I F S2 F T D L F T I2 G S I<br>
对称棋盘公式：S2 I2 T2 F2 J2 D2<br>
循环棋盘公式：D2 T2 L F2 T2 S2 I2 D K F T A J S I D2 J2 G J2<br>
六面十字公式：F2 G S2 I2 D2 F2 T2 S2 I2 J2 G<br>
四面十字公式：D T2 I2 T2 A J I2 T2 I2 L<br>
双色十字公式：L D G F S K L D S2 I2 T2 F2 J2 D2<br>
三色十字公式：F G S2 I2 J A<br>
四色十字公式：J2 I F D F G W L F G S T W I D J2 G K J2<br>
五彩十字公式：S2 A T2 D F D S T K L K A T S2 F T2 S<br>
六面皇后公式：I2 F2 J2 S2 F2 J2 T2 S2 D W I T S2 G L D S<br>
六面五色公式：J F2 S2 F G J G D2 S D2 T D I2 T2 K H L K<br>
六面六色公式：D2 J2 S2 F I2 A S2 I2 D2 F2 T2 L I2 H I2<br>
六面彩条公式：T2 J2 T2 F2 J2 T F<br>
六面三条公式：(J2 S2)3 (J2 I2)3 J D S2 I2<br>
六面凹字公式：T2 W I F2 J2 S K D2<br>
六面凹字公式：J D S2 T2 J A F2 I2 D2<br>
六面凸字公式：T2 I T2 K J2 T2 S J2 F2 J2 G J2 I A F2 D G D2 I T<br>
六面工字公式：D2 S K D2 L2 S K L2<br>
六面Q字公式：D T2 L F G S K D S2 L F I2 H J S2 L<br>
六面J字公式：D2 S2 D I2 J F2 J2 F K H D F2 K T I2 G J K<br>
六面S字公式：S I J D G H S I<br>
六面彩E公式：T2 I2 T2 L K F2 T S K J W I J F J2 T2 A L<br>
六面C J公式：A J F A W I T A H A J S<br>
六面T字公式：J2 T2 I2 D L S2 F2 D J 或者 F2 D2 S K D2 F2 S K<br>
四面Z字公式：( T F I S )3 (J A )2<br>
四面I字公式：I2 T2 I2 S2 T2 S2<br>
四面S字公式：F T D J S2 D L F G<br>
四面O字公式：J I2 S2 J A T2 F2 A<br>
四面E字公式：I2 J2 T2 I2 J2 I2 T2 J2<br>
四面V Y公式：D2 I S J2 I2 S2 J2 I S<br>
四面C J公式：I2 T2 F2 S2 J T2 I2 S2 F2 A<br>
C C T V公式一 F2 I2 D2 J2 T2 S K J2 W K<br>
C C T V公式二 S2 F2 I2 D2 I2 T2 J2 T2 I2 J2 I2<br>
六面斜线公式：F S2 J2 S2 H G J2 K F T I2 A S K A J I G<br>
三色斜线公式：I T2 W D2 T2 W I2 H W H G A J I G D K F K<br>
四面斜线公式：T F S I T F S I T F S I<br>
大小魔方公式：J2 S2 T2 L F2 D I G I G I G A F2 L<br>
大中小魔公式：FW D2SDG D2TA H G IJ2K L FJ2H JT (K D2IH J2F)2<br>
大中小魔公式：T D2 S2 F D H T2 L T J T2 J2 G S D G J<br>
六面弓箭公式：I J T2 A I W T H A G I T2 I J2 T I2 G K L G J2 T I<br>
六面双环公式：F I W A I2 D K S H I2 J F2 L D F2 I S J2 K W F2 A<br>
六面蛇形公式：F I W A I2 D K S H I2 J F2 L D I2 A<br>
彩带魔方公式：D2 W J2 TS2 D2 J I2 D S2 H S2 J S A I2 L<br>
六面鱼形公式：S D F2 J I2 F2 D W F2 G A J K D2 K F2 G L G