import copy
from pprint import pprint
f = open("Test.txt")
adjacency_matrix = []
for line in f:
    adjacency_matrix.append(list(map(float, line.split())))

v_amount = len(adjacency_matrix)
current_matrix = copy.deepcopy(adjacency_matrix)

for k in range(v_amount):
    previous_matrix = copy.deepcopy(current_matrix)
    for i in range(v_amount):
        for j in range(v_amount):
            current_matrix[i][j] = min(previous_matrix[i][k] + previous_matrix[k][j], previous_matrix[i][j])


for i in range(v_amount):
    for j in range(v_amount):
        if current_matrix[i][j] != float("inf"):
            current_matrix[i][j] = int(current_matrix[i][j])

pprint(current_matrix)
