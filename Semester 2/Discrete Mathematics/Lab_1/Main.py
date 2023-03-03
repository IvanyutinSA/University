def inputData2(nodes, edges):
    nodes.update([1, 2, 3, 4, 5, 6, 7, 8, 9])
    edges += [
            (1, 2, 15), (1, 5, 14), (1, 4, 23), (2, 3, 19), (2, 4, 16), (2, 5, 15), (3, 5, 14), (3, 6, 26),
            (4, 5, 25), (4, 7, 23), (4, 8, 20), (5, 6, 24), (5, 8, 27), (5, 9, 18), (7, 8, 14), (8, 9, 18)
        ]


def inputData(nodes, edges):
    f = open('Test_1.txt')
    nodes.update(list(map(int, f.readline().split())))
    for i in range(int(f.readline())):
        temp_list = list(map(int, f.readline().split()))
        temp_list[2] = int(temp_list[2])
        edges.append(tuple(temp_list.copy()))


consNodes = set()
consEdges = list()
notConsNodes = set()
notConsEdges = list()
graphLength = 0

inputData(notConsNodes, notConsEdges)

curNode = notConsNodes.pop()
consNodes.add(curNode)

while len(notConsNodes) != 0:
    for edge in notConsEdges:
        firstNode = edge[0]
        secondNode = edge[1]
        edgeLength = edge[2]
        if firstNode in consNodes or secondNode in consNodes:
            consEdges.append(edge)
            notConsEdges.remove(edge)

    consEdges.sort(key=lambda x: x[2])
    for edge in consEdges:
        consEdges.remove(edge)
        firstNode = edge[0]
        secondNode = edge[1]
        edgeLength = edge[2]
        if firstNode in consNodes and secondNode in consNodes:
            continue
        curNode = firstNode if secondNode in consNodes else secondNode
        consNodes.add(curNode)
        notConsNodes.remove(curNode)
        graphLength += edgeLength
        break


print(graphLength)



