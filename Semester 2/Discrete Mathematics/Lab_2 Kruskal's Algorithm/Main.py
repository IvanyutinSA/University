def inputData(nodes, edges):
    f = open('Test_1.txt')
    nodes.update(list(map(int, f.readline().split())))
    for i in range(int(f.readline())):
        temp_list = list(f.readline().split())
        temp_list[2] = int(temp_list[2])
        edges.append(tuple(temp_list.copy()))


allNodes = set()
nodeSets = set()
edges = list()
goodEdgesLength = list()

inputData(allNodes, edges)

edges.sort(key=lambda x: x[2])

for edge in edges:
    firstNode = edge[0]
    secondNode = edge[1]
    edgeLength = edge[2]

    extraNodeSet = set()
    basedNodeSets = nodeSets.copy()
    fl = True

    for nodeSet in basedNodeSets:
        if firstNode in nodeSet and secondNode in nodeSet:
            fl = False
            break
        if firstNode not in nodeSet and secondNode not in nodeSet:
            continue

        fl = False

        if len(extraNodeSet) == 0:
            goodEdgesLength.append(edgeLength)

        nodeSets.remove(nodeSet)
        if len(extraNodeSet) != 0:
            nodeSets.remove(tuple(sorted(extraNodeSet)))
        extraNodeSet.update(nodeSet)
        extraNodeSet.add(firstNode)
        extraNodeSet.add(secondNode)
        nodeSets.add(tuple(sorted(extraNodeSet)))


    if fl:
        goodEdgesLength.append(edgeLength)
        extraNodeSet.add(firstNode)
        extraNodeSet.add(secondNode)
        nodeSets.add(tuple(sorted(extraNodeSet)))

print(sum(goodEdgesLength))





