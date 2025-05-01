import turtle

def draw_fan_branch(length, depth):
    if depth == 0:
        turtle.forward(length)
        turtle.backward(length)
    else:
        turtle.forward(length / 3)
        turtle.left(20)
        draw_fan_branch(length / 1.5, depth - 1)
        turtle.right(40)
        draw_fan_branch(length / 1.5, depth - 1)
        turtle.left(20)
        turtle.backward(length / 3)

def draw_fanflake(arms, length, depth):
    for _ in range(arms):
        draw_fan_branch(length, depth)
        turtle.right(360 / arms)

turtle.speed(0)
turtle.bgcolor("white")
turtle.color("black")
turtle.penup()
turtle.goto(0, -50)
turtle.pendown()
turtle.setheading(90)

draw_fanflake(8, 300, 8)

turtle.hideturtle()
canvas = turtle.getcanvas()
canvas.postscript(file="fanflake.eps")
turtle.done()
