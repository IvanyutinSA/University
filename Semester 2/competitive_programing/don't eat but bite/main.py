def findway(tree, start, end):
    startpath = []
    endpath = []
    path = 0
    q = 0
    if start == [0]:
        for j in range(len(end) - 1, 0, -1):
            endpath.append(end[j])
    for i in range(1, min(len(start), len(end))):
        if start[i] != end[i]:
            for j in range(len(start) - 1, i - 1, -1):
                startpath.append(start[j])
            for j in range(len(end) - 1, i - 1, -1):
                endpath.append(end[j])
            break
        elif i == len(start) - 1:
            for j in range(len(end) - 1, i - 1, -1):
                endpath.append(end[j])
            break
        elif i == len(end) - 1:
            for j in range(len(start) - 1, i - 1, -1):
                startpath.append(start[j])
            break

    while (q < max(len(startpath), len(endpath))):
        if q < len(startpath):
            path += tree[startpath[q]][0]
        if q < len(endpath):
            path += tree[endpath[q]][0]
        q += 1

    return path


def chooseend(tree, start, apples):
    wae = findway(tree, start, apples[0])
    ind = 0
    c = 0
    for i in apples:
        if wae < findway(tree, start, i):
            wae = findway(tree, start, i)
            ind = c
        c += 1
    return apples[ind]


def choosestart(tree, start, apples):
    wae = findway(tree, start, apples[0])
    ind = 0
    c = 0
    for i in apples:
        if wae > findway(tree, start, i):
            wae = findway(tree, start, i)
            ind = c
        c += 1

    return apples[ind]


def chooseapple(start, apples, end):
    ind = 0
    prior = 0
    for j in range(len(apples)):
        if apples[j] != end:
            for i in range(1, min(len(start), len(apples[j]))):
                if i == len(start) - 1 and start[i] == apples[j][i]:
                    if len(apples[j]) > prior:
                        prior = len(apples[j])
                        ind = j
                elif start[i] != apples[j][i]:
                    if i > prior:
                        prior = i
                        ind = j
    return apples[ind]


f = open('input.txt', 'r')
branches = [[0]]
path = 0
apples = []
apples_sort = []
a = f.readline().split(' ')
for i in range(int(a[0])):
    q = f.readline().split(' ')
    branches.append([int(q[1])])
    for k in range(1, len(branches[int(q[0])])):
        branches[-1].append(branches[int(q[0])][k])
    branches[-1].append(len(branches) - 1)

for i in range(int(a[1])):
    q = f.readline().split(' ')
    apples.append(branches[int(q[0])])
    apples_sort.append(int(q[1]))

q = f.readline().split(' ')
start = branches[int(q[0])]
for i in range(len(apples_sort)):
    if apples_sort[i] < int(q[1]):
        apples[i] = []
while ([] in apples):
    apples.remove([])

end = chooseend(branches, start, apples)
while len(apples) != 0:
    path += findway(branches, start, chooseapple(start, apples, end))
    au = chooseapple(start, apples, end)
    start = au
    apples.remove(au)
path += findway(branches, start, end)
print(path)
