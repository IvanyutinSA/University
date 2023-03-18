import copy
from pprint import pprint
f = open("Test.txt")

start_vertex = int(f.readline()) - 1
weight_matrix = []
for line in f:
    weight_matrix.append(list(map(float, line.split())))

v_amount = len(weight_matrix)
current_lambda = [0 for x in range(v_amount)]
previous_lambda = []
for i in range(v_amount):
    previous_lambda.append(float("inf") if i != start_vertex else 0)

for k in range(1, v_amount + 1):
    for i in range(v_amount):
        min_sum = float("inf") if start_vertex != i else 0
        for j in range(v_amount):
            min_sum = min(min_sum, previous_lambda[j] + weight_matrix[j][i])
        current_lambda[i] = min_sum

    if current_lambda == previous_lambda:
        break
    elif k == v_amount:
        print("Есть цикл по отрицательнмоу контуру")
    previous_lambda = current_lambda.copy()

for i in range(len(current_lambda)):
    if current_lambda[i] != float("inf"):
        current_lambda[i] = int(current_lambda[i])

print("Вершина\tРасстояние")
for i in range(1, v_amount+1):
    print(i, current_lambda[i-1], sep="\t\t")













