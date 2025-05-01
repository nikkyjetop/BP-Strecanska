import turtle

# Nastavení plátna
screen = turtle.Screen()
screen.setup(width=1920, height=1080)
screen.bgcolor("white")  # bílé pozadí, dá se snadno odstranit

# Nastavení želvy
t = turtle.Turtle()
t.hideturtle()
t.speed(0)
t.color("black")
t.pensize(4)

# Kreslení čar
y = -540
while y <= 540:
    t.penup()
    t.goto(-960, y)
    t.pendown()
    t.forward(1920)
    y += 8

# Uložení
canvas = turtle.getcanvas()
canvas.postscript(file="horizontal_lines.eps", colormode='color')
print("Uloženo jako horizontal_lines.eps")
turtle.done()
