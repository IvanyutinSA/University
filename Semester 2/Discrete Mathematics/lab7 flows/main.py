import copy
import math
from functools import reduce
from pprint import pprint


def restore_dijkstra_path(matrix: list[list[int]], distances: list[float], end_node: int) -> list[int]:
    path = [end_node]
    v = end_node

    for i in range(len(matrix)):
        for u in range(len(matrix)):
            if distances[v] - matrix[u][v] == distances[u] and u != v:
                path.append(u)
                v = u
                break

    return path[::-1]


def dijkstra(matrix: list[list[int]], started_node: int) -> list[float]:
    distances = [float('inf') for x in range(len(matrix))]
    visited_nodes = [False for x in range(len(matrix))]
    distances[started_node] = 0

    for i in range(len(matrix)):
        min_marked_node = -1

        for node in range(len(matrix)):
            if (
                    not visited_nodes[node] and
                    (min_marked_node == -1 or
                     distances[node] < distances[min_marked_node])
            ):
                min_marked_node = node

        visited_nodes[min_marked_node] = True

        for node in range(len(matrix)):
            if distances[min_marked_node] + matrix[min_marked_node][node] < distances[node]:
                distances[node] = distances[min_marked_node] + matrix[min_marked_node][node]

    return distances


f = open('Test.txt')

weight_matrix = [[float('inf') if x == '-1' else int(x) for x in line.split()] for line in f]

I, S = 0, len(weight_matrix)-1
total_flow = 0

while True:
    distances = dijkstra(weight_matrix, I)
    if distances[S] == float('inf'):
        break

    path = restore_dijkstra_path(weight_matrix, distances, S)

    min_distance = float('inf')

    path_distances = list()

    for i in range(1, len(path)):
        node_out = path[i - 1]
        node_in = path[i]
        path_distances.append(weight_matrix[node_out][node_in])

    min_distance = min(path_distances)

    for i in range(1, len(path)):
        node_out = path[i-1]
        node_in = path[i]
        weight_matrix[node_out][node_in] -= min_distance
        if not weight_matrix[node_out][node_in]:
            weight_matrix[node_out][node_in] = float('inf')

    total_flow += min_distance

print(total_flow)
