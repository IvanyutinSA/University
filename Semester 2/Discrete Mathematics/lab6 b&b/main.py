import copy


class Cluster:
    def __init__(self, table, weight, penalty):
        self.table = table
        self.weight = weight
        self.penalty = 0
        self.nodes = set()
        self.enough = False

    def get_total_weight(self):
        return self.weight + self.penalty

    def set_weight(self, weight):
        self.weight = weight

    def increase_weight(self, weight):
        self.weight += weight

    def add_nodes(self, row, column):
        self.nodes.update(row, column)

    def is_enough(self, nodes):
        return self.nodes == nodes or self.enough


def recalculate_table(table):
    extra_weight = 0
    for row in table.keys():
        min_value = min(table[row].values())
        extra_weight += min_value
        for column in table[row].keys():
            table[row][column] -= min_value
    row_node = sorted(table.keys())[0]
    for column in table[row_node].keys():
        min_value = min([table[row][column] for row in table.keys()])
        extra_weight += min_value
        for row in table.keys():
            table[row][column] -= min_value
    return extra_weight


def get_suit_edge(table):
    zeros_degrees = list()
    for row in table.keys():
        for column in table[row].keys():
            if not table[row][column]:
                column_degree = min([table[row][x] for x in table[row].keys() if x != column])
                row_degree = min([table[x][column] for x in table.keys() if x != row])
                total_degree = column_degree + row_degree
                if total_degree == float('inf'):
                    total_degree = 0
                zeros_degrees.append((total_degree, row, column))
    return max(zeros_degrees)


f = open("Test.txt")
nodes = f.readline().split()
table = dict()
for row in nodes:
    line = list(map(float, f.readline().split()))
    table[row] = dict()
    for column in nodes:
        value = line.pop(0)
        table[row][column] = value

nodes = set(nodes)
clusters = list()
clusters.append(Cluster(table, 0, 0))


while not clusters[0].is_enough(nodes):
    cluster = clusters[0]
    cluster.penalty = 0
    current_table = cluster.table
    extra_weight = recalculate_table(current_table)
    total_weight = extra_weight + cluster.weight
    penalty, final_row, final_column = get_suit_edge(current_table)
    if len(current_table.keys()) == 2 and len(current_table[final_row].keys()) == 2:
        cluster.increase_weight(extra_weight)
        for row in current_table.keys():
            for column in current_table[row].keys():
                cluster.add_nodes(row, column)
        clusters.sort(key=lambda x: x.get_total_weight())
        cluster.enough = True
        continue
    extra_table = copy.deepcopy(current_table)
    extra_table[final_row][final_column] = float('inf')
    left_cluster = Cluster(extra_table, total_weight, penalty)
    clusters.append(left_cluster)
    if (final_column in current_table.keys()
        and final_row in current_table[final_row].keys()):
        current_table[final_column][final_row] = float('inf')
    current_table.pop(final_row)
    for row in current_table.keys():
        current_table[row].pop(final_column)
    cluster.table = copy.deepcopy(current_table)
    cluster.increase_weight(extra_weight)
    cluster.add_nodes(final_row, final_column)
    clusters.sort(key=lambda x: x.get_total_weight())


print(clusters[0].weight)

