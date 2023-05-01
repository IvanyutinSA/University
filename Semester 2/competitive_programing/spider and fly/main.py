f = open('spider_and_fly/input_s1_15.txt')
spider = [0, 0, 0]
fly = [0, 0, 0]
a, b, c = map(int, f.readline().split())
spider[0], spider[1], spider[2] = map(int, f.readline().split())
fly[0], fly[1], fly[2] = map(int, f.readline().split())

if (
        spider[0] != fly[0] and
        (spider[0] == a or spider[0] == 0) and
        (fly[0] == a or fly[0] == 0)
):
    base = min(abs(spider[1] + fly[1]), abs((a - spider[1]) + (a - fly[1]))) + abs(spider[0] - fly[0])
    height = abs(spider[2] - fly[2])

elif (
        spider[1] != fly[1] and
        (spider[1] == b or spider[1] == 0) and
        (fly[1] == b or fly[1] == 0)
):
    base = min(abs(spider[0] + fly[0]), abs((a - spider[0]) + (a - fly[0]))) + abs(spider[1] - fly[1])
    height = abs(spider[2] - fly[2])

elif (
        spider[2] != fly[0] and
        (spider[2] == c or spider[2] == 0) and
        (fly[2] == c or fly[2] == 0)
):
    base = min(abs(spider[2] + fly[2]), abs((c - spider[2]) + (c - fly[2]))) + abs(spider[1] - fly[1])
    height = abs(spider[0] - fly[0])

elif (
        (spider[0] == 0 or spider[0] == a) and
        (fly[1] == 0 or fly[1] == b) or (fly[0] == 0 or fly[0] == a) and
        (spider[1] == 0 or spider[1] == b)
):
    base = abs(spider[0] - fly[0]) + abs(spider[1] - fly[1])
    height = abs(spider[2] - fly[2])

elif (
        (spider[1] == 0 or spider[1] == b) and
        (fly[2] == 0 or fly[2] == c) or (fly[1] == 0 or fly[1] == b)
        and (spider[2] == 0 or spider[2] == c)
):
    base = abs(spider[2] - fly[2]) + abs(spider[1] - fly[1])
    height = abs(spider[0] - fly[0])

else:
    base = abs(spider[0]-fly[0]) + abs(spider[2] - fly[2])
    height = abs(spider[1] - fly[1])

total_length = (base ** 2 + height ** 2) ** (1 / 2)

print(total_length)
