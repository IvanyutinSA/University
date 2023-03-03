import copy
graph = dict()
f = open('Test_2.txt')

start_node, finish_node = f.readline().split()
nodes = f.readline().split()
current_node = start_node

for row_node in nodes:
    graph[row_node] = dict()
    nodes_copy = nodes.copy()
    for length in map(int, f.readline().split()):
        column_node = nodes_copy.pop(0)
        if length != 0:
            graph[row_node][column_node] = length

graph_copy = copy.deepcopy(graph)
temp_dict = graph[start_node].copy()
temp_dict[start_node] = 0
temp_dict["current_length"] = 0
last_line = dict()
used_nodes = set(current_node)

while current_node != finish_node:
    some_dict = {k:v+temp_dict["current_length"] for k, v in graph_copy[current_node].items()}
    current_line = dict(sorted(some_dict.items(), key=lambda item: item[1]))

    graph_copy.pop(current_node)
    for key in graph_copy.keys():
        if current_node in graph_copy[key]:
            graph_copy[key].pop(current_node)

    if not last_line:
        last_line = current_line
    else:
        for node in set(last_line.keys()).union(set(current_line.keys())):
            if node in current_line and node in last_line:
                current_line[node] = min(current_line[node], last_line[node])
            elif node in last_line:
                current_line[node] = last_line[node]

    if current_node in current_line:
        current_line.pop(current_node)
    last_line = current_line
    current_line = dict(sorted(current_line.items(), key=lambda x: x[1]))
    final_node, final_length = sorted(current_line.items(), key=lambda x: x[1])[0]
    current_node = final_node
    temp_dict["current_length"] = final_length
    temp_dict[final_node] = final_length
    used_nodes.add(current_node)

the_path = [current_node]
used_nodes.remove(current_node)

while current_node != start_node:
    for node in used_nodes:
        if node in graph[current_node].keys():
            if temp_dict[node] == temp_dict[current_node] - graph[current_node][node]:
                the_path.append(node)
                used_nodes.remove(node)
                current_node = node
                break
the_path.reverse()
print(temp_dict["current_length"])
print(the_path)








