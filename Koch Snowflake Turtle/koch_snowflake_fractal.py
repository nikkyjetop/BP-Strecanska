import turtle

def draw_koch_segment(length, depth):
    if depth == 0:
        turtle.forward(length)
    else:
        length /= 3.0
        draw_koch_segment(length, depth - 1)
        turtle.left(60)
        draw_koch_segment(length, depth - 1)
        turtle.right(120)
        draw_koch_segment(length, depth - 1)
        turtle.left(60)
        draw_koch_segment(length, depth - 1)

def draw_snowflake(length, depth):
    for _ in range(3):
        draw_koch_segment(length, depth)
        turtle.right(120)

turtle.speed(0)
turtle.bgcolor("lightblue")
turtle.color("white")
turtle.penup()
turtle.goto(-150, 90)
turtle.pendown()

draw_snowflake(300, 0)
turtle.hideturtle()

canvas = turtle.getcanvas()
canvas.postscript(file="snowflake.eps")


print("Saved as snowflake.eps")
turtle.done()
