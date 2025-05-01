import numpy as np
from PIL import Image

width, height = 500, 500
max_iter = 1000

re_start, re_end = -2.0, 1.0
im_start, im_end = -1.0, 1.0

image = np.zeros((height, width), dtype=np.uint8)

for y in range(height):
    for x in range(width):
        c = complex(re_start + (x / width) * (re_end - re_start),
                    im_start + (y / height) * (im_end - im_start))
        z = 0
        n = 0
        while abs(z) <= 2 and n < max_iter:
            z = z * z + c
            n += 1
        color = int(255 * n / max_iter)
        image[y, x] = color

img = Image.fromarray(image)
img.save("mandelbrot.png")
