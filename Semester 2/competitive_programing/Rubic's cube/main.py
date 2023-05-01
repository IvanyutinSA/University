def calculate(cubes_elem, axis, row, direction):
    if cubes_elem[axis] != row:
        return
    axes = sorted(set(cubes_elem.keys()).difference(axis))
    s = axes[0]
    t = axes[1]
    vector = [cubes_elem[s], cubes_elem[t]]
    rotate_times = 1
    if direction < 0:
        rotate_times = 3
    for i in range(rotate_times):
        vector = rotate(vector)
    cubes_elem[s] = vector[0]
    cubes_elem[t] = vector[1]


def rotate(vector):
    return [vector[1], n - vector[0] + 1]


f = open('rubic/input_s1_20.txt')
n, m = list(map(int, f.readline().split()))
x,y,z = list(map(int, f.readline().split()))
cubes_elem = {'x': x, 'y': y, 'z': z}

for i in range(m):
    axis, row, direction = f.readline().split()
    axis = axis.lower()
    row = int(row)
    direction = int(direction)
    calculate(cubes_elem, axis, row, direction)

print(cubes_elem)
