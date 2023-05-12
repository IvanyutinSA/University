import collections

f = open('Test.txt')

adjacency_matrix = [list(map(int, line.split())) for line in f]

nodes = list(range(len(adjacency_matrix)))
connectivity_components = list()
current_connectivity_component = list()

queue = collections.deque()
queue.append(nodes.pop())

while True:
    if not queue:
        if current_connectivity_component:
            connectivity_components.append(current_connectivity_component.copy())
            current_connectivity_component = list()
        if nodes:
            queue.append(nodes.pop())
        else:
            break

    current_node = queue.popleft()

    for i in range(len(adjacency_matrix)):
        if i in nodes and adjacency_matrix[current_node][i]:
            queue.append(i)
            nodes.remove(i)

    current_connectivity_component.append(current_node)

print(connectivity_components)
