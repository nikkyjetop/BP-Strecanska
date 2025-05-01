import turtle

screen = turtle.Screen()
screen.setup(width=1920, height=1080)
screen.bgcolor("white")

t = turtle.Turtle()
t.hideturtle()
t.speed(0)
t.color("black")
t.pensize(4)

y = -540
while y <= 540:
    t.penup()
    t.goto(-960, y)
    t.pendown()
    t.forward(1920)
    y += 8

canvas = turtle.getcanvas()
canvas.postscript(file="horizontal_lines.eps", colormode='color')
turtle.done()
