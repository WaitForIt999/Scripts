import matplotlib.pyplot as plt
import numpy as np


ypoints = np.array([3, 8, 1, 10])

plt.plot(ypoints, marker = 'o')
plt.plot(ypoints, 'o:r')
plt.plot(ypoints, marker = 'x', linestyle = 'dotted', color = 'green')
plt.plot(ypoints)
plt.xticks(np.arange(len(ypoints)), ['A', 'B', 'C', 'D'])
plt.yticks(np.arange(0, 11, 1))
plt.title("Line Plot")
plt.xlabel("X-axis")
plt.ylabel("Y-axis")
plt.grid()