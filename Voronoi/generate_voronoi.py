import numpy as np
from scipy.spatial import Voronoi
from PIL import Image

multiplier = 9
width, height = 189 * multiplier, 75 * multiplier
num_points = 100

points = np.random.rand(num_points, 2) * [width, height]
vor = Voronoi(points)

image = np.zeros((height, width), dtype=np.uint8)

for y in range(height):
    for x in range(width):
        distances = np.linalg.norm(points - [x, y], axis=1)
        distance = np.min(distances)
        intensity = np.clip(distance * 2, 0, 255)
        image[y, x] = 255 - int(intensity) 

img = Image.fromarray(image)
img.save("voronoi_5.png")
